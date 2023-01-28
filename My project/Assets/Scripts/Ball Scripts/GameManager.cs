using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, inRingInterface
{
	#region Singleton class: GameManager

	public static GameManager Instance;

	void Awake ()
	{
		if (Instance == null) {
			Instance = this;
		}
	}

	#endregion

	Camera cam;

	[SerializeField] private Ball ball;
	[SerializeField] private Trajectory trajectory;
	[SerializeField] float pushForce = 4f;
	private Vector2 admissibleForce;

	bool isDragging = false;

	Vector2 startPoint;
	Vector2 endPoint;
	Vector2 direction;
	Vector2 force;
	float distance;
	[SerializeField] private bool InRing = true;

	void Start ()
	{
		cam = Camera.main;
		ball.DesactivateRb ();
	}

	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			isDragging = true;
			OnDragStart ();
		}
		if (Input.GetMouseButtonUp (0)) {
			isDragging = false;
			OnDragEnd ();
		}

		if (isDragging) {
			OnDrag ();
		}

		admissibleForce.y = ball.transform.position.y;
	}

	void OnDragStart ()
	{
	       if(InRing)
	       {
	            ball.DesactivateRb ();
           		startPoint = cam.ScreenToWorldPoint (Input.mousePosition);
           		trajectory.Show ();

           	    PlayerPrefs.SetInt("bow sound", 1);
	       }
	}

	void OnDrag ()
	{
	    if(InRing)
	    {
            endPoint = cam.ScreenToWorldPoint (Input.mousePosition);
            distance = Vector2.Distance (startPoint, endPoint);
            direction = (startPoint - endPoint).normalized;
            force = direction * distance * pushForce;
            Debug.Log("farse = " + force);

            Debug.DrawLine (startPoint, endPoint);


            trajectory.UpdateDots (ball.pos, force);
		}
	}

	void OnDragEnd ()
	{
	 if(InRing)
      {
        if(force.y + 5f >= admissibleForce.y + 10f)
        {
         ball.ActivateRb ();
        }

        if(force.y + 5f >= admissibleForce.y + 10f)
        {
         ball.Push (force);

         InRing = false;
        }

		trajectory.Hide ();

		trajectory.PassingValuesRing ();
	  }
	}

	public void InRingControl()
	{
	  InRing = true;
	}
}
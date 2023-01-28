using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RandomRingPosition))]
public class RingGeneration : MonoBehaviour
{
   	[SerializeField] GameObject RingDotPrefab;
    [SerializeField] GameObject[] dotpos;
    [Space(10)]
    [SerializeField] [Range (0.1f, 1f)] float coefficient_for_max_y;
    [SerializeField] [Range (20f, 100f)] int repetition;
    [SerializeField] float coroutine_return_time;
    [Space(10)]
    [SerializeField] private float increase;
    [SerializeField] private float distance_increase;
    [SerializeField] private float coef_distance_increase;
     int x = 0;
     private Vector2 Next_ring_position;
     [HideInInspector] public float random_position_x;
     [HideInInspector] public float random_position_y;
     [HideInInspector] private RandomRingPosition _randomRingPosition;

   	void Start()
   	{
   	  dotpos = new GameObject[3];

   	  dotpos[1] = GameObject.Find("Ring start");
   	  dotpos[2] = Instantiate (RingDotPrefab, new Vector2(0, 0), Quaternion.identity);

   	  _randomRingPosition = GetComponent<RandomRingPosition>();
   	  StartCoroutine(Acceleration());
   	}

   	public void createNewRing()
   	{

      if(dotpos[1] != null)
        dotpos[0] = dotpos[1];

      Destroy(dotpos[0]);

     if(dotpos[2] != null)
        dotpos[1] = dotpos[2];

     Next_ring_position = dotpos[1].transform.position;

     _randomRingPosition.RandomPosition(Next_ring_position);

   	 dotpos[2] = Instantiate (RingDotPrefab, new Vector2(random_position_x, random_position_y), Quaternion.identity);
     Debug.Log("dotpos[2] = " + dotpos[2].transform.position);

     x++;
   	}

    public void positionRing(float max_y)
    {
     StartCoroutine(animRing(max_y));
    }

    IEnumerator animRing(float max_y)
    {
         bool end = false;

            for(int a = 1; a <= repetition; a++)
            {

              for (int i = 1; i <= 2; i++)
              {
               Vector2 pos;
               pos = dotpos[i].transform.position;
               pos.y = pos.y - (max_y) / repetition * coefficient_for_max_y;
               if((max_y) / repetition * coefficient_for_max_y > 0)
                    dotpos[i].transform.position = pos;
              }
              yield return new WaitForSeconds(coroutine_return_time);
            }
         
    }

    IEnumerator Acceleration()
    {
         bool x = true;
         while(x)
         {
            for(int a = 1; a <= repetition; a++)
            {
              for (int i = 1; i <= 2; i++)
              {
               Vector2 pos;
               pos = dotpos[i].transform.position;
               pos.y = pos.y - distance_increase;
               dotpos[i].transform.position = pos;
              }
            }
            increase = increase - increase * 0.005f;
            distance_increase = distance_increase + coef_distance_increase;
            coef_distance_increase = coef_distance_increase - coef_distance_increase * 0.015f;
            
            yield return new WaitForSeconds(increase);
         }

    }
}

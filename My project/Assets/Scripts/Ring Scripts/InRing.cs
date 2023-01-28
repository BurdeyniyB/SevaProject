using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(EdgeCollider2D))]
public class InRing : MonoBehaviour
{
   private GameObject GameManager;
   private inRingInterface _inRingInterface;

    void Start()
    {
      GameManager = GameObject.Find("GameManager");

      _inRingInterface = GameManager.GetComponent<inRingInterface>();
    }

    private void OnTriggerEnter2D(Collider2D other)
      {
        if (other.CompareTag("Player"))
        {
        Debug.Log("InRing");

        PlayerPrefs.SetInt("In ring sound", 1);
        PlayerPrefs.SetInt("BlockRing", 1);
        _inRingInterface.InRingControl();
        }
      }
}

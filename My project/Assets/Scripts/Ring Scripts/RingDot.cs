using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(EdgeCollider2D))]
public class RingDot : MonoBehaviour
{
   private GameObject _ringGenerationObj;
   private RingGeneration _ringGeneration;
   private GameObject _ballObj;
   private Ball _ball;

   void Update()
   {
   _ringGenerationObj = GameObject.Find("RingGeneration");
   _ballObj = GameObject.Find("Player");


   _ringGeneration = _ringGenerationObj.GetComponent<RingGeneration>();
   _ball = _ballObj.GetComponent<Ball>();
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
     if (other.CompareTag("Player"))
     {
      //_ball.Static();
      this.gameObject.SetActive(false);

      _ringGeneration.createNewRing();
     }
   }

}

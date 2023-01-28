using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RingGeneration))]
public class RandomRingPosition : MonoBehaviour
{
    [SerializeField] RingGeneration _ringGeneration;
    private float random_x;
    private float random_x_1;
    private float random_x_2;
    private int random_x_3;
    private float random_y;

    public void RandomPosition(Vector2 Next_ring_position)
    {
         random_y = Random.Range((Next_ring_position.y + 0.6f), (Next_ring_position.y + 0.9f));

         random_x_1 = Random.Range(-2.0f, (Next_ring_position.x - 0.85f));
         random_x_2 = Random.Range((Next_ring_position.x + 0.85f), 2.0f);


              if(random_x_1 > -2.0f)
              {
               random_x_3 = 0;
              }
              else
              {
              if(random_x_2 < 2.0f)
              {
               random_x_3 = 1;
              }
              }

                if(random_x_1 > -2.0f && random_x_2 < 2.0f)
                {
                 random_x_3 = Random.Range(0, 2);
                }

         Debug.Log("random_x_3 = " + random_x_3 + " random_x_1 = " + random_x_1 + " random_x_2 = " + random_x_2 + " Next_ring_position = " + Next_ring_position);

         if(random_x_3 == 0)
         {
          random_x = random_x_1;
         }
         else
         {
          random_x = random_x_2;
         }

        _ringGeneration.random_position_x = random_x;
        _ringGeneration.random_position_y = random_y;
    }

}

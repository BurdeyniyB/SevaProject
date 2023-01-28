using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Exit_from_arena : MonoBehaviour
{
   [SerializeField] private LevelManager _levelmanager;
   [SerializeField] private GameObject Panel_fail;
   [SerializeField] private Text _scoreText_panel_fail;
   [SerializeField] private GameObject _new_score_panel_fail;
   private int score_for_check;
   private int _best_score_for_check;

   void Start()
   {
     _best_score_for_check = PlayerPrefs.GetInt("Best score");
   }

   public void Check(int score)
   {
     score_for_check = score;
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
     if (other.CompareTag("Player"))
     {
         if(score_for_check == 0)
         {
          _levelmanager.Task();
         }
         else
         {
          _scoreText_panel_fail.text = score_for_check.ToString();
          if(_best_score_for_check < score_for_check)
             _new_score_panel_fail.SetActive(true);

          Panel_fail.SetActive(true);
         }
     }
   }
}

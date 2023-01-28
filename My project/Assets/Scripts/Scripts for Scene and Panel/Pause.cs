using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Development.System
{
    public class Pause : MonoBehaviour
    {
        [SerializeField] private GameObject Pause_panel;

        public void ActivePausePanel()
        {
            Pause_panel.SetActive(true);

            PlayerPrefs.SetInt("Click", 1);
        }

        public void BlockPausePanel()
        {
            Pause_panel.SetActive(false);
            
            PlayerPrefs.SetInt("Click", 1);
        }

        public void StopTime()
        {
            Time.timeScale = 0;
        }

        public void ContinueTime()
        {
            Time.timeScale = 1;
        }
    }
}
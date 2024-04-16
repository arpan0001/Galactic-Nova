using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TImer : MonoBehaviour
{
    [SerializeField]Text timerText;
    [SerializeField] float timePassed;
    bool keepTime = false;

    void OnEnable()

  {
    EventManager.onStartGame += StartTimer;
    EventManager.onPlayerDeath += StopTimer;

  }

  void OnDisable()

  {
   EventManager.onStartGame -= StartTimer;
   EventManager.onPlayerDeath -= StopTimer;
  } 

  void Update()
  {
    if(keepTime)
     {
        timePassed += Time.deltaTime;
        UpdateTimerDisplay();
     }
  }

  void StartTimer()
  {
    timePassed = 0;
    keepTime = true;
  }

  void StopTimer()
  {
     keepTime = false;
  }

  void UpdateTimerDisplay()
  {
    float minutes;
    float seconds;

    minutes = Mathf.FloorToInt(timePassed/60);
    seconds = timePassed%60;

    timerText.text = string.Format("{0}:{1:00.0}", minutes, seconds);

   
  }

}




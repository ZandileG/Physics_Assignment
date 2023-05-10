using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class CountdownTimer : MonoBehaviour
{
  //the countdown value can be changed in the Inspector
    public int countdown;
    [SerializeField] TMP_Text countdownLabel;


  //the current time is the first frame
    float nowTime = 0f;

  //the timer starts at 3 
    float startTime = 3;


    void Start()
    {
      //the current time is equated to the starting time 
        nowTime = startTime;
    }

    void Update()
    {
      //the timer reduces by one value after 1 second
        nowTime -= 1 * Time.deltaTime;


      //the default text value changes to 0 when the timer finishes
        countdownLabel.text = nowTime.ToString("0");


      //the countdown ends at 0
        if (nowTime <= 0)
        {
           nowTime = 0;

          //the game starts after the timer gets to 0
            SceneManager.LoadScene("Air_HockeyGame");
        }
    }
}

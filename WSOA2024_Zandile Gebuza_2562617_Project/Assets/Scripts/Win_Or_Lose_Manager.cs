using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win_Or_Lose_Manager : MonoBehaviour
{
  //headings to keep things organised when they appear in the Inspector 
    [Header("Canvases")]
    public GameObject ScoreCanvas;
    public GameObject RestartGameCanvas;

    [Header("RestartGameCanvas")]
    public GameObject WonLabel;
    public GameObject LostLabel;

    [Header("ComponentScripts")]
    public Score_Board scoreBoard;

    public PuckMovement puckMovement;
    public PlayerMovement playerMovement;
    public AI_Movement ai_Movement;


  //the Restart Cnavas appears to show who won
    public void ShowRestartCanvas (bool did_AI_Win)
     {
         Time.timeScale = 0;
         ScoreCanvas.SetActive(false);
         RestartGameCanvas.SetActive(true);

       //text appears according to which player won or lost
         if (did_AI_Win)
         {
             WonLabel.SetActive(false);
             LostLabel.SetActive(true);
         }

         else
         {
             WonLabel.SetActive(true);
             LostLabel.SetActive(false);
         }
     }

   // when the restart button is pressed, everything is reset
     public void Restart()
     {
         Time.timeScale = 1;

         ScoreCanvas.SetActive(true);
         RestartGameCanvas.SetActive(false);

         scoreBoard.ResetScores();
         puckMovement.CenterPuck();
         playerMovement.ResetPosition();
         ai_Movement.ResetPosition();
     }  
}

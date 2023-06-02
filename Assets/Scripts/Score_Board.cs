using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Board : MonoBehaviour
{
    public enum Score
    {
        AI_Score, PlayerScore
    }

  //the score labels are declared as they are used in the code
    public Text AI_ScoreLabel, PlayerScoreLabel;


  //the manager is accessible in the Inspector
    public Win_Or_Lose_Manager win_or_lose_Manager;
    

   //the number of goals that a player has to get in order to win
   //the number can be set in the Inspector
     public int WinningScore;


  //both the players' socres are called as they are used in the code
    private int ai_Score, playerScore;


   //the value of the AI's score
     private int AI_Score
     {
        get 
        { 
            return ai_Score; 
        }

       //the Restart Canvas will appear on the screen
         set
         {
             ai_Score = value;
             if (value == WinningScore)
                 win_or_lose_Manager.ShowRestartCanvas(true);
         }
     }

  //the value of the player's score
    private int PlayerScore
     {
         get
         { 
            return playerScore; 
         }

      //the Restart Canvas will not appear on the screen
        set
        {
             playerScore = value;
             if (value == WinningScore)
                 win_or_lose_Manager.ShowRestartCanvas(false);
         }
     }


    //whichever player scored a goal will gain a point 
    public void Increment (Score whichScore)
     {
         if (whichScore == Score.AI_Score)
             AI_ScoreLabel.text = (++ AI_Score).ToString();
         else
             PlayerScoreLabel.text = (++ PlayerScore).ToString();
     }

  //scores are returned to 0 when the game ends or restarts
    public void ResetScores()
    {
         AI_Score = playerScore = 0;
         AI_ScoreLabel.text = PlayerScoreLabel.text = "0";
    } 
}

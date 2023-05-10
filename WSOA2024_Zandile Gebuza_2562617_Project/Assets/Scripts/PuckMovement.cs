using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckMovement : MonoBehaviour
{
    public Score_Board ScoreBoardInstance;

  //questions if a player has scored 
    public static bool Scored 
    { 
        get; 
        private set; 
    }

  //the puck's speed is accessible in the Inspector
    public float Puck_Speed;


  //the puck's rigidbody is called as it used in the code
    private Rigidbody2D puck_rbody;


  //the puck's rigidbody is activated
    void Start()
    {
        puck_rbody = GetComponent<Rigidbody2D>();
        Scored = false;
    }

    //if a player scores, the score board changes and the puck resets
    private void OnTriggerEnter2D (Collider2D other)
    {
        if (!Scored)
        {
            if (other.tag == "AIScored")
            {
                ScoreBoardInstance.Increment(Score_Board.Score.PlayerScore);
                Scored = true;
                StartCoroutine (ResetPuck (false)); 
            }

            else if (other.tag == "PlayerScored")
            {
                ScoreBoardInstance.Increment(Score_Board.Score.AI_Score);
                Scored = true;
                StartCoroutine (ResetPuck(true)); 
            }
        }

    }

    //the puck will be returned closer to the player that did not score
    private IEnumerator ResetPuck (bool did_AI_Score)
    {
        yield return new WaitForSecondsRealtime(1);
        Scored = false;
        puck_rbody.velocity = puck_rbody.position = new Vector2(0, 0);

        if (did_AI_Score)
            puck_rbody.position = new Vector2(-1, 0);

        else
            puck_rbody.position = new Vector2(1, 0);
    }

  //the puck is centered 
    public void CenterPuck()
    {
        puck_rbody.position = new Vector2(0, 0);
    }    

  //puck moves using the speed entered in the Inspector
    private void FixedUpdate()
    {
        puck_rbody.velocity = Vector2.ClampMagnitude(puck_rbody.velocity, Puck_Speed);
    }
}

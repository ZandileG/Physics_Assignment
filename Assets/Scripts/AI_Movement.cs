using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Movement : MonoBehaviour
{
  //the speed is visible in the inspector and the value can be altered 
  //it will also be used in the code
    public float AI_Speed;


  //the AI's rigidbody is used in the code
    private Rigidbody2D ai_rbody;
  

  //the AI's starting position is used in the code
    private Vector2 startPlace;

    
  //the puck's rigidbody is called as it is used in the code
    public Rigidbody2D Puck;


  //the AI and puck's board limits are used in the code
    public Transform AI_Limit;
    private Limit ai_Limit;

    public Transform PuckLimit;
    private Limit puckLimit;
    
    private Vector2 targetPosition;


  //questions what happens when the puck is on the opponent's side for the fist time
    private bool isFirstTimeOnTheOtherSide = true;
    

  //this makes the AI not follow the puck too precisely
    private float offsetYFromTarget;
    

    private void Start()
    {
        ai_rbody = GetComponent<Rigidbody2D>();

      //the AI's starting place is equated to its rigidbody position
        startPlace = ai_rbody.position;

      //code for the next four lines is referenced from:
      //Rešetár, M. (2017). #7 Make an Air Hockey Game in Unity - WIN / LOSE (Code). [online] Reso Coder.
      //Available at: https://resocoder.com/2017/07/07/7-make-an-air-hockey-game-in-unity-win-loose-code/ [Accessed 3 May 2023].
      //the AI's limits on the board are activated  
        ai_Limit = new Limit (AI_Limit.GetChild(0).position.y,
                              AI_Limit.GetChild(1).position.y,
                              AI_Limit.GetChild(2).position.x,
                              AI_Limit.GetChild(3).position.x);
        

      //code for the next four lines is referenced from:
      //Rešetár, M. (2017). #7 Make an Air Hockey Game in Unity - WIN / LOSE (Code). [online] Reso Coder.
      //Available at: https://resocoder.com/2017/07/07/7-make-an-air-hockey-game-in-unity-win-loose-code/ [Accessed 3 May 2023].
      //the puck's limits on the AI's side of the board are activated  
        puckLimit = new Limit (PuckLimit.GetChild (0).position.y,
                               PuckLimit.GetChild (1).position.y,
                               PuckLimit.GetChild (2).position.x,
                               PuckLimit.GetChild (3).position.x);  
    }

  //when no one scores this is how the AI will move
    private void FixedUpdate()
    {
       if (!PuckMovement.Scored)
          {
            //the AI's movement speed 
              float movingSpeed;

              //the puck has not reached its bottom limit 
                if (Puck.position.y < puckLimit.Bottom)
                {
                    if (isFirstTimeOnTheOtherSide)
                    {
                        isFirstTimeOnTheOtherSide = false;
                        offsetYFromTarget = Random.Range(-1f, 1f);
                    }

              //code for the next four lines is referenced from:
              //Rešetár, M. (2017). #7 Make an Air Hockey Game in Unity - WIN / LOSE (Code). [online] Reso Coder.
              //Available at: https://resocoder.com/2017/07/07/7-make-an-air-hockey-game-in-unity-win-loose-code/ [Accessed 3 May 2023].
                movingSpeed = AI_Speed * Random.Range(0.1f, 0.3f);
                    targetPosition = new Vector2 (Mathf.Clamp (Puck.position.x + offsetYFromTarget,
                                                  ai_Limit.AI_Side, ai_Limit.Player_Side), startPlace.y); 
                }

                 else
                 {
                   isFirstTimeOnTheOtherSide = true;

                 //the AI will move at this speed when its the puck's first time on the opponent's side
                   movingSpeed = Random.Range (AI_Speed * 0.4f, AI_Speed);
                   targetPosition = new Vector2 (Mathf.Clamp(Puck.position.x, ai_Limit.AI_Side,
                                                 ai_Limit.Player_Side), Mathf.Clamp(Puck.position.y,
                                                 ai_Limit.Bottom, ai_Limit.Top));
                 }

             //moves the AI towards the puck
               ai_rbody.MovePosition (Vector2.MoveTowards(ai_rbody.position, targetPosition,
                                      movingSpeed * Time.fixedDeltaTime));
          } 
    }

  //the AI paddle is returned to its starting position 
    public void ResetPosition()
    {
        ai_rbody.position = startPlace;
    }
}

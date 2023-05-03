using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  //states that the player has picked up the player paddle 
    bool wasPicked_up = true;

  //questions if the player can move
    bool able_to_Move;


  //the player's starting position and rigidbody are called as they are used in the code
    Rigidbody2D player_rbody;
    Vector2 startPlace;


  //the player's starting position and board limit are called as they are used in the code
    public Transform Limit;
    Limit playerLimit;


  //the player's collider is called as it is used in the code
    Collider2D playerCollider;

    void Start()
    {
      //the player's rigidbody and collider are activated
        player_rbody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();


      //the player's starting place is equated to its rigidbody position
        startPlace = player_rbody.position;



      //code for the next four lines is referenced from:
      //Rešetár, M. (2017). #7 Make an Air Hockey Game in Unity - WIN / LOSE (Code). [online] Reso Coder.
      //Available at: https://resocoder.com/2017/07/07/7-make-an-air-hockey-game-in-unity-win-loose-code/ [Accessed 3 May 2023].
      
      //the player's limits on the board are activated  
        playerLimit = new Limit (Limit.GetChild (0).position.y,
                                 Limit.GetChild (1).position.y,
                                 Limit.GetChild (2).position.x,
                                 Limit.GetChild (3).position.x);
    }

    void Update()
    {        
      //when the mouse is clicked, it checks if the player's paddle was picked up 
        if (Input.GetMouseButton(0)) 
        {  
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 

            if (wasPicked_up)
            {
                wasPicked_up = false;

              //if the mouse touches the player's colllider, the paddle can move
                if (playerCollider.OverlapPoint(mousePos)) 
                      {
                         able_to_Move = true;
                      }

                else
                {
                    able_to_Move = false;
                }
            }

          //the player can move any where on the board on their side
            if (able_to_Move)
            {
              //code for the first line bellow is referenced from:
              //Rešetár, M. (2017). #7 Make an Air Hockey Game in Unity - WIN / LOSE (Code). [online] Reso Coder.
              //Available at: https://resocoder.com/2017/07/07/7-make-an-air-hockey-game-in-unity-win-loose-code/ [Accessed 3 May 2023].
                Vector2 clampedMousePos = new Vector2 (Mathf.Clamp (mousePos.x, playerLimit.AI_Side,
                                                         playerLimit.Player_Side), Mathf.Clamp 
                                                        (mousePos.y,playerLimit.Bottom,
                                                         playerLimit.Top));

                //moves the player through the mouse position
                  player_rbody.MovePosition (clampedMousePos); 
            }
        }
            else
            {
                wasPicked_up = true;
            }
    }

  //the player's paddle is returned to its starting position 
    public void ResetPosition()
    {
        player_rbody.position = startPlace;
    }
}

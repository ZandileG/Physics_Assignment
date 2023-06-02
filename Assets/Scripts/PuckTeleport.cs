using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckTeleport : MonoBehaviour
{
   //the portals are used in the code
    public GameObject portal2;

    private GameObject puck;


   //the puck is the one object that gets affected
    void Start()
    {
        puck = GameObject.FindWithTag("Puck");
    }


  //when the puck collides with the portal collider, it will reappear out of the other one
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Puck")
        {
            puck.transform.position = new Vector2 (portal2.transform.position.x, portal2.transform.position.y);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  //this activates the "Play"button's functionality
    public void Play()
    {
    //when the player presses the "Play" button, the coundown will begin
      SceneManager.LoadScene("CountdownTimer");
    }

  //the game will end when the "Quit" button is pressed
    public void Quit()
    {
        Application.Quit();
    }
}

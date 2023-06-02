using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedMenuScreen : MonoBehaviour
{
   //the pause screen is called so that is referred to in the code
    public GameObject pausedMenuScreen;


   //used to question whether the screen is paused or not
    public static bool Paused;


  //the pause screen is deactivated until it is needed 
    void Start()
    {
        pausedMenuScreen.SetActive(false);
    }

    //when the space bar is pressed, the game will pause
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Paused)
            {
                Continue();
            }

            else
            {
                Freeze();
            }
        }
    }

  //the pause screen is activated after the space bar is pressed 
    public void Freeze()
    {
        pausedMenuScreen.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }

  //the pause screen is deactivated when the "Continue" button is pressed
    public void Continue()
    {
        pausedMenuScreen.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }

  //go back to the Main Menu when this button is pressed
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Air_HockeyMenu");
    }

  //the game will end when the "Quit" button is pressed
    public void Quit()
    {
        Application.Quit();
    }

}

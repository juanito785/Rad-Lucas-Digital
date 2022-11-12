using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public int gameStartScene = 1;
    public int gameInfoScene = 2;
    public int gameMenuScene = 0;

    public void StartGame()
    {
        SceneManager.LoadScene(gameStartScene);
    }

    public void Info()
    {
        SceneManager.LoadScene(gameInfoScene);
    }

    public void Menu()
    {
        SceneManager.LoadScene(gameMenuScene);
    }
    
    //public object Quit()
    //{
    //    Application.Quit;
    //}

}

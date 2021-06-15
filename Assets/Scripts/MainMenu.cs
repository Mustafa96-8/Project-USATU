using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class MainMenu : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("SnakeScene");
    }

    public void GameExit()
    {
        Application.Quit() ;
    }
}
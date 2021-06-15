using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Whall : MonoBehaviour
{
    public Snake mainSnake;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnakeHead"))
        {
            SceneManager.LoadScene("MainMenu");
        } 
    }
}

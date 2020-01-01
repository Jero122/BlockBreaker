using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex  > SceneManager.sceneCount)
        {
            SceneManager.LoadScene(0);
            FindObjectOfType<GameStatus>().ResetGame();
        } 
        else
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
    }

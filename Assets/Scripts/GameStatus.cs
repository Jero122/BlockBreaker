using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [SerializeField] int playerScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] public TimeManager timeManager;
    [SerializeField] public bool instantDestory;


    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        scoreText.SetText("Score: {0}", playerScore);
    }

     public void AddScore()
    {
        playerScore++;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}

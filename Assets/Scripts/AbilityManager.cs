using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    [SerializeField] TimeManager timeManager = null;
    [SerializeField] GameObject extraLife;
    [SerializeField] Ball ball;
    GameStatus gameStatus;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
    }

    public void HandleAbility(int abilityNumber)
    {
        if (abilityNumber == 1)
        {
            DoMultipleBalls();
        }
        else if (abilityNumber == 2) //Time based
        {
            DoSlowtime(abilityNumber);
        }
        else if (abilityNumber == 3) //Time based
        {
            DoInstantDestroy(abilityNumber);
        }
        else if (abilityNumber == 4)
        {
            DoExtraLife();
        }
    }
    public void EndAbility(int abilityNumber)
    {
        if (abilityNumber == 2)
        {
            EndSlowTime();
        }
        else if (abilityNumber ==3)
        {
            EndInstantDestory();
        }
    }

    void DoExtraLife()
    {
        extraLife.SetActive(true);

    }

    void DoMultipleBalls() //Spawns an additional Ball
    {
        Rigidbody2D ballRB = ball.GetComponent<Rigidbody2D>();
        Ball additionalBall = Instantiate(ball, ball.transform.position, Quaternion.identity);
        additionalBall.hasStarted = true;
        //additionalBall.GetComponent<Rigidbody2D>().velocity = new Vector2(ball.GetComponent<Rigidbody2D>().velocity.x * -1, ball.GetComponent<Rigidbody2D>().velocity.y);
    }
    void DoSlowtime(int abilityNumber) //Slows time (duh). Timer based
    {
        Time.timeScale = 0.5f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;

        Instantiate(timeManager, timeManager.transform.position, timeManager.transform.rotation);
        timeManager.targetTime = 10f;
        timeManager.abilityNumber = abilityNumber;
    }

    void DoInstantDestroy(int abilityNumber) //All active balls instantly destory destroyale blocks. Timer based
    {
        Ball[] Balls = FindObjectsOfType<Ball>();
        gameStatus.instantDestory = true;
        foreach (Ball ball in Balls)
        {
            ball.GetComponent<SpriteRenderer>().color = Color.red;
        }
        Instantiate(timeManager, timeManager.transform.position, timeManager.transform.rotation);
        timeManager.targetTime = 10f;
        timeManager.abilityNumber = abilityNumber;
    }


    void EndSlowTime()
    {
        Time.timeScale = 1;

    }
    void EndInstantDestory()
    {
        Ball[] Balls = FindObjectsOfType<Ball>();
        gameStatus.instantDestory = false;
        foreach (Ball ball in Balls)
        {
            ball.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}

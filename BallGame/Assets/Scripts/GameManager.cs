using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public static Action OnFinishBouncing;
    public static Action OnShowColorStarted;
    public static Action OnShowColorEnded;

    [Header("Time Variables")]
    [SerializeField] private float gameTime;
    [SerializeField] private float yellowDelayTime;

    public static bool canClick = false; //it's here for while the ball bouncing we can't touch it

    public static bool isItFinished;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        OnFinishBouncing += FreezeAllTheBalls; //OnFinishBouncing action freeze the balls at end of the game 
    }

    public void InitiateGameLogic()
    {
        StartCoroutine(GameTime(gameTime)); //calculating the game time
        StartCoroutine(ShowColorPhase(yellowDelayTime)); //target ball became yellow in given time
    }

    private void OnDisable()
    {
        OnFinishBouncing -= FreezeAllTheBalls;
    }

    IEnumerator GameTime(float gameTime)
    {
        yield return new WaitForSeconds(gameTime);

        //gameobjectleri alýp rigidBodylerini kapatmam gerek

        OnFinishBouncing?.Invoke(); //froze the balls 
    }

    private void FreezeAllTheBalls()
    {
        //canClick = true;

        isItFinished = true;

        //CheckForCollision(1f);
    }

    private void CheckForCollision(float range)
    {
        foreach (GameObject ball in BallManager.Instance.balls)
        {
            foreach (GameObject ballToCheckAgainst in BallManager.Instance.balls)
            {
                if (ball == ballToCheckAgainst)
                {
                    continue; //next step
                }

                Debug.Log("First Ball" + ball.transform.position);
                Debug.Log("Second Ball" + ballToCheckAgainst.transform.position);

                if (Vector2.Distance(ball.transform.position, ballToCheckAgainst.transform.position) < range)
                {                  
                    Debug.Log("Game Breaking Exception Succesfully Handled");
                    return;
                }
            }
        }
    }

    IEnumerator ShowColorPhase(float time)
    {   
        yield return new WaitForSeconds(time);

        OnShowColorStarted?.Invoke();

        yield return new WaitForSeconds(time);

        OnShowColorEnded?.Invoke();
    }    
}

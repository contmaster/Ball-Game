using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BallManager : MonoBehaviour
{
    public static BallManager Instance { get; private set; }

    public List<GameObject> balls = new List<GameObject>();
    public List<Vector2> finalPoints = new List<Vector2>();

    [SerializeField] private GameObject ballPrefab;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI winText;
    [SerializeField] private TextMeshProUGUI loseText;
    [SerializeField] private TextMeshProUGUI countdown;

    private int countdownTime = 3;
    public bool isCountdownFinished;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        balls.Capacity = PlayerPrefs.GetInt("Level", 0);

        StartCoroutine(CountDown());
    }

    public void SelectTheBall(GameObject selectedBall)
    {
        if (selectedBall.GetComponent<ChangeColor>().isYellow)
        {
            //UI iÞLEMLERÝ true
            Debug.Log("Sarý olana týklandý");
            selectedBall.GetComponent<SpriteRenderer>().color = Color.yellow;
            winText.gameObject.SetActive(true);
            loseText.gameObject.SetActive(false);
            GameManager.canClick = false;
            StartCoroutine(BackToTheMainMenu());
        }
        else
        {
            //UI ÝÞLEMLERÝ false
            Debug.Log("Yanlýþ Olana Týklandý");
            selectedBall.GetComponent<SpriteRenderer>().color = Color.red;
            loseText.gameObject.SetActive(true);
            winText.gameObject.SetActive(false);
            GameManager.canClick = false;
            StartCoroutine(BackToTheMainMenu());
        }
    }

    public IEnumerator CountDown()
    {
        while (countdownTime > 0)
        {
            countdown.gameObject.SetActive(true);
            countdown.text = countdownTime.ToString();
            yield return new WaitForSeconds(1);

            countdownTime--;
        }

        countdownTime = 3;
        countdown.gameObject.SetActive(false);
        isCountdownFinished = true;

        CreatingTheBalls();
        DetermineFinalPoints();
        GameManager.Instance.InitiateGameLogic();


    }

    private void DetermineFinalPoints()
    {
        for (int i = 0; i < balls.Capacity; i++)
        {
            if (i == 0)
            {
                finalPoints.Add(Vector2.zero);
                continue;
            }
            if (i % 2 == 0) //çift olduðu durum
            {
                Vector2 finalPoint = new Vector2(i / 2, 0);
                finalPoints.Add(finalPoint);
            }
            else           //tek olduðu durum
            {
                Vector2 finalPoint = new Vector2(-(i + 1) / 2, 0);
                finalPoints.Add(finalPoint);
            }
        }
    }

    private void CreatingTheBalls()
    {
        for (int i = 0; i < balls.Capacity; i++)
        {
            GameObject ball = Instantiate(ballPrefab);
            ball.GetComponent<Ball>().ID = i;
            balls.Add(ball);
        }

        int randomBall = Random.Range(0, balls.Capacity);
        balls[randomBall].GetComponent<ChangeColor>().isYellow = true;
    }

    IEnumerator BackToTheMainMenu()
    {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(0);
        GameManager.isItFinished = false;
    }
}

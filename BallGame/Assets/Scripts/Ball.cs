using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector2 finalPoint;
    static int finishedBallCount = 0;
    const float finalSpeedMultiplier = 0.1f;
    public int ID;

    private bool mussebbek;

    void Start()
    {
        finishedBallCount++;
        
        finalPoint = BallManager.Instance.finalPoints[ID];
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (GameManager.isItFinished)
        {
            LerpToFinalPoint();
        }
    }

    private void LerpToFinalPoint()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        float speed = rb.velocity.magnitude * finalSpeedMultiplier; //magnitude bileþke
        rb.constraints = RigidbodyConstraints2D.FreezePosition;

        StartCoroutine(LerpingTheBalls(speed));
    }

    IEnumerator LerpingTheBalls(float speed)
    {
        if (mussebbek)
        {
            yield break;
        }

        mussebbek = true;
        Debug.Log("Lerping");
        float t = 0;
        Vector2 startPosition = transform.position;

        while (t < 1)
        {
            yield return null;
            t += Time.deltaTime * speed;
            transform.position = Vector2.Lerp(startPosition, finalPoint, t);
        }

        finishedBallCount--;

        if (finishedBallCount == 0)
        {
            GameManager.canClick = true;
        }
    }
}

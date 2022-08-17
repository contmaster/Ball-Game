using UnityEngine;

public class FirstPosition : MonoBehaviour
{
    void Start()
    {
        float randomPosX = Random.Range(-8.25f, 8.25f);
        float randomPosY = Random.Range(3f, 4.5f);
        Vector2 startPosition = new Vector2(randomPosX, randomPosY);
        transform.position = startPosition;
    }
}

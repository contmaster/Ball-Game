using System.Collections.Generic;
using UnityEngine;

public class StartForce : MonoBehaviour
{   
    [Header("Variables")]
    [SerializeField] private Vector2 startForcePos;
    [SerializeField] private Vector2 startForceNeg;
    //[SerializeField] private Vector2 currentForce; //for spectating

    void Start()
    {
        StartForceSetting();
        EqualForceGenerator();

        #region Random Force
        //random generator for starting force
        //currentForce = GenerateStartForce();
        #endregion
    }

    private void StartForceSetting()
    {
        int level = PlayerPrefs.GetInt("Level");
        startForcePos = new Vector2(level + 5, level + 5);
        startForceNeg = new Vector2(-(level + 5), level + 5);

        if (level == 1)
        {
            startForcePos = new Vector2(level + 6, level + 6);
            startForceNeg = new Vector2(-(level + 6), level + 6);
        }
    }

    private void EqualForceGenerator()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        List<Vector2> forceList = new List<Vector2>();
        forceList.Add(startForceNeg);
        forceList.Add(startForcePos);

        int random = Random.Range(0, forceList.Count);

        if (random == 0)
        {
            rb.AddForce(forceList[0], ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(forceList[1], ForceMode2D.Impulse);
        }
    }

    private Vector2 GenerateRandomStartForce()
    {
        float randomX = Random.Range(-15f, 16);
        Vector2 randomStartForce = new Vector2(randomX, transform.position.y);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        rb.AddForce(randomStartForce, ForceMode2D.Impulse);

        return randomStartForce;
    }
}

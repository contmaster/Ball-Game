using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private float time;
    [HideInInspector]
    public bool isYellow = false;

    void Start()
    {
        GameManager.OnShowColorStarted += SetYellow;
        GameManager.OnShowColorEnded += SetDefault;
        //observe pattern
    }

    private void OnDisable()
    {
        GameManager.OnShowColorStarted -= SetYellow;
        GameManager.OnShowColorEnded -= SetDefault;
    }

    private void SetYellow()
    {
        if (isYellow)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.yellow; //it became yellow
        }
    }

    private void SetDefault()
    {
        if (isYellow)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.white;
        }
    }
}

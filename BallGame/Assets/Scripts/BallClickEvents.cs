using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallClickEvents : MonoBehaviour 
{
    //public UnityEvent onPointerDown; //it's here for we can put in it a public method

    public void OnMouseDown()
    {
        if (GameManager.canClick) //a static variable can called with its calls name
        {
            BallManager.Instance.SelectTheBall(gameObject);
            //onPointerDown?.Invoke(); //if it isn't null
        }
    }
}

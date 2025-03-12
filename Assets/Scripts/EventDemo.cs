using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventDemo : MonoBehaviour
{
    public RectTransform banba;

    public UnityEvent OnTimeUp;
    public float timerLenght = 2;
    public float t;

    private void Update()
    {
        t += Time.deltaTime;
        if (t > timerLenght)
        {
            OnTimeUp.Invoke();
            t = 0;
        }
        
        //if (t< timerLenght)
        //{
        //    t += Time.deltaTime;
        //}
        //else
        //{
        //    OnTimeUp.Invoke();
        //}
    }
    public void MouseOver()
    {
        Debug.Log("Mouse is Over");
        banba.localScale = Vector3.one * 1.2f;
    }

    public void MouseNotOver()
     {
        Debug.Log("Mouse is not Over");
        banba.localScale = Vector3.one;
    }
}

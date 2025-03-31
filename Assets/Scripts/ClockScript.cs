using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClockScript : MonoBehaviour
{
    public Transform hourHand;
    public Transform minuteHand;
    public float hourLenght = 5;

    public float t;
    public int hour = 0;

    public UnityEvent<int> OClock; //angle brackets the type of variable of argument that will be passed


    Coroutine clockRunning;
    IEnumerator handsMoving;
    // Start is called before the first frame update
    

    // Update is called once per frame
    //void Update()
    //{
    //    t += Time.deltaTime;

    //    if (t > hourLenght)
    //    {
    //        t = 0;
    //        OClock.Invoke();

    //        hour++;
    //        if (hour == 12)
    //        {
    //            hour = 0;
    //        }
    //    }
    //}

    private void Start()
    {
      
            clockRunning = StartCoroutine(ClockRun());
            //yield return null;
    
    }

    IEnumerator ClockRun()
    {
        hour = 0;
        while (true)
        {
            handsMoving = MoveHands(); //asign serperately to be able to stop it
            //must be IEnumerator before start
            yield return StartCoroutine(handsMoving);
            //yield return StartCoroutine(MoveHands()); (old code)
        }

    }

    IEnumerator MoveHands()
    {
        t = 0;
        while (t < hourLenght)
        {
            t += Time.deltaTime;
            minuteHand.Rotate(0, 0, -(360 / hourLenght) * Time.deltaTime);
            hourHand.Rotate(0, 0, -(30 / hourLenght) * Time.deltaTime);
            yield return null;
        }
        hour++;
        if ( hour>12)
        {
            hour = 1;
        }
        OClock.Invoke(hour);

    }

    public void StopClock()
    {
        if (clockRunning != null)
        {
            StopCoroutine(clockRunning);
            //dont reference, call the one that is started, use variable
        }

        if (handsMoving != null)
        {
            StopCoroutine(handsMoving);
        }
    }

 }

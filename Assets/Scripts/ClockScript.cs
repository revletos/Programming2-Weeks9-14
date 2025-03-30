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

    public UnityEvent OClock;
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
        while (true)
        {
            StartCoroutine(ClockRun());
            yield return null;
        }
    }

    IEnumerator ClockRun()
    {
        yield return StartCoroutine(MoveHands());
        yield return StartCoroutine(MoveHands());
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
        OClock.Invoke();
    }
}

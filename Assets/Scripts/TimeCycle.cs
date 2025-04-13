using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class TimeCycle : MonoBehaviour
{
    Slider slider;
    float t;
    public bool day = true;
    UnityEvent moving = new UnityEvent();
    public Slimemovement sm; 
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        moving.AddListener(sm.SlimeMoving);
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime * 0.1f;
        slider.value = t % slider.maxValue; 
        if (slider.value < 0.75)
        {
            moving.Invoke();

        }
        else
        {
 
        }
        Debug.Log(slider.value);    
        //Debug.Log(day);
    }
    
}

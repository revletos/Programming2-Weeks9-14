using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeCycle : MonoBehaviour
{
    Slider slider;
    float t;
    public bool day = true;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        slider.value = t % slider.maxValue; 
        if (slider.value >0.75)
        {
            day = false;
        }
        else
        {
            day = true;
        }
        Debug.Log(day);
    }
    
}

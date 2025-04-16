using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class TimeCycle : MonoBehaviour
{
    Slider slider;
    float t;
    //public bool day = true; No longer in use, only made code more complicated and served no tangible purpose that couldn't be accomplished without it
    UnityEvent moving = new UnityEvent(); //I'm pretty sure this isn't the right syntax but this was the only way it worked
    public Slimemovement sm; // Making script public so I can reference the method from there
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>(); //Hook up slider component to code
        moving.AddListener(sm.SlimeMoving); // Add listener to the event
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime * 0.1f;  // To slow down the timer (It was too fast and the movement as such was very jittery)
        slider.value = t % slider.maxValue; //Slider value is the t modulus of the maximum slider value
        if (slider.value < 0.75) // If the slider is less than 75% complete
        {
            moving.Invoke();  //run the movement method (Line 20, Slimemovement Script)

        }
        //else // probably unessecary, left over from previous logic that got scrapped
        //{
 
        //}
        //Debug.Log(slider.value);    //Remainder from bug testing
        //Debug.Log(day);
    }
    
}

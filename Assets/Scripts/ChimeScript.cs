using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimeScript : MonoBehaviour
{
    // Start is called before the first frame update
    public ClockScript clock;
    public AudioClip chime;

    AudioSource audioSource;
    void Start()
    {
        clock.OClock.AddListener(ChimeHour); //56:53 of video had error, I didn't. Oh okay that was expected. 
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChimeHour(int hour)
    {
        Debug.Log("ChimeHour: " + hour);
        StartCoroutine(HourChime(hour));
        //ChimeOnce();
    }

    public void ChimeOnce()
    {
        audioSource.PlayOneShot(chime);
    }

    IEnumerator HourChime(int hour)
    {
        while (hour > 0)
        {
            ChimeOnce();
            yield return new WaitForSeconds(chime.length);
            hour--;
        }
    }
        }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Slimemovement : MonoBehaviour
{
    public float speed = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void SlimeMoving() // Simple movement from Week 1, written as a method so it could be used as a event in another script 
    {
        Vector2 pos = transform.position; // declare pos as a Vector 2
        pos.x += speed * Time.deltaTime; // Position is increased by speed * Delta Time
        Vector2 slimemove = Camera.main.WorldToScreenPoint(pos); // declare slimemove as a Vector 2 in screenspace

        if (slimemove.x < 0 + 100 || slimemove.x > Screen.width - 100) // If the slime reaches the predetermined border, have it go in the opposite direction
        {
            speed = speed * -1; // Positive/Negative value determines change on x axis
        }
        transform.position = pos;
        //Debug.Log(slimemove.x); // Used for determining movement constraints
    }
}
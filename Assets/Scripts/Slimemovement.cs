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
     public void SlimeMoving()
    {
        Vector2 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        Vector2 slimemove = Camera.main.WorldToScreenPoint(pos);

        if (slimemove.x < 0 + 100 || slimemove.x > Screen.width - 100)
        {
            speed = speed * -1;
        }
        transform.position = pos;
        //Debug.Log(slimemove.x);
    }
}
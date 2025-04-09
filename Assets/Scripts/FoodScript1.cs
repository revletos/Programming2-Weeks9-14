using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using static Unity.Burst.Intrinsics.X86;

public class FoodScript1 : MonoBehaviour
{
    //public UnityEvent watermelonclick = new UnityEvent();
    public GameObject prefabtext;
    public SpriteRenderer sr;
    public SpriteRenderer slime;
    public Vector2 mouse;
    public bool lastTime = false;
    //public Color colourChange;
    bool mouseOver;
    float hue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(mouse);

        prefabtext.SetActive(sr.bounds.Contains(mouse));  //activate prefab when the mouse position is over the bounds of the sprite (and disable otherwise)
        if (sr.bounds.Contains(mouse) && Input.GetMouseButtonDown(0))
        {
            Debug.Log("a");
            //slime.transform.localScale = new Vector3(slime.transform.localScale.x*1.1f, slime.transform.localScale.y*1.1f, 2);
            //slime.transform.localScale = new Vector3(slime.transform.localScale.x * 0.9f, slime.transform.localScale.y * 0.9f, 2);
            //colourChange = new Color(0, 250, 0);
            //slime.color = colourChange;
            //hue = Random.Range(0f, 1f);
            //slime.color = Color.HSVToRGB(hue, 1, 1);
        }


    //    if (sr.bounds.Contains(mouse))
    //    {
    //        //if (lastTime == false)
    //        //{
    //            OverTarget();
    //            Debug.Log("over");
                
    //            //GameObject newText = Instantiate(prefabtext, mouse, Quaternion.identity);
    //        //}
    //    }
    //    else
    //    {

    //        ;//lastTime = false;
    //    }
    //    //lastTime = sr.bounds.Contains(mouse);
       
    //}

    //public void OverTarget()
    //{
    //    //GameObject newText = Instantiate(prefabtext, mouse, Quaternion.identity);
    //    prefabtext.SetActive(true);
        
    }

public void Watermelon()
    {
        Debug.Log("click");
        slime.transform.localScale = new Vector3(slime.transform.localScale.x*1.1f, slime.transform.localScale.y*1.1f, 2);
    }

public void Cupcake()
    {
        slime.transform.localScale = new Vector3(slime.transform.localScale.x * 0.9f, slime.transform.localScale.y * 0.9f, 2);
    }

public void Drink()
    {
        hue = Random.Range(0f, 1f);
        slime.color = Color.HSVToRGB(hue, 1, 1);
    }
}

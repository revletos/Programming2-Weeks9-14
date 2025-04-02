using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86;

public class FoodScript1 : MonoBehaviour
{
    public GameObject prefabtext;
    public SpriteRenderer sr;
    public Vector2 mouse;
    public bool lastTime = false;
    bool mouseOver;

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
}

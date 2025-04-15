using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using static Unity.Burst.Intrinsics.X86;

public class FoodScript1 : MonoBehaviour
{
    //public UnityEvent watermelonclick = new UnityEvent();
    public GameObject watermelonprefabtext;
    public GameObject cupcakeprefabtext;
    public GameObject teaprefabtext;
    public SpriteRenderer watermelon;
    public SpriteRenderer cupcake;
    public SpriteRenderer tea;
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
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition); // defines mouse variable as the player's mouse position
        //Debug.Log(mouse); // used to test for mouse position before Sprite Renderer bounds contains function was used 

        watermelonprefabtext.SetActive(watermelon.bounds.Contains(mouse));  //activate prefab when the mouse position is over the bounds of the sprite (and disable otherwise)
        cupcakeprefabtext.SetActive(cupcake.bounds.Contains(mouse));        //activate prefab when the mouse position is over the bounds of the sprite (and disable otherwise)
        teaprefabtext.SetActive(tea.bounds.Contains(mouse));        //activate prefab when the mouse position is over the bounds of the sprite (and disable otherwise)
        if (watermelon.bounds.Contains(mouse) && Input.GetMouseButtonDown(0))
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
        slime.transform.localScale = new Vector3(slime.transform.localScale.x*1.1f, slime.transform.localScale.y*1.1f, 2); // Increase the size of the slime by 110% its current size in both x and y scales
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

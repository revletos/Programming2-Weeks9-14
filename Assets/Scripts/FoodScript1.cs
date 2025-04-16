using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using static Unity.Burst.Intrinsics.X86;

public class FoodScript1 : MonoBehaviour
{
    //public UnityEvent watermelonclick = new UnityEvent();
    public GameObject watermelonprefabtext;
    public GameObject cupcakeprefabtext;
    public GameObject teaprefabtext;
    public GameObject watermelonindicator1;
    public GameObject watermelonindicator2;
    public GameObject cupcakeindicator1;
    public GameObject cupcakeindicator2;
    public GameObject cupcakeindicator3;
    public GameObject teaindicator1;
    public GameObject teaindicator2;
    public SpriteRenderer watermelon;
    public SpriteRenderer cupcake;
    public SpriteRenderer tea;
    public SpriteRenderer slime;
    public Vector2 mouse;
    public bool lastTime = false;
    public float t;

    Coroutine watermelonindicator;
    Coroutine cupcakeindicator;
    Coroutine teaindicator;
    //public Color colourChange;
    bool mouseOver;
    float hue;

    // Start is called before the first frame update
    void Start()
    {
        t = 0;
        watermelonindicator1.SetActive(false);
        watermelonindicator2.SetActive(false);
        cupcakeindicator1.SetActive(false);
        cupcakeindicator2.SetActive(false);
        cupcakeindicator3.SetActive(false);
        teaindicator1.SetActive(false);
        teaindicator2.SetActive(false);

    }

    // Update is called once per frame
    public void Update()
    {
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition); // defines mouse variable as the player's mouse position
        //Debug.Log(mouse); // used to test for mouse position before Sprite Renderer bounds contains function was used 

        watermelonprefabtext.SetActive(watermelon.bounds.Contains(mouse));  //activate prefab when the mouse position is over the bounds of the sprite (and disable otherwise)
        cupcakeprefabtext.SetActive(cupcake.bounds.Contains(mouse));        //activate prefab when the mouse position is over the bounds of the sprite (and disable otherwise)
        teaprefabtext.SetActive(tea.bounds.Contains(mouse));        //activate prefab when the mouse position is over the bounds of the sprite (and disable otherwise)

        if (watermelonindicator != null)
        {
            if (t <= 2) // if the value of t is less than 2
            {
                t = Time.deltaTime * 300; // increase t
                                          // yes, I know this looks atrocious. Page 6 of my implementation log explains the madness somewhat
                                          // I'm very out of it and the dirty fix did relatively what I needed it to. 
            }
            else
            {
                StopCoroutine(watermelonindicator);
                watermelonindicator1.SetActive(false);
                watermelonindicator2.SetActive(false);
                t = 0;
            }

        }

        if (cupcakeindicator != null) // same code just for the cupcake
                                      // don't see much logic is recommenting it
        {
            if (t <= 2)
            {
                t = Time.deltaTime * 300;
            }
            else
            {
                StopCoroutine(cupcakeindicator);
                cupcakeindicator1.SetActive(false);
                cupcakeindicator2.SetActive(false);
                cupcakeindicator3.SetActive(false);
                t = 0;
            }

        }

        if (teaindicator != null)     // same code just for the tea
                                      // don't see much logic is recommenting it
        {
            if (t <= 2)
            {
                t = Time.deltaTime * 300;
            }
            else
            {
                StopCoroutine(teaindicator);
                teaindicator1.SetActive(false);
                teaindicator2.SetActive(false);
                t = 0;
            }

        }


    }

    public void Watermelon()  //Watermelon event
    {
        slime.transform.localScale = new Vector3(slime.transform.localScale.x * 1.1f, slime.transform.localScale.y * 1.1f, 2); // Increase the size of the slime by 110% its current size in both x and y scales
        watermelonindicator = StartCoroutine(SpawnIndicatorWatermelon()); // Start the watermelon indicator coroutine (line 61)

    }

    public void Cupcake()
    {
        slime.transform.localScale = new Vector3(slime.transform.localScale.x * 0.9f, slime.transform.localScale.y * 0.9f, 2);
        cupcakeindicator = StartCoroutine(SpawnIndicatorCupcake()); // Start the cupcake indicator coroutine (line 61)
    }

    public void Drink()
    {
        hue = Random.Range(0f, 1f);
        slime.color = Color.HSVToRGB(hue, 1, 1);
        teaindicator = StartCoroutine(SpawnIndicatorTea());
    }

    IEnumerator SpawnIndicatorWatermelon()
    {
        watermelonindicator1.SetActive(true);
        watermelonindicator2.SetActive(true);
        yield return null;

    }

    IEnumerator SpawnIndicatorCupcake()
    {
        cupcakeindicator1.SetActive(true);
        cupcakeindicator2.SetActive(true);
        cupcakeindicator3.SetActive(true);
        yield return null;

    }

    IEnumerator SpawnIndicatorTea()
    {
        teaindicator1.SetActive(true);
        teaindicator2.SetActive(true);
        yield return null;
    }
}



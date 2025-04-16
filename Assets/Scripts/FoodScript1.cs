using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using static Unity.Burst.Intrinsics.X86;

public class FoodScript1 : MonoBehaviour
{
    public GameObject watermelonprefabtext; // Declare prefab text assets
    public GameObject cupcakeprefabtext;
    public GameObject teaprefabtext;
    public GameObject watermelonindicator1;  // Declare all indicators
    public GameObject watermelonindicator2;
    public GameObject cupcakeindicator1;
    public GameObject cupcakeindicator2;
    public GameObject cupcakeindicator3;
    public GameObject teaindicator1;
    public GameObject teaindicator2;
    public SpriteRenderer watermelon; //Make a call to the specific sprite for sprite render bounds contains functions
    public SpriteRenderer cupcake;
    public SpriteRenderer tea;
    public SpriteRenderer slime;
    public Vector2 mouse;           // Declare mouse as a vector 2
    public float hold = 350; // Made it a public variable so I could adjust all 3 and test in inspector
    //public bool lastTime = false;
    public float t;

    Coroutine watermelonindicator; // Declare coroutines
    Coroutine cupcakeindicator;
    Coroutine teaindicator;
    //public Color colourChange;
    //bool mouseOver;
    float hue;                   // Declare hue as a float variables

    // Start is called before the first frame update
    void Start()
    {
        t = 0;                                      // Set the t value to be 0 at start
        watermelonindicator1.SetActive(false);      //Set all indicators to be hidden at start
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
                t = Time.deltaTime * hold; // increase t
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
                t = Time.deltaTime * hold;
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
                t = Time.deltaTime * hold;
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
        slime.transform.localScale = new Vector3(slime.transform.localScale.x * 0.9f, slime.transform.localScale.y * 0.9f, 2);// Decrease the size of the slime by 90% its current size in both x and y scales
        cupcakeindicator = StartCoroutine(SpawnIndicatorCupcake()); // Start the cupcake indicator coroutine (line 79)
    }

    public void Drink()
    {
        hue = Random.Range(0f, 1f); // Set boundary of the random range to hue's possible range (see implementation log for more explanation)
        slime.color = Color.HSVToRGB(hue, 1, 1); // Change slime colour to random hue with maximum saturation and brightness. Referenced code from unity forums (link in implementation log)
        teaindicator = StartCoroutine(SpawnIndicatorTea()); // Start the tea inidicator coroutine (line 97)
    }

    IEnumerator SpawnIndicatorWatermelon() // Coroutine to spawn watermelon inidcators 
                                           // In hindsight, the coroutine might have been better elsewhere. :p
    {
        watermelonindicator1.SetActive(true);//Turn on sprite
        watermelonindicator2.SetActive(true);
        yield return null;                   //Manadatory yield return, and nothing needs to get returned

    }

    IEnumerator SpawnIndicatorCupcake()     // Same logic as above
    {
        cupcakeindicator1.SetActive(true);
        cupcakeindicator2.SetActive(true);
        cupcakeindicator3.SetActive(true);
        yield return null;                   //Manadatory yield return, and nothing needs to get returned

    }

    IEnumerator SpawnIndicatorTea()         //Same logic as above
    {
        teaindicator1.SetActive(true);
        teaindicator2.SetActive(true);
        yield return null;                   //Manadatory yield return, and nothing needs to get returned
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlimeListener : MonoBehaviour
{
    UnityEvent watermelonclick = new UnityEvent(); //I'm pretty sure this isn't the right syntax but this was the only way it worked
    UnityEvent cupcakeclick = new UnityEvent();
    UnityEvent teaclick = new UnityEvent();
    public FoodScript1 fs1;               // Making script public so I can reference the method from there      
    public SpriteRenderer watermelonsprite; //Make a call to the specific sprite for sprite render bounds contains functions
    public SpriteRenderer cupcakesprite;
    public SpriteRenderer teasprite;
    public Vector2 mouse;                   // Declare mouse as a vector 2
    // Start is called before the first frame update
    void Start()
    {
        watermelonclick.AddListener(fs1.Watermelon); // Add Listeners for all events
        cupcakeclick.AddListener(fs1.Cupcake);
        teaclick.AddListener(fs1.Drink);
    }

    // Update is called once per frame
    void Update()
    {
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition); // defines mouse variable as the player's mouse position
        if (watermelonsprite.bounds.Contains(mouse) && Input.GetMouseButtonDown(0)) // if the mouse is over the watermelon AND the left mouse button is pressed
        {
            watermelonclick.Invoke(); // run the code for the watermelon event
        }
        if (cupcakesprite.bounds.Contains(mouse) && Input.GetMouseButtonDown(0)) // if the mouse is over the cupcake AND the left mouse button is pressed
        {
            cupcakeclick.Invoke(); // run the code for the cupcake event
        }
        if (teasprite.bounds.Contains(mouse) && Input.GetMouseButtonDown(0)) // if the mouse is over the tea AND the left mouse button is pressed
        {
            teaclick.Invoke(); // run the code for the tea event
        }
    }
}

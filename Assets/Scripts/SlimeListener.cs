using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlimeListener : MonoBehaviour
{
    UnityEvent watermelonclick = new UnityEvent();
    public FoodScript1 fs1;
    public SpriteRenderer watermelonsprite;
    public Vector2 mouse;
    // Start is called before the first frame update
    void Start()
    {
        watermelonclick.AddListener(fs1.Watermelon);
    }

    // Update is called once per frame
    void Update()
    {
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (watermelonsprite.bounds.Contains(mouse) && Input.GetMouseButtonDown(0))
        {
            Debug.Log("bb");
            watermelonclick.Invoke();
        }
        }
}

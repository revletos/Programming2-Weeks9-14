using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointerEvents : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;
    public GameObject prefab;
    public Transform parent;
    int randomw = Random.Range(0, Screen.width);
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void MouseEnter()
    {
       
    }
    
    public void MouseExit()
    {

    }

    public void MouseClick()
    {
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Instantiate(prefab, mouse, Quaternion.identity);
        GameObject spawned = Instantiate(prefab, parent);
        //Vector2 spawnpos = spawned.transform.position 

    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CoroutineGrower : MonoBehaviour
{
    public AnimationCurve curve;
    public float minSize = 0;
    public float maxSize = 1;
    public float t;
    public Transform apple;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGrowing()
    {
        StartCoroutine(Grow());
        Debug.Log("yes");
    }

    public IEnumerator Grow()
    {
        //hide until they grow 
        apple.localScale = Vector3.zero;

        //grow the tree
        t = 0;
        while(t<1)
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.one * maxSize * curve.Evaluate(t);
            yield return null;
        }

        yield return new WaitForSeconds(2);

        // grow the apple
        t = 0;
        while (t<1)
        {
            t += Time.deltaTime;
            apple.localScale = Vector3.one * maxSize * curve.Evaluate(t);
            yield return null;
        }
    }
}

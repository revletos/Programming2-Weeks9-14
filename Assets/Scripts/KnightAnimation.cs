using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAnimation : MonoBehaviour
{

    Animator animator;
    SpriteRenderer sr;
    public float speed = 2;
    public bool canRun = true;
    public bool jumping = false;
    public AnimationCurve jumpcurve;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxis("Horizontal");
        sr.flipX = (direction < 0);
        animator.SetFloat("speed", Mathf.Abs(direction));

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("attack");
            canRun = false;
        }

        if (canRun == true)
        {
            transform.position += transform.right * direction * speed * Time.deltaTime;
        }
           
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("jump", true);
            if (jumping == true)
            {

            }
        }
    }

    public void AttackEnd()
    {
        Debug.Log("ready to run");
        canRun = true;
    }
}

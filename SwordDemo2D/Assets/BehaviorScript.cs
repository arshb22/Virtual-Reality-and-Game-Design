using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorScript : MonoBehaviour
{

    Animator animator;
    private Rigidbody2D rb2d;
    bool flip;
    Vector3 scale;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        flip = false;
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //From Idle to Attack
        if(Input.GetKeyDown("space"))
        { 
           animator.SetTrigger("Attack");
        }
        if(Input.GetKeyUp("space"))
        {
            animator.SetTrigger("UnAttack");
        }
        
        //From Any State to Run
        if(Input.GetKeyDown(KeyCode.R))
        {
            animator.SetTrigger("StartRun");
        }
        if(Input.GetKeyUp(KeyCode.R))
        {
            animator.SetTrigger("When");
        }
        */

        //Stuff
        if (Input.GetKey(KeyCode.Space))
        {
            //animator.SetTrigger("attack1");
            animator.SetBool("attack", true);
        }
        
        else
        {
            //animator.SetTrigger("attack1");
            animator.SetBool("attack", false);
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (flip == true)
            {
                scale.x *= -1;
                transform.localScale = scale;
                flip = false;
            }
            animator.SetBool("run", true);
            transform.Translate(Vector2.left * 0.01f, Space.World);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (flip == false)
            {
                scale.x *= -1;
                transform.localScale = scale;
                flip = true;
            }
            animator.SetBool("run", true);
            transform.Translate(Vector2.right * 0.01f, Space.World);
            transform.eulerAngles = new Vector3(0, 0, 0);

        }
        else
            animator.SetBool("run", false);
    }
}

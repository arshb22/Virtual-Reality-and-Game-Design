using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    float forceAmount = 2.0f;
    //public Vector3 jump;
    public float jumpForce = 0.0001f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("T " + transform.forward);
        //Debug.Log("V " + Vector3.forward);
        //var num = Input.GetAxis("Horizontal");
        //Debug.Log(num);

    }

    void FixedUpdate()
    {
        //rb.AddForce(transform.forward);
        //rb.AddForce(Vector3.forward);
        //rb.AddForce(Vector3.forward, ForceMode.Impulse);
        if(Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
        }
        //for the keyCode, if you only want it to go up when you press you have to use something else different than getKey
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsScript : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb.transform.Rotate(0, 2, 0);
        //rb.AddForceAtPosition(Vector3.back * Time.deltaTime * 6, Vector3.zero, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        rb.AddForceAtPosition(Vector3.back * Time.deltaTime * 6, Vector3.zero, ForceMode.Impulse);
    }

    /*
    void ApplyForce(Rigidbody body)
    {
        Vector3 direction = body.transform.position - transform.position;
        body.AddForceAtPosition(direction.normalized, transform.position);
    }
    */
}

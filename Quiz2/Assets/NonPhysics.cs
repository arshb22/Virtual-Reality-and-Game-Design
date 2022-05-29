using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPhysics : MonoBehaviour
{
    // Start is called before the first frame update
    //Rigidbody rb;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * 2, Space.World);
        //transform.Translate(0.0,Time.deltaTime * 6, );
        transform.Rotate(0,2,0);
    }
}

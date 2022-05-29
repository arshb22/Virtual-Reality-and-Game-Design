using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCannon : MonoBehaviour
{
    Vector3 center;
    // Start is called before the first frame update
    void Start()
    {
        center = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(center, new Vector3(0,-1,0), 100*Time.deltaTime);
            //transform.Rotate(new Vector3(0, -1, 0), Space.World);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(center, new Vector3(0, 1, 0), 100 * Time.deltaTime);
            //transform.Rotate(new Vector3(0, 1, 0), Space.World);
        }

        if(Input.GetKey(KeyCode.W))
        {
            transform.RotateAround(center, new Vector3(1, 0, 0), 100 * Time.deltaTime);
           // transform.Rotate(new Vector3(1, 0, 0), Space.Self);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.RotateAround(center, new Vector3(-1,0, 0), 100 * Time.deltaTime);
            //transform.Rotate(new Vector3(-1, 0, 0), Space.Self);
        }
    }
}

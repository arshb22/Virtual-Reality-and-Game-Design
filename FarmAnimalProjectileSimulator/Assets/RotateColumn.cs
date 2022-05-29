using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateColumn : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //left
        if(Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(new Vector3(0, 1, 0), Vector3.forward, 20 * Time.deltaTime);
        }
        //right
        if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(new Vector3(0, 1, 0), Vector3.back, 20 * Time.deltaTime);
        }
    }
}

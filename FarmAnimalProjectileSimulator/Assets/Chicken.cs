using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject chickenObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 spawn = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            GameObject clone = Instantiate(chickenObject, transform.position, transform.rotation) as GameObject;
            clone.transform.localScale += new Vector3(1f, 1f, 1f);
            clone.GetComponent<Rigidbody>().AddForce(transform.forward * 50.0f, ForceMode.Impulse);
        }
    }
}

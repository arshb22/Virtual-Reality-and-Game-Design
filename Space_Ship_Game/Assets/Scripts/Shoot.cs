using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject missile;
    public bool hellothere;
    public GameObject barrel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && hellothere == false)
        {
            GameObject a = Instantiate(missile, barrel.transform.position, transform.rotation) as GameObject;
            Rigidbody rb = a.GetComponent<Rigidbody>();
            a.GetComponent<Rigidbody>().AddForce(transform.forward * 2000);
            hellothere = true;
            StartCoroutine(hello1());
            Destroy(a, 2f);
        }
    }

    IEnumerator hello1()
    {
        yield return new WaitForSeconds(0.25f);
        hellothere = false;
    }
}

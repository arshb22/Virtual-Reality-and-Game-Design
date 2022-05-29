using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirenLights : MonoBehaviour
{
    public Light red;
    public Light blue;

    public float minFlickerSpeed = 0.1f;
    public float maxFlickerSpeed = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            red.GetComponent<Light>().enabled = false;
            blue.GetComponent<Light>().enabled = false;
        }
        else
            StartCoroutine(LightFlicker());
    }
    
    // Update is called once per frame
    IEnumerator LightFlicker()
    {
        red.enabled = true;
        yield return new WaitForSeconds(Random.Range(minFlickerSpeed, maxFlickerSpeed));
        red.enabled = false;
        yield return new WaitForSeconds(Random.Range(minFlickerSpeed, maxFlickerSpeed));

        blue.enabled = true;
        yield return new WaitForSeconds(Random.Range(minFlickerSpeed, maxFlickerSpeed));
        blue.enabled = false;
        yield return new WaitForSeconds(Random.Range(minFlickerSpeed, maxFlickerSpeed));
    }
}

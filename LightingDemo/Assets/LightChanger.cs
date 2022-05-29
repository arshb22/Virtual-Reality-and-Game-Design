using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChanger : MonoBehaviour
{

    public Light l;
    public float counter;

    // Start is called before the first frame update
    void Start()
    {
        l = GetComponent<Light>();
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        counter += 0.001f;
        l.color = Color.Lerp(Color.blue, Color.red, counter);
        if (counter >= 1)
            counter = 0;
        */
        counter += Time.deltaTime;
        float unitCircle = Mathf.Sin(counter);
        //add debugs
        Debug.Log(unitCircle);
        if(unitCircle < 0)
        {
            unitCircle = Mathf.Abs(unitCircle);
        }
        l.color = Color.Lerp(Color.blue, Color.red, unitCircle);
    }
}

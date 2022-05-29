using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFlip : MonoBehaviour
{
    //Attach this script to the camera
    //This script will rotate the camera so that it move from top view to bottom view
    private Quaternion currentRotation;
    private Quaternion leftFinalRotation = Quaternion.Euler(0, 0, 180);
    private Quaternion rightFinalRotation = Quaternion.Euler(0, 0, -180);
    private Quaternion normalRotation = Quaternion.Euler(0, 0, 0);
    private bool oneOrAnother = false;
    private IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {
        currentRotation = normalRotation;
    }

    // Update is called once per frame
    void Update()
    {
        //Case 1
        if (Input.GetKeyDown(KeyCode.Space) && !(oneOrAnother)) //When space key is pressed down [once]; changes from blue bottom to blue top
        {
            currentRotation = leftFinalRotation;
            coroutine = changeCase();
            StartCoroutine(coroutine);
        }

        
        //Case 2
        if (Input.GetKeyDown(KeyCode.Space) && oneOrAnother) //When space key is pressed down [once]; changes from blue top to blue bottom
        {
            currentRotation = normalRotation;
            coroutine = changeCase();
            StartCoroutine(coroutine);
        }

        //Debug.Log(oneOrAnother);
        

        //Makes it so that rotation appears slowly
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, currentRotation, 0.02f);
    }

    //Trying to use a coroutine so it can differentiate between which way to move
    //Consider that maybe the yield return new could've worked without the coroutine
    //You also need to press pretty hard for it to actual change
    IEnumerator changeCase()
    {
        yield return new WaitForSeconds(0.1f);
        oneOrAnother = !oneOrAnother;
    }
}

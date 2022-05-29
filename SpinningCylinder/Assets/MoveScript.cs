using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    //Extdend the pegs [to make room for more than one player]
    //Make it end up not going as fast [it has to be realistic]
    //Add invisible gameobjects [turn off the mesh renderer]
    //Remake wheel so the obstacles are equally spaced and you can create a pseudo circle


    float currentSpeed = 0.05f;
    float maxSpeed = 0.1f;
    // New variables :
    public float accelerationTime = 15;
    private float minSpeed;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        minSpeed = currentSpeed;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = Mathf.SmoothStep(minSpeed, maxSpeed, time / accelerationTime);
        time += Time.deltaTime;
        transform.RotateAround(transform.position, Vector3.up, currentSpeed);
        //Debug.Log("Time: " + time);
        //Debug.Log("Speed: " + currentSpeed);
    }
}

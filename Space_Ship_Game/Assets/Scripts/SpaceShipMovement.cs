using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipMovement : MonoBehaviour
{
    private float speed = 60;
    private float degreeStep = 90f;
    private Quaternion rightTarget = Quaternion.Euler(0, 0, -45);
    private Quaternion leftTarget = Quaternion.Euler(0, 0, 45);
    private Quaternion zeroTarget = Quaternion.Euler(0, 0, 0);
    private Quaternion current;

    // Start is called before the first frame update
    void Start()
    {
        current = zeroTarget;
}

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -80, 80), 0, Mathf.Clamp(transform.position.z, -44, 44));

        // Left Arrow
        if (Input.GetKeyDown(KeyCode.LeftArrow)) // key down left
        {
            current = leftTarget;

        }
        if (Input.GetKey(KeyCode.LeftArrow)) // key pressed left
        {
            current = leftTarget;
            transform.Translate(Vector3.left * Time.deltaTime * speed, relativeTo: Space.World);            
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))// key up left
        {
            current = zeroTarget;
        }

        //Down Arrow
        if (Input.GetKey(KeyCode.DownArrow) && transform.position.z > -44)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed, relativeTo: Space.World);
        }

        // Up Arrow
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.z < 44)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed, relativeTo: Space.World);
        }


        //Right Arrow
        if (Input.GetKeyDown(KeyCode.RightArrow)) // key down right
        {
            current = rightTarget;
        }
        if (Input.GetKey(KeyCode.RightArrow)) // key pressed right
        {
            current = rightTarget;
            transform.Translate(Vector3.right * Time.deltaTime * speed, relativeTo: Space.World);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow)) // key up right
        {
            current = zeroTarget;
        }

        Debug.Log(current.eulerAngles+" "+transform.position.x);

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, current, 0.02f);
    }
}

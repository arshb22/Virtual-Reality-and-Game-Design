using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipMovement : MonoBehaviour
{
    private float speedOfShip = 70;
    private Quaternion currentRotation;
    private Quaternion leftFinalRotation = Quaternion.Euler(0, 0, 45);
    private Quaternion rightFinalRotation = Quaternion.Euler(0, 0, -45);
    private Quaternion normalRotation = Quaternion.Euler(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        currentRotation = normalRotation;
    }

    // Update is called once per frame
    void Update()
    {
        //Left
        if (Input.GetKey(KeyCode.A) && transform.position.x>-140) //While left key is pressed, it sets rotation to final and moves it
        {
            currentRotation = leftFinalRotation;
            transform.Translate(Vector3.left * Time.deltaTime * speedOfShip, relativeTo: Space.World);
        }
        if (Input.GetKeyUp(KeyCode.A)) //When left key is let go, the rotation returns to normal
        {
            currentRotation = normalRotation;
        }

        //Right
        if (Input.GetKey(KeyCode.D) && transform.position.x<140) //While right key is pressed, it sets rotation to final and moves it
        {
            currentRotation = rightFinalRotation;
            transform.Translate(Vector3.right * Time.deltaTime * speedOfShip, relativeTo: Space.World);
        }
        if (Input.GetKeyUp(KeyCode.D)) //When right key is let go, the rotation returns to normal
        {
            currentRotation = normalRotation;
        }

        //Makes it so that rotation appears slowly
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, currentRotation, 0.1f);
    }
}

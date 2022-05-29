using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    public GameObject frontRight;
    public GameObject frontLeft;
    public GameObject backRight;
    public GameObject backLeft;

    public float acceleration = 5f;
    public float breakingForce = 5f;

    private float currentAcceleration = 0f;
    private float currentBreakForce = 0f;

    private Quaternion currentRotation;
    private Quaternion leftFinalRotation;
    private Quaternion rightFinalRotation;
    private Quaternion normalRotation = Quaternion.Euler(0, 0, 0);


    public GameObject BackLeft;
    public GameObject BackRight;

    public GameObject BackLeftTurnSignal;
    public GameObject BackRightTurnSignal;

    public float period = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        leftFinalRotation = Quaternion.Euler(0, transform.rotation.y + 90, 0);
        rightFinalRotation = Quaternion.Euler(0, transform.rotation.y - 90, 0);

        BackLeft.GetComponent<Light>().enabled = false;
        BackRight.GetComponent<Light>().enabled = false;

        BackLeftTurnSignal.GetComponent<Light>().enabled = false;
        BackRightTurnSignal.GetComponent<Light>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (period > 0.3f)
            {
                BackLeftTurnSignal.GetComponent<Light>().enabled = true;
                BackLeftTurnSignal.GetComponent<Renderer>().material.color = Color.yellow;
                period = 0;
            }
            period += UnityEngine.Time.deltaTime;
        }
        else
        {
            BackLeftTurnSignal.GetComponent<Light>().enabled = false;
            BackLeftTurnSignal.GetComponent<Renderer>().material.color = Color.grey;
        }
        if (Input.GetKey(KeyCode.R))
        {
            if (period > 0.3f)
            {
                BackRightTurnSignal.GetComponent<Light>().enabled = true;
                BackRightTurnSignal.GetComponent<Renderer>().material.color = Color.yellow;
                period = 0;
            }
            period += UnityEngine.Time.deltaTime;
        }
        else
        {
            BackRightTurnSignal.GetComponent<Light>().enabled = false;
            BackRightTurnSignal.GetComponent<Renderer>().material.color = Color.grey;
        }
    }

    private void FixedUpdate()
    {
        currentAcceleration = acceleration * Input.GetAxis("Vertical");
        Debug.Log(currentAcceleration);

        if (Input.GetKey(KeyCode.Space))
        {
            currentBreakForce = breakingForce;
            BackLeft.GetComponent<Light>().enabled = true;
            BackRight.GetComponent<Light>().enabled = true;
        }
        else
        {
            currentBreakForce = 0f;
            BackLeft.GetComponent<Light>().enabled = false;
            BackRight.GetComponent<Light>().enabled = false;
        }

        frontRight.GetComponent<WheelCollider>().motorTorque = currentAcceleration;
        frontLeft.GetComponent<WheelCollider>().motorTorque = currentAcceleration;

        frontRight.GetComponent<WheelCollider>().brakeTorque = currentBreakForce;
        frontLeft.GetComponent<WheelCollider>().brakeTorque = currentBreakForce;
        backRight.GetComponent<WheelCollider>().brakeTorque = currentBreakForce;
        backLeft.GetComponent<WheelCollider>().brakeTorque = currentBreakForce;

        //currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        //frontLeft.GetComponent<WheelCollider>().steerAngle = currentTurnAngle;
        //frontRight.GetComponent<WheelCollider>().steerAngle = currentTurnAngle;

            //transform.rotation = Quaternion.Slerp(Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, currentTurnAngle, 0), 30f);

        //Left
        if (Input.GetKey(KeyCode.A)) //While left key is pressed, it sets rotation to final and moves it
        {
            currentRotation = leftFinalRotation;     
        }
        if (Input.GetKeyUp(KeyCode.A)) //When left key is let go, the rotation returns to normal
        {
            leftFinalRotation = Quaternion.Euler(0, transform.rotation.y + 90, 0);
            rightFinalRotation = Quaternion.Euler(0, transform.rotation.y - 90, 0);
            currentRotation = this.transform.rotation;
        }

        //Right
        if (Input.GetKey(KeyCode.D)) //While right key is pressed, it sets rotation to final and moves it
        {
            currentRotation = rightFinalRotation;
        }
        if (Input.GetKeyUp(KeyCode.D)) //When right key is let go, the rotation returns to normal
        {
            leftFinalRotation = Quaternion.Euler(0, transform.rotation.y + 90, 0);
            rightFinalRotation = Quaternion.Euler(0, transform.rotation.y - 90, 0);
            currentRotation = this.transform.rotation;
        }

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, currentRotation, 0.005f);

    }
}

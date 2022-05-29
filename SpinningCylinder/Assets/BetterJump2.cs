using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BetterJump2 : MonoBehaviour
{
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2.5f;
    public float timeJump = 0.3f;
    private float time;

    public Rigidbody rb;

    //Notes:
    //Ducking Works
    //Hit detection works
    //Small errors with the course cause some parts to be unplayable
    //Extend obstacles and add second player + music
    //Does it move back when it gets hit?
    //FREEZING ROTATION CAUSES COLLIDERS TO NOT WORK
    //Maybe make it so that it can only move on a circular path so it can move forward and backward; and not side to side

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Speed: " + rb.velocity);
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        fallMultiplier = fallMultiplier * 1.0005f;
        lowJumpMultiplier = lowJumpMultiplier * 1.000005f;
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.J))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            //Debug.Log("We Jumped");
        }
        if (Input.GetKeyDown(KeyCode.J) && transform.position.y > 4.0f && transform.position.y < 4.1f && (!(Input.GetKey(KeyCode.P))))
        {
            rb.velocity += Vector3.up * 10;
            //Debug.Log("We Jumped");
        }

        if (Input.GetKey(KeyCode.P))
        {
            transform.localScale = new Vector3(0.5f, 2.0f, 0.5f);
        }
        if (!(Input.GetKey(KeyCode.P)))
        {
            transform.localScale = new Vector3(0.5f, 8.0f, 0.5f);
        }
    }

    void FixedUpdate()
    {
        //time += Time.deltaTime;
        //try to set transform.position so it become circular [or only moves in some spots]
        //transform.position = new Vector3(Mathf.Cos(time) * 30.0f, 1, Mathf.Sin(time)*30.0f);
        //You have the circular equation; now try to make it follow that path
        //if it's hitting something make it move back using the equation; try to get it to have the same velocity as the obstacle during that moment
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        if (transform.position.y < 1.0f && (Input.GetKey(KeyCode.P)))
        {
            transform.position = new Vector3(transform.position.x, 1.0f, transform.position.z);
        }
        if (transform.position.y < 4.0f && !(Input.GetKey(KeyCode.P)))
        {
            transform.position = new Vector3(transform.position.x, 4.0f, transform.position.z);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        //Debug.Log("You have been hit!");
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("You have been hit!");
        }
        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("done");
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("You have been hit!");
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("You have been hit!");
        }
        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("done");
        }
    }
    void OnCollisionExit(Collision collision)
    {
        //Debug.Log("You have been hit!");
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("You have been hit!");
        }
        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("done");
        }
    }
}

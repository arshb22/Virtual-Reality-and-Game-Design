using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject diamondObject;
    private float time = 3f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) && transform.position.z<5)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 20);
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x >-5)
        {
            transform.Translate(Vector3.left * Time.deltaTime * 20);
        }
        if (Input.GetKey(KeyCode.S) && transform.position.z > -5)
        {
            transform.Translate(Vector3.back * Time.deltaTime * 20);
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < 5)
        {
            transform.Translate(Vector3.right * Time.deltaTime * 20);
        }
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime;

        if (time >= 3)
        {
            time = 0.0f;
            System.Random random = new System.Random();
            int x = random.Next(-12, 12);
            int y = random.Next(-12, 12);
            Vector3 spawn = new Vector3(x, 20, y);
            GameObject clone = Instantiate(diamondObject, spawn, transform.rotation) as GameObject;
            clone.transform.localScale += new Vector3(1f, 1f, 1f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Hexagon")
        {
            ParticleSystem emit = gameObject.GetComponent<ParticleSystem>();
            emit.transform.parent = null;
            float totalDuration = 3.0f;
            emit.Stop();
            collision.gameObject.GetComponent<Renderer>().enabled = false;
            Destroy(collision.gameObject, totalDuration);
        }
    }
}

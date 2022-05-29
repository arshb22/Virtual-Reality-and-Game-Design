using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject diamondObject;
    float spawntime;
    int score = 0;
    public Text scoreText;
    public Text EndText;
    public ParticleSystem PS;
    public GameObject clone;

    void Start()
    {
        spawntime = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && transform.position.z < 5 && score < 10)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 20);
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x > -5 && score < 10)
        {
            transform.Translate(Vector3.left * Time.deltaTime * 20);
        }
        if (Input.GetKey(KeyCode.S) && transform.position.z > -5 && score < 10)
        {
            transform.Translate(Vector3.back * Time.deltaTime * 20);
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < 5 && score < 10)
        {
            transform.Translate(Vector3.right * Time.deltaTime * 20);
        }

        if(clone != null)
        {
            PS.transform.position = clone.transform.position;
        }
        else
        {
            PS.Stop();
        }
    }

    void FixedUpdate()
    {
        spawntime += Time.deltaTime;
        if (spawntime >= 5)
        {
            spawntime = 0.0f;
            System.Random random = new System.Random();
            Vector3 spawn = new Vector3(random.Next(-10, 10), 40, random.Next(-10, 10));
            clone = Instantiate(diamondObject, spawn, transform.rotation) as GameObject;
            clone.transform.localScale += new Vector3(1f, 1f, 1f);
            PS.Play();
        }
        if(score == 10)
        {
            //UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }

    void OnCollisionEnter(Collision c)
    {
        if(c.gameObject.name == "Diamondo(Clone)")
        {
            Debug.Log("Collision");
            //ParticleSystem emit = c.gameObject.GetComponent<ParticleSystem>();
            //emit.emissionRate = 0;
            //emit.Stop();
            PS.Stop();
            //emit.transform.parent = null;
            c.gameObject.GetComponent<Renderer>().enabled = false;
            Destroy(c.gameObject);
            
            score++;
            scoreText.text = "Score: " + score;
        }
    }
}

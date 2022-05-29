using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipExplosion : MonoBehaviour
{
    public GameObject particles;
    public GameObject a;

    public int maxHealth = 100;
    public int currentHealth;
    private int counter = 5;
    public float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(counter==0)
        {
            time += Time.deltaTime;
            if (time > 1)
            {
                SceneManager.LoadScene("StartScene");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            Debug.Log("fortnite");
            TakeDamage(20);
            Destroy(other.gameObject);
            Vector3 position = other.gameObject.transform.position;
            a = Instantiate(particles, position, transform.rotation) as GameObject;
            a.gameObject.GetComponent<ParticleSystem>().Play();
            Destroy(a, 2f);
        }
        /*
        if (other.gameObject.tag == "enemy")
        {
            Destroy(other.gameObject);
            Vector3 position = other.gameObject.transform.position;
            //a = Instantiate(particles, position, transform.rotation) as GameObject;
            //a.gameObject.GetComponent<ParticleSystem>().Play();
            //Destroy(a, 2f);

        }
        */
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        GameObject.Find("Health Controller").SendMessage("SetHealth");
        counter--;
    }
}

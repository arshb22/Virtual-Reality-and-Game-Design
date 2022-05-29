using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileExplosion : MonoBehaviour
{
    public GameObject particles;
    public GameObject a;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            GameObject.Find("UI Controller").SendMessage("addScore");
            Destroy(other.gameObject);
            Vector3 position = this.gameObject.transform.position;
            a = Instantiate(particles, position, transform.rotation) as GameObject;
            a.gameObject.GetComponent<ParticleSystem>().Play();
            Destroy(a, 2f);
            Destroy(this.gameObject);
        }
    }
}
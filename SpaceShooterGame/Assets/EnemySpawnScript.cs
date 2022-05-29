using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    public List<GameObject> enemyList;
    public bool win;
    public bool wait = true;
    public int i = 0;
    public Vector3 position;
    public float positionx;
    public bool hello = true;
    public bool isBounded = false;
    public int counter = 0;
    public float ok = 0f;

    // Start is called before the first frame update
    void Start()
    {
        enemyList = new List<GameObject>(Resources.LoadAll<GameObject>("Targets"));
        StartCoroutine(EnemySpawner());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator EnemySpawner()
    {
        while (hello)
        {
            yield return new WaitForSeconds(6f);
            positionx = Random.Range(-70, 70);
            StartCoroutine(Delay());
            if (counter == 1)
                counter = 0;
            else
                counter = 1;
        }
    }

    IEnumerator Delay()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.6f);
            int random = Random.Range(0, enemyList.Count - 1);
            int RandomRange = 0;

            while (!isBounded)
            {
                RandomRange = Random.Range(-10, 10);
                if (positionx + RandomRange <= 60 && positionx + RandomRange >= -60)
                {
                    position = new Vector3(positionx, 0f, 100f);
                    isBounded = true;
                }
            }
            //Debug.Log(positionx + RandomRange);

            GameObject a = Instantiate(enemyList[random], position, Quaternion.identity) as GameObject;
            a.transform.Rotate(0, 180, 0);
            Rigidbody rb = a.GetComponent<Rigidbody>();
            a.GetComponent<Rigidbody>().AddForce(-transform.forward * 800);

            
            yield return new WaitForSeconds(0.5f);
            {
                if (counter == 1)
                    a.GetComponent<Rigidbody>().AddForce(-transform.right * 400);
                else
                    a.GetComponent<Rigidbody>().AddForce(transform.right * 400);
            }
            
            isBounded = false;
            Destroy(a, 5f);
        }
    }

}

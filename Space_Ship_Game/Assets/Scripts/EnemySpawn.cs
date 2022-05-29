using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public List<GameObject> enemyList;
    public bool win;
    public bool wait = true;
    public int i = 0;
    public Vector3 position;
    public float positionx;
    public bool hello = true;
    public bool isBounded = false;


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
            yield return new WaitForSeconds(5f);
            positionx = Random.Range(-70, 70);
            StartCoroutine(Delay());
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
                    position = new Vector3(positionx + Random.Range(-10, 10), 0f, 44f);
                    isBounded = true;
                }
            }
            Debug.Log(positionx + RandomRange);

            GameObject a = Instantiate(enemyList[random], position, Quaternion.identity) as GameObject;
            a.transform.Rotate(0, 180, 0);
            Rigidbody rb = a.GetComponent<Rigidbody>();
            a.GetComponent<Rigidbody>().AddForce(-transform.forward * 800);
            isBounded = false;
            Destroy(a, 5f);
        }
    }
}

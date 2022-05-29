using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cube;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void clockwise()
    {
        cube.transform.Rotate(new Vector3(0, 0, - 1), Space.Self);
    }

    public void counterclockwise()
    {
        cube.transform.Rotate(new Vector3(0, 0, 1), Space.Self);
    }
}

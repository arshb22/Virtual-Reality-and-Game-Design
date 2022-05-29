using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinController : MonoBehaviour
{
    Animation spinAnimation;
    
    // Start is called before the first frame update
    void Start()
    {
        spinAnimation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(spinAnimation != null)
            {
                spinAnimation.Play("SpinCube");
            }
        }
    }
}

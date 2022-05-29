using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    Camera camera;
    float time;
    public Image reticle;
    public Text teleportIn;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        if (Physics.Raycast(
                Camera.main.transform.position,
                Camera.main.transform.forward,
                out hit))
        {
            string objectHit = hit.collider.gameObject.name;
            time += Time.deltaTime;
            reticle.transform.localScale = new Vector3(1 + .25f * time, 1 + .25f * time);
            if(objectHit.Equals("Scene1Transport"))
            {
                if(time>3)
                    SceneManager.LoadScene("London");
                teleportIn.text = "TELEPORT" + (3-time);
            }
            if (objectHit.Equals("WaterfallTransport"))
            {
                if(time>3)
                    SceneManager.LoadScene("Waterfall");
                teleportIn.text = "TELEPORT" + (3 - time);
            }
        }
        else
        {
            reticle.transform.localScale = new Vector3(1, 1, 1);
            time = 0;
            teleportIn.text = "TELEPORT";
        }
    }
}

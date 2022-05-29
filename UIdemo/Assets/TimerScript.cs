using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    
    float timer;
    int counter;
    public Text myText;
    private Text UIText;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        counter = 0;
        myText.text = "Time " + timer;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //myText.text = "Time " + timer;
        UIText = GetComponent<Text>();
        UIText.text = "Time " + timer;
    }
}

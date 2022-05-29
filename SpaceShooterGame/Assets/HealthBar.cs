using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Text winLoss;

    void Start()
    {
        slider.maxValue = 100;
        slider.value = 100;
    }
    
    public void SetHealth()
    {
        float nou = slider.value;
        float b = nou - 20;
        slider.value = b;
        if (slider.value == 0.0f)
        {
            winLoss.text = "You lose!";
        }
    }
    
}

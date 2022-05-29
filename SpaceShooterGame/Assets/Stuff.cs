using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stuff : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("SceneWithHealthBar");
    }
}

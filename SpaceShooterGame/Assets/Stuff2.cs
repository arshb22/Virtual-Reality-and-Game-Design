using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stuff2 : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("SceneWithHealthBar");
    }

}

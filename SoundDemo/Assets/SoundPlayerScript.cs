using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayerScript : MonoBehaviour
{
    AudioSource audioSource;
    AudioClip audioClip;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            audioSource.Play();
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            audioSource.Stop();
            audioClip = Resources.Load("CasualGameSounds/DM-CGS-02") as AudioClip;
            audioSource.clip = audioClip;
        }
    }
}

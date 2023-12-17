using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GlobalMusicVolume : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<MusicPlayer>().resetSound();
        audioSource.volume = audioSource.volume * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

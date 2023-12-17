using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource audioSource;
    public static Slider volumeSlider;
    public static float globalVolume = 1;
    //public float volumeChanger2, volumeChanger2;

    // Start is called before the first frame update
    void Start()
    {
        //audioSource = FindObjectOfType<AudioSource>();
        volumeSlider = FindObjectOfType<Slider>();
        audioSource.loop = false;
        audioSource.volume = globalVolume;
    }


    private AudioClip GetRandomClip()
    {
        return clips[Random.Range(0, clips.Length)];
    }


    public void changeVolume(float sliderValue)
    {
        audioSource.volume = sliderValue;
        globalVolume = sliderValue;
    }

    public void resetSound()
    {
        audioSource.volume = globalVolume * .5f;
    }


    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = GetRandomClip();
            audioSource.Play();
        }
    }
}

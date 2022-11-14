using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class AudioVolumen : MonoBehaviour
{
    public AudioMixer backgroundmixer;
    public AudioSource soundTrack;
    

    public static AudioVolumen instance;

    [Range(-80,10)]
    public float masterVol;
    public Slider materSlider;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayAudio(soundTrack);
        materSlider.value = masterVol;
        materSlider.minValue = -80;
        materSlider.maxValue = 0;
    }

    // Update is called once per frame
    public void Update()
    {

        MasterVolume();
        
    }

    public void PlayAudio(AudioSource audio)
    {
        audio.Play();
    }    

    public void MasterVolume()
    {
        backgroundmixer.SetFloat("MasterVolume", materSlider.value);
    }
  

}

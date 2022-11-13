using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPaused : MonoBehaviour
{


    public GameObject paused;
    public GameObject buttonCreation;
    public GameObject buttonOptions;
    public GameObject controls;
    public GameObject soundTrack;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void ActivatePaused()
    {
        paused.SetActive(true);
        buttonCreation.SetActive(false);

    }

    public void ResumePaused()
    {
        paused.SetActive(false);
        buttonCreation.SetActive(true);
    }

    public void Options()
    {
        buttonOptions.SetActive(true);
    }

    public void ButtonExit()
    {
        buttonOptions.SetActive(false);
        soundTrack.SetActive(true);
        AudioVolumen.instance.materSlider.value = 0;


    }

    public void Controls()
    {
        controls.SetActive(true);
    }

    public void ExitControls()
    {
        controls.SetActive(false);

    }

    public void OptonOk()
    {
        buttonOptions.SetActive(false);
    }

    public void PausedGame()
    {
        Time.timeScale = 0f;
    }

    public void ResuemGame()
    {
        Time.timeScale = 1f;
    }
}

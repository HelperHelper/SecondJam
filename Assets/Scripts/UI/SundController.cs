using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SundController : MonoBehaviour
{

    public GameObject sound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void ControlSound()
    {
        sound.SetActive(false);
    }

    public void SoundActive()
    {
        sound.SetActive(true);
    }


}

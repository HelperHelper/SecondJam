using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeclineLifeTree : MonoBehaviour
{

    
    public GameObject hearth;
    public GameObject hearth2;
    public GameObject hearth3;
    public GameObject gameOver;
    public GameObject buttonCreation;
    public AudioSource backGroundSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.CompareTag("Enemy"))
        {

            StartCoroutine(DeclineLife(collision));

        }
    }

    IEnumerator DeclineLife(Collider2D collider)
    {
        collider.enabled = false;
        hearth.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        collider.enabled = true;
        hearth2.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        collider.enabled = false;
        yield return new WaitForSeconds(1.5f);
        collider.enabled = true;
        hearth3.SetActive(false);
        Time.timeScale = 0f;
        backGroundSound.enabled = false;
        gameOver.SetActive(true);
        buttonCreation.SetActive(false);

        
        
    }
}



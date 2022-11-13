using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CambiarScene(string Menufirts)
    {
        SceneManager.LoadScene(Menufirts);
    }

    public void Tutorial(string Tutorial)
    {
        SceneManager.LoadScene(Tutorial);
    }

    public void PlayJuego(string SampleScene)
    {
        SceneManager.LoadScene(SampleScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

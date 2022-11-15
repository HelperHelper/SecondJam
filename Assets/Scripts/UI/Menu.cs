using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void CambiarScene(string Menufirts)
    {
        SceneManager.LoadScene(Menufirts);
     
    }

    public void Tutorial(string WorldMap)
    {
        SceneManager.LoadScene(WorldMap);
    }

    public void PlayJuego(string WorldMap)
    {
      
        SceneManager.LoadScene(WorldMap);
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

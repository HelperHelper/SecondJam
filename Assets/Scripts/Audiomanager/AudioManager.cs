using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip music;
    [SerializeField] private AudioClip coinSFX;
    [SerializeField] private AudioClip gameOverVFX;
    [SerializeField] private Transform objeto;

    private AudioSource audio;
    /// <summary>
    /// instance -> Es la variable común a todas las instancias o copias de Audiomanager
    /// y que si por casualidad ya tiene un valor osea no es == null significa que
    /// la instancia que está comprobando si ya instance tiene un valor es la segunda instancia en llegar
    /// </summary>
    public static AudioManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else instance = this;

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    //[ContextMenu("Reset")]
    //public void ResetCurrentScene()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}

    [ContextMenu("Coin")]
    public void PlayCoinVFX()
    {
        audio.PlayOneShot(coinSFX);
    }
}

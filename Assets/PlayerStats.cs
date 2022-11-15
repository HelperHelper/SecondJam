using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 20;

    public static int lives;
    public int startLives = 3;

    public static int Rounds;


    public GameObject live1;
    public GameObject live2;
    public GameObject live3;


    private void Start()
    {
        Money = startMoney;
        lives = startLives;

        Rounds = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            lives--;
        }
        if (collision.CompareTag("final"))
        {
            Destroy(gameObject);
        }

    }
    private void Update()
    {
        if (lives < 1)
        {
            Destroy(live1);
            return;
        }
        if (lives < 2)
        {
            Destroy(live2);
            return;
        }
        if (lives < 3)
        {
            Destroy(live3);
            return;
        }
    }
    
}

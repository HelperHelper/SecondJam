using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterLife : MonoBehaviour
{
    [HideInInspector]
    public float startSpeed = 1f;
    public float speed;
    public float startHealth = 100;
    private float healt;

    public int value = 5;

    private Transform target;

    public Image healthBar;
    //private int wavepointIndex = 0;

    private void Start()
    {
        speed = startSpeed;
        healt = startHealth;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            TakeDamage(50);
        }
        if (collision.CompareTag("Final"))
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float amount)
    {
        healt -= amount;

        healthBar.fillAmount = healt / startHealth;

        if (healt <= 0)
            Die();
    }
    void Die()
    {
        WaveSpawner.enemiesAlive--;
        Destroy(gameObject);
    }
}

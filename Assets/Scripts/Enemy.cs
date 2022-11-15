using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    [HideInInspector]
    public float startSpeed = 1f;
    public float speed;
    public float startHealth = 100;
    private float healt;

    public int value = 5;
    ActiveButtom activeButtom;

    private Transform target;

    public Image healthBar;
    private int wavepointIndex = 0;

    private void Start()
    {
        speed = startSpeed;
        healt = startHealth;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TakeDamage(50);
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
        PlayerStats.Money += value;
        ActiveButtom.bank += value;
        WaveSpawner.enemiesAlive--;
        Debug.Log("se murio" + WaveSpawner.enemiesAlive);
        Destroy(gameObject);
    }
}

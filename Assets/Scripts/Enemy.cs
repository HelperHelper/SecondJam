using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [HideInInspector]
    public float startSpeed = 1f;
    public float speed;
    public float startHealth = 100;
    private float healt;

    public int value = 5;

    private Transform target;
    private int wavepointIndex = 0;

    private void Start()
    {
        speed = startSpeed;
        healt = startHealth;
    }

    public void TakeDamage(float amount)
    {
        healt -= amount;

        if (healt <= 0)
            Die();
    }
    void Die()
    {
        Destroy(gameObject);
    }
}

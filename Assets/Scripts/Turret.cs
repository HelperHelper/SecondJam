using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target = null;
    private Enemy targetEnemy;

    Animator anim;

    [Header("General")]
    public float range = 1f;

    [Header("Proyectiles(default)")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public bool attack = true;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";

    [Header("proyectil")]
    public Transform firepoint;
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        anim = GetComponent<Animator>();
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (fireCountdown <= 0f && target)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
            fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        StartCoroutine(WaitForAttack(0.8f));            
        
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        bool attaking = stateInfo.IsName("Player_Attack");

        if (!attaking)
        {
            anim.SetTrigger("Attaking");
        }
        

        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

    IEnumerator WaitForAttack(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();
        if (bullet != null)
            bullet.Seek(target);
    }

}

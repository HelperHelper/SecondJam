using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAMover : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform targetSecondary;

    private NavMeshAgent agent;

    public float range = 1;

    Animator anim;

    public float speed;

    public string enemyTag = "Player";
    private Enemy targetEnemy;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        targetSecondary = target;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        anim = GetComponent<Animator>();

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void Update()
    {
        if (target == null)
        {
            agent.SetDestination(targetSecondary.position);
            return;
        }/*
        Vector3 dir = agent.destination - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if (dir.magnitude <= distanceThisFrame + 2)
        {
            Attaking();
            return;
        }*/
        agent.SetDestination(target.position);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Attaking();
        }
    }

    void Attaking()
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        bool attaking = stateInfo.IsName("Attack");

        if (!attaking)
        {
            anim.SetTrigger("Attacking");
        }
    }
}

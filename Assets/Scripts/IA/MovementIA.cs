using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementIA : MonoBehaviour
{
    private NavMeshAgent MovePlayer, MoveEnemy;
    private Animator thisAnim;
    public GameObject[] destinyPrefabs;

    [SerializeField] private Transform objetivo;
    [SerializeField] private float sideSpawnMinY = 1.32f;
    [SerializeField] private float sideSpawnMaxY = -9.89f;

    private Vector3 spawnPos;
    [SerializeField] private float sideSpawnX = 10;
    //private bool spawn
    public bool isAllied;
    void Start()
    {
        MovePlayer = GetComponent<NavMeshAgent>();
        MoveEnemy = GetComponent<NavMeshAgent>();
        thisAnim = GetComponent<Animator>();

        if (spawnPos != null)
        {
            Debug.Log("Se ejecuto el metodo invoke y pasaron estos segundos" + Time.deltaTime);
        }

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right);
            if (hit.transform.tag == "Enemy" && !isAllied)
            {
                if (hit.transform.position.x == MovePlayer.transform.position.x && hit.collider.IsTouching(hit.collider) == true)
                {
                    thisAnim.SetTrigger("AttackAlly");
                }
                else
                {
                    MoveEnemy.SetDestination(objetivo.position);
                    thisAnim.SetBool("ConnectedCharacter", false);                    
                }
                if (hit.collider != null)
                {
                    Debug.Log(hit.collider.name);
                }
            }
        }
        if (isAllied)
        {
            MovePlayer.SetDestination(objetivo.position);
            this.transform.localRotation = Quaternion.Euler(0, 0, 0); 
        }
        else
        {            
            MoveEnemy.SetDestination(spawnPos);
            this.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
    /*
    void SpawnDestiny()
    {
        int destinyIndex = Random.Range(0, destinyPrefabs.Length);
        spawnPos = new Vector3(-sideSpawnX, Random.Range(-sideSpawnMinY, sideSpawnMaxY), 0);
    }
    */
}

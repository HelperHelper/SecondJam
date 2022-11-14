using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementIA : MonoBehaviour
{
    private NavMeshAgent MovePlayer, MoveEnemy;
    private Animator thisAnim;
    public GameObject[] destinyPrefabs;
    // [SerializeField] private Transform destinyEnemie;
    [SerializeField] private Transform objetivo;
    [SerializeField] private float sideSpawnMinY = 1.32f;
    [SerializeField] private float sideSpawnMaxY = -9.89f;
//public float sideSpawnMinX;
  //  public float sideSpawnMaxX;
    private float starDelay = 5;
    private float spawnInterval = 2.5f;
    private Vector3 spawnPos;
    [SerializeField] private float sideSpawnX = 10;
    //private bool spawn
    public bool isAllied;

    // Start is called before the first frame update
    void Start()
    {
        MovePlayer = GetComponent<NavMeshAgent>();
        MoveEnemy = GetComponent<NavMeshAgent>();
        thisAnim = GetComponent<Animator>();
        // destinyEnemie = GetComponent<Transform>();
        InvokeRepeating("SpawnDestiny", starDelay, spawnInterval);
        if (spawnPos != null)
        {
            Debug.Log("Se ejecuto el metodo invoke y pasaron estos segundos" + Time.deltaTime);
        }

    }

    // Update is called once per frame
    void Update()
    {

        //If the left mouse button is clicked.
        if (Input.GetMouseButtonDown(0))
        {
            //Get the mouse position on the screen and send a raycast into the game world from that position.
            // Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right);
            Debug.DrawRay(transform.position, Vector2.right * hit.point, Color.blue);
            Debug.DrawRay(transform.position, Vector2.right * 10f, Color.red);
            Debug.Log("hit nombre tag: " + hit.transform.tag);
            if (hit.transform.tag == "Enemy" && !isAllied)
            {


                Debug.Log("Es el enemigo ataquemoslo, está en la posicion: " + hit.transform.position);
                Debug.Log("Que hace el hit collider y lo está tocando " + hit.collider.IsTouching(hit.collider));
              //  MoveEnemy.SetDestination(objetivo.position);

                // Debug.DrawRay(transform.position, Vector2.right * hit.point, Color.blue);
                // Debug.DrawRay(transform.position, Vector2.right * 10f, Color.red);
                if (hit.transform.position.x == MovePlayer.transform.position.x && hit.collider.IsTouching(hit.collider) == true)
                {
                    thisAnim.SetTrigger("AttackAlly");
                    // thisAnim.SetFloat("Speed", 1);
                    // thisAnim.SetBool("ConnectedCharacter", true);

                }
                else
                {
                    MoveEnemy.SetDestination(objetivo.position);
                    //thisAnim.ResetTrigger("AttackAlly");
                    // thisAnim.Play("Locomotion");
                    //thisAnim.SetFloat("Spee", 0);d
                    thisAnim.SetBool("ConnectedCharacter", false);
                    // thisAnim.applyRootMotion = true;
                }


                //If something was hit, the RaycastHit2D.collider will not be null.
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



    void SpawnDestiny()
    {
      //Vector3 asd = new Vector3()
        int destinyIndex = Random.Range(0, destinyPrefabs.Length);
        spawnPos = new Vector3(-sideSpawnX, Random.Range(-sideSpawnMinY,
        sideSpawnMaxY), 0);
        Instantiate(destinyPrefabs[destinyIndex], spawnPos,
        destinyPrefabs[destinyIndex].transform.rotation);
    }

    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entro al trigger");

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right);
        Debug.Log("hit nombre tag: " + hit.transform.tag);
        if (hit.transform.tag == "Enemy")
        {

            bool diferencia = hit.transform.position.x == MovePlayer.transform.position.x;

            //Debug.Log()
            // Debug.Log("la distancia del enemigo es " + diferencia);

            MoveEnemy.SetDestination(objetivo.position);
            // Debug.DrawRay(transform.position, Vector2.right * hit.point, Color.blue);
            // Debug.DrawRay(transform.position, Vector2.right * 10f, Color.red);
            if (hit.transform.position.x == MovePlayer.transform.position.x && other.isTrigger)
            {
                thisAnim.SetTrigger("AttackAlly");
                // thisAnim.SetFloat("Speed", 1);
                // thisAnim.SetBool("ConnectedCharacter", true);

            }
            else
            {
                //thisAnim.ResetTrigger("AttackAlly");
                // thisAnim.Play("Locomotion");
                //thisAnim.SetFloat("Speed", 0);
                thisAnim.SetBool("ConnectedCharacter", false);
                // thisAnim.applyRootMotion = true;
            }

        }

        //  Debug.Log("la distancia del enemigo es " + hit.transform.tag);

        // bool diferencia = hit.transform.position.x == MovePlayer.transform.position.x;

        //Debug.Log()
        // Debug.Log("la distancia del enemigo es " + diferencia);

        MovePlayer.SetDestination(objetivo.position);
        // Debug.DrawRay(transform.position, Vector2.right * hit.point, Color.blue);
        // Debug.DrawRay(transform.position, Vector2.right * 10f, Color.red);
        if (hit.transform.position.x == MoveEnemy.transform.position.x && isAllied)
        {
            thisAnim.SetTrigger("Attack");
            // thisAnim.SetFloat("Speed", 1);
            // thisAnim.SetBool("ConnectedCharacter", true);

        }
        else
        {
            //thisAnim.ResetTrigger("AttackAlly");
            // thisAnim.Play("Locomotion");
            //thisAnim.SetFloat("Speed", 0);
            thisAnim.SetBool("ConnectedCharacter", false);
            // thisAnim.applyRootMotion = true;
        }

    }
    */
}

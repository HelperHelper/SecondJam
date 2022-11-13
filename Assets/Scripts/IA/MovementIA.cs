using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementIA : MonoBehaviour
{
    private NavMeshAgent MovePlayer, MoveEnemy;
    private Animator thisAnim;
    public Transform DestinyAliate, DestinyEnemie;

    public bool isAllied;

    // Start is called before the first frame update
    void Start()
    {
        MovePlayer = GetComponent<NavMeshAgent>();
        MoveEnemy = GetComponent<NavMeshAgent>();
        thisAnim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        /// usar este metodo para atacar con proyectiles desde el arbol
        //public void TakeDamage(float amount)
        //{
        //    healt -= amount;

        //    if (healt <= 0)
        //        Die();
        //}

        if (isAllied)
        {
            MovePlayer.SetDestination(DestinyAliate.position);
            this.transform.localRotation = Quaternion.Euler(0, 0, 0); 
        }
        else
        {
            MoveEnemy.SetDestination(DestinyEnemie.position);
            this.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {


        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right);
        if (hit.transform.tag == "Enemie")
        {

            bool diferencia = hit.transform.position.x == MovePlayer.transform.position.x;

            //Debug.Log()
           // Debug.Log("la distancia del enemigo es " + diferencia);

            MoveEnemy.SetDestination(hit.point);
           // Debug.DrawRay(transform.position, Vector2.right * hit.point, Color.blue);
           // Debug.DrawRay(transform.position, Vector2.right * 10f, Color.red);
            if (hit.transform.position.x == MovePlayer.transform.position.x && other.isTrigger)
            {
                thisAnim.SetTrigger("AttackAlly");
               // thisAnim.SetFloat("Speed", 1);
               // thisAnim.SetBool("ConnectedCharacter", true);

            } else
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

            MovePlayer.SetDestination(hit.point);
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
}

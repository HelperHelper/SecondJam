using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCoin : MonoBehaviour
{

    public GameObject coin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       StartCoroutine(DestroyEnemy());

    }

    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        coin.SetActive(true);
    }
}


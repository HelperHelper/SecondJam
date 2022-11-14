using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinEnemy : MonoBehaviour
{

    public int coin;
    public GameObject positionEnemy;
   

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Coin());
        transform.position = positionEnemy.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Coin()
    {
        yield return new WaitForSeconds(1);
        ActiveButtom.instance.Money(coin);
        Destroy(gameObject);
    }
}

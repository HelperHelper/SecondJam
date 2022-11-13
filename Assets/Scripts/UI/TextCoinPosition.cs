using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCoinPosition : MonoBehaviour
{

    public GameObject positionEnemy;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = positionEnemy.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

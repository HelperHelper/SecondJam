using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private float starDelay = 2;
    private float spawnInterval = 1.5f;
    [SerializeField] private float sideSpawnMinY = -3;
    [SerializeField] private float sideSpawnMaxY = 5;
    [SerializeField] private float sideSpawnX = 19;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnLefEnemy", starDelay, spawnInterval);
    }


    void SpawnLefEnemy()
    {
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Vector3 spawnPos = new Vector3(sideSpawnX, Random.Range(sideSpawnMinY,
        -sideSpawnMaxY), 0);
        Instantiate(enemyPrefabs[enemyIndex], spawnPos,
        enemyPrefabs[enemyIndex].transform.rotation);
    }
}

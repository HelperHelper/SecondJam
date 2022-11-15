using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int enemiesAlive;

    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 5f;

    public Text waveCountdownText;

    public GameManager gamemanager;

    private int waveIndex = 0;

    [SerializeField] private float sideSpawnMinY = -3;
    [SerializeField] private float sideSpawnMaxY = 5;
    [SerializeField] private float sideSpawnX = 19;

    private void Start()
    {
        enemiesAlive = 0;
    }

    void Update()
    {
        Debug.Log(enemiesAlive);
        if (enemiesAlive > 0)
        {
            return;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00:00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveIndex++;
        Debug.Log(waveIndex);
    }

    void SpawnEnemy(GameObject enemy)
    {

        enemiesAlive++;
        Vector3 spawnPos = new Vector3(sideSpawnX, Random.Range(sideSpawnMinY,sideSpawnMaxY), 0);
        Instantiate(enemy, spawnPos, spawnPoint.rotation);
        
    }
}

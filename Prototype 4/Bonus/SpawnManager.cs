using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject normalEnemy;
    public GameObject strongEnemy;
    public GameObject[] powerUpPrefabs;
    public GameObject bossEnemy;

    private float spawnRange = 9.0f;
    public int waveNumber = 1;
    public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        //SpawnEnemyWave(waveNumber);

        //Instantiate(powerUpPrefabs[0], GenerateSpawnPosition(), powerUpPrefabs[0].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length + FindObjectsOfType<HardEnemy>().Length + FindObjectsOfType<Boss>().Length;

        int powerUpIndex = Random.Range(0, powerUpPrefabs.Length);

        if(enemyCount == 0)
        {
            if (waveNumber == 2)
            {
                Instantiate(powerUpPrefabs[powerUpIndex], GenerateSpawnPosition(), powerUpPrefabs[powerUpIndex].transform.rotation);
                SpawnBossWave();
                waveNumber++;
            }
            else
            {
                Instantiate(powerUpPrefabs[powerUpIndex], GenerateSpawnPosition(), powerUpPrefabs[powerUpIndex].transform.rotation);
                SpawnEnemyWave(waveNumber);
                waveNumber++;
            }

        }


    }

    private void SpawnBossWave()
    {
        Instantiate(bossEnemy, GenerateSpawnPosition(), bossEnemy.transform.rotation);
    }

    private void SpawnEnemyWave(int enemies)
    {
        int enemyType = Random.Range(0, 10);

        if(enemyType < 3)
        {
            for (int i = 0; i < enemies; i++)
            {
                Instantiate(strongEnemy, GenerateSpawnPosition(), strongEnemy.transform.rotation);
            }
        }
        else if(enemyType >= 3)
        {
            for (int i = 0; i < enemies; i++)
            {
                Instantiate(normalEnemy, GenerateSpawnPosition(), normalEnemy.transform.rotation);
            }
        }
    }
    
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}

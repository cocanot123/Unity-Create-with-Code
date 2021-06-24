using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private Vector3 spawnPos2 = new Vector3(26, 0, 0);
    private float startDelay = 2.0f;
    private float repeatRate = 4.0f;
    private PlayerController playerControlerScript;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControlerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        int stackIndex = Random.Range(0, 2);

        if (playerControlerScript.gameOver == false && stackIndex == 0)
        {
            int index = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[index], spawnPos, obstaclePrefabs[index].transform.rotation);
        }
        else if (playerControlerScript.gameOver == false && stackIndex == 1)
        {
            int index = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[index], spawnPos, obstaclePrefabs[index].transform.rotation);
            Instantiate(obstaclePrefabs[index], spawnPos2, obstaclePrefabs[index].transform.rotation);
        }
    }
}

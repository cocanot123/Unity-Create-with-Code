using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20;
    private float spawnRangeZ = 30;
    private float spawnPosZ = 30;
    private float spawnPosX = 20;
    private float startDelay = 2;
    private float spawnIntervalFront = 4.5f;
    private float spawnIntervalSide = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimalFront", startDelay, spawnIntervalFront);
        InvokeRepeating("SpawnRandomAnimalSide", startDelay, spawnIntervalSide);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomAnimalFront()
    {
        Vector3 spawnPosX = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], spawnPosX, animalPrefabs[animalIndex].transform.rotation);
    }

    void SpawnRandomAnimalSide()
    {
        Vector3 spawnPosZRight = new Vector3(-spawnPosX, 0, Random.Range(10, spawnRangeZ));
        Vector3 spawnPosZleft = new Vector3(spawnPosX, 0, Random.Range(10, spawnRangeZ));
        int animalIndexR = Random.Range(0, animalPrefabs.Length);
        int animalIndexL = Random.Range(0, animalPrefabs.Length);
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.y = 90;
        Instantiate(animalPrefabs[animalIndexR], spawnPosZRight, Quaternion.Euler(rotationVector));
        Instantiate(animalPrefabs[animalIndexL], spawnPosZleft, Quaternion.Euler(-rotationVector));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Rigidbody bossRb;
    private GameObject player;
    public GameObject minionEnemy;

    public float speed;
    private int minionWaveNum = 1;
    private float spawnRange = 8.0f;
    // Start is called before the first frame update
    void Start()
    {
        bossRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        bossRb.AddForce(lookDirection * speed);

        if (transform.position.y < -15)
        {
            Destroy(gameObject);
        }

        if(FindObjectsOfType<Enemy>().Length == 0)
        {
            SpawnMinions(minionWaveNum);
            minionWaveNum++;
        }
    }

    private void SpawnMinions(int count)
    {
        for(int i = 0; i < count; i++)
        {
            Instantiate(minionEnemy, GenerateSpawnPosition(), minionEnemy.transform.rotation);
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

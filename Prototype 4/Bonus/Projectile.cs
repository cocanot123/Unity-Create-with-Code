using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    private float Bound = 25;

    private Rigidbody projectileRb;
    private GameObject enemy;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        projectileRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        Vector3 playerPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        transform.LookAt(playerPos);
        transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);

        if(FindObjectsOfType<Enemy>().Length > 0)
        {
            enemy = GameObject.Find("Enemy");
        }
        else if(FindObjectsOfType<HardEnemy>().Length > 0)
        {
            enemy = GameObject.Find("HardEnemy");
        }

        StartCoroutine(runProjectileCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        projectileRb.AddForce(-transform.up * speed);
    }

    IEnumerator runProjectileCoroutine()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }


    private bool OutOfBound(float xPos, float zPos)
    {
        return ((xPos > Bound || xPos < -Bound) || (zPos > Bound || zPos < -Bound));
    }
}

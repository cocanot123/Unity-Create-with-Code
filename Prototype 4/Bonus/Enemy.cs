using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRb;
    private GameObject player;
    public float speed;
    public float hitStrength;
    public float hitBySmashUpStrength;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        Debug.Log(lookDirection);
        enemyRb.AddForce(lookDirection* speed);

        if(transform.position.y < -15)
        {
            Destroy(gameObject);
        }
    }

    public void KnockBack()
    {
        enemyRb.AddForce(Vector3.up * hitBySmashUpStrength, ForceMode.Impulse);
        enemyRb.AddForce(-transform.forward * hitStrength, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Vector3 awayFromEnemy = (transform.position - collision.gameObject.transform.position);
            enemyRb.AddForce(awayFromEnemy * hitStrength, ForceMode.Impulse);
        }
    }


}

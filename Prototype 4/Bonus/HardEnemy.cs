using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardEnemy : MonoBehaviour
{
    private Rigidbody henemyRb;
    private GameObject player;

    public float speed;
    public float hitStrength;
    public float hitBySmashUpStrength;

    // Start is called before the first frame update
    void Start()
    {
        henemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        henemyRb.AddForce(lookDirection * speed);

        if (transform.position.y < -15)
        {
            Destroy(gameObject);
        }
    }

    public void KnockBack()
    {
        henemyRb.AddForce(Vector3.up * hitBySmashUpStrength, ForceMode.Impulse);
        henemyRb.AddForce(-transform.forward * hitStrength, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Projectile"))
        {
            Vector3 awayFromEnemy = (collision.gameObject.transform.position - transform.position);
            henemyRb.AddForce(awayFromEnemy * hitStrength, ForceMode.Impulse);
        }
    }
}

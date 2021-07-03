using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    private float powerUpStrength = 15.0f;
    public float jumpStrength;
    public float smashStrength;

    public bool hasPowerUpA;
    public bool hasPowerUpB;
    public bool hasPowerUpC;
    private bool isOnGround;

    private Rigidbody playerRb;
    private GameObject focalPoint;
    public GameObject powerUpIndicator;
    public GameObject projectile;
    private GameObject spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");

        spawnManager = GameObject.Find("SpawnManager");

        isOnGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);
        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

        if(hasPowerUpC && Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            StartCoroutine(JumpSmash());
        }
    }

    IEnumerator PowerupCountdownCoroutine()
    {
        yield return new WaitForSeconds(3);
        hasPowerUpA = false;
        hasPowerUpB = false;
        powerUpIndicator.SetActive(false);
    }

    IEnumerator JumpSmash()
    {
        isOnGround = false;
        playerRb.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
        yield return new WaitForSeconds(0.6f);
        playerRb.AddForce(-Vector3.up * smashStrength, ForceMode.Impulse);
    }

    private void KnockEnemies()
    {
        var enemies = FindObjectsOfType<Enemy>();
        var hardEnemies = FindObjectsOfType<HardEnemy>();
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].KnockBack();
        }

        for (int i = 0; i < hardEnemies.Length; i++)
        {
            hardEnemies[i].KnockBack();
        }
    }

    private void SpawnProjectile()
    {
        for (int i = 0; i < 18; i++)
        {
            float rot = 2.0f * Mathf.PI / 18.0f * i;
            Debug.Log(rot);
            //Vector3 spawnPos = new Vector3(Mathf.Cos(rot), 0.5f, Mathf.Sin(rot));
            Instantiate(projectile, new Vector3 (transform.position.x + 1.2f*Mathf.Cos(rot), transform.position.y, transform.position.z + 1.2f*Mathf.Sin(rot)), Quaternion.identity);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("PowerupA"))
        {
            hasPowerUpA = true;
            Destroy(other.gameObject);
            powerUpIndicator.SetActive(true);
            StartCoroutine(PowerupCountdownCoroutine());
        }
        else if (other.CompareTag("PowerupB"))
        {
            hasPowerUpB = true;
            Destroy(other.gameObject);
            powerUpIndicator.SetActive(true);
            SpawnProjectile();
            StartCoroutine(PowerupCountdownCoroutine());
        }
        else if (other.CompareTag("PowerupC"))
        {
            hasPowerUpC = true;
            Destroy(other.gameObject);
            powerUpIndicator.SetActive(true);
            //StartCoroutine(PowerupCountdownCoroutine());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("HardEnemy")) && hasPowerUpA)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            Debug.Log("Collided with " + collision.gameObject.name + "with powerup set to " + hasPowerUpA);
            enemyRb.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            hasPowerUpC = false;
            powerUpIndicator.SetActive(false);
            isOnGround = true;
            KnockEnemies();
        }
    }
}

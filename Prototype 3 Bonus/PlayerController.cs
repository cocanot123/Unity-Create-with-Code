using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAni;
    public ParticleSystem explosionParticle;
    public AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    public int jumpForce;
    public float gravityModifier;
    private int jumpCount;
    private int score;

    public bool isOnGround = true;
    public bool gameOver = false;
    public bool dash = false;
    private bool moveRight = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAni = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
        jumpCount = 0;
        InvokeRepeating("CalculateScore", 1.0f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {

        Jump();
        Dash();
        Debug.Log(score);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2 && gameOver != true)
        {
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            isOnGround = false;
            jumpCount++;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAni.SetTrigger("Jump_trig");
        }
    }

    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.D) && gameOver != true)
        {
            dash = true;
            playerAni.SetFloat("Speed_f", 2.5f);
        }
        else if (Input.GetKeyUp(KeyCode.D) && gameOver != true)
        {
            dash = false;
            playerAni.SetFloat("Speed_f", 1.5f);
        }
    }

    void CalculateScore()
    {
        if(dash)
        {
            score += 2;
        }
        else
        {
            score += 1;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            jumpCount = 0;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            playerAudio.PlayOneShot(crashSound, 1.0f);
            playerAni.SetBool("Death_b", true);
            playerAni.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            CancelInvoke();
            Debug.Log("Game Over");
        }
    }
}

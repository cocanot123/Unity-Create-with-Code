using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30.0f;
    public PlayerController playerControllerScript;
    private int leftBound = -15;
    private float dashMultiplier = 1.5f; 
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject();
        DestroyObject();
    }

    void MoveObject()
    {
        if (playerControllerScript.gameOver == false && playerControllerScript.dash)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed * dashMultiplier);
        }
        else if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }

    void DestroyObject()
    {
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}

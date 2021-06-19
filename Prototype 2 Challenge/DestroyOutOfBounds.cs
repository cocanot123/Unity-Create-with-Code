using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -10;
    private float leftBound = -20;
    private float rightBound = 20;
    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
         target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
            target.GetComponent<PlayerController>().lives -= 1;
            Debug.Log("Lives" + target.GetComponent<PlayerController>().lives);
        }
        else if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
            target.GetComponent<PlayerController>().lives -= 1;
            Debug.Log("Lives" +  target.GetComponent<PlayerController>().lives);
        }

        if (transform.position.x > rightBound)
        {
            Destroy(gameObject);
            target.GetComponent<PlayerController>().lives -= 1;
            Debug.Log("Lives" +  target.GetComponent<PlayerController>().lives);
        }
        else if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
            target.GetComponent<PlayerController>().lives -= 1;
            Debug.Log("Lives" + target.GetComponent<PlayerController>().lives);
        }

    }
}

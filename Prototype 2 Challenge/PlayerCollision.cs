using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit animal");
        Destroy(other.gameObject);
        target.GetComponent<PlayerController>().lives -= 1;
        Debug.Log(target.GetComponent<PlayerController>().lives);
    }
}

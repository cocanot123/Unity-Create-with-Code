using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectCollision : MonoBehaviour
{

    //Slider

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Destroy(other.gameObject);
        GameObject target = GameObject.Find("Player");
        target.GetComponent<PlayerController>().score += 1;
        Debug.Log("Score: " + target.GetComponent<PlayerController>().score);
    }

}

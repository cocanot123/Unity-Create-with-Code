using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public float colorInterp =2.0f;
    public int posFrames = 600;
    private int elapsedFrames = 0;
    private float color4 = 0.4f;
    private Color newColor;
    private Vector3 newPos;

    void Start()
    {
        transform.position = new Vector3(40, 4, 5);
        transform.localScale = Vector3.one * 1.3f;
        
        Material material = Renderer.material;
        material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), color4);

        InvokeRepeating("changeColor", 0.0f, 1.5f);
        //InvokeRepeating("changePos", 0.0f, 2.0f);
    }
    
    void Update()
    {
        Material material = Renderer.material;
        material.color = Color.Lerp(material.color, newColor, Time.deltaTime*colorInterp); 
        transform.Rotate(20.0f * Time.deltaTime, 0.0f, 0.0f);

        float interpolationRatio = (float)elapsedFrames / posFrames;
        transform.position = Vector3.Lerp(transform.position, new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10)), interpolationRatio);
        elapsedFrames = (elapsedFrames + 1) % (posFrames + 1);
    }

    void changeColor()
    {
        newColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), color4);
    }

    void changePos()
    {
        newPos = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
    }
}

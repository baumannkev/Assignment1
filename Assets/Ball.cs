using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    public float x = 0.0f;
    public float y = 0.0f;
    public float z = 0.0f;
    
    public GameObject ball;
    public string HitMessage = "Hit collider!";
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            x *= -1.0f;
            y *= -1.0f;
            Debug.Log(HitMessage);
        }
        
        if (collision.gameObject.tag == "Game Controller") {
            y *= -1.0f;
            Debug.Log(HitMessage);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        x = -0.05f;
        y = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(x, y, z);
    }
}

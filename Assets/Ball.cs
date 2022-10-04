using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    public int playerOneScore = 0;
    public int playerTwoScore = 0;
    public int gameOver = 5;
    
    public GameObject playerOneText;
    public GameObject playerTwoText;
    
    public GameObject gameOverText;
    public float x = 0.0f;
    public float y = 0.0f;
    public float z = 0.0f;
    
    public GameObject ball;
    public string HitMessage = "Hit collider!";
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            
            x *= -1.05f;
            Debug.Log(HitMessage);
        }
        
        if (collision.gameObject.tag == "GameController") {
            Debug.Log(HitMessage);
            y *= -1.0f;
        }
        
        if (collision.gameObject.tag == "Respawn")
        {
            playerOneText.name = "" + playerOneScore++;
            Debug.Log("Point for left");
            y *= 0.0f;
            x *= 0.0f;
        }
        
        if (collision.gameObject.tag == "Finish") {
            playerTwoScore++;
            Debug.Log("Point for right");
            y *= 0.0f;
            x *= 0.0f;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        gameOverText.GetComponent<Renderer>().enabled = false;
        x = -0.05f;
        y = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerOneScore == gameOver || playerTwoScore == gameOver)
        {
            gameOverText.GetComponent<Renderer>().enabled = true;
        }
        transform.Translate(x, y, z);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Hat : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Transform pos;

    private bool red_hat = false;
    private float xSpeed;
    [SerializeField ]private float ySpeed;
    [SerializeField ]private float xSpeedRange;

    private int points = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pos = GetComponent<Transform>();
        pos.position = new Vector2(0.0f, 3.6f);
        red_hat = false;
        rb.velocity = new Vector2(xSpeed, ySpeed);
        xSpeed = UnityEngine.Random.Range(-xSpeedRange, xSpeedRange);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        rb.velocity = new Vector2(xSpeed, rb.velocity.y);
        
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.name == "Floor")
        {
            Debug.Log("Collision with Floor");
            red_hat = true;
            Invoke("Start", 0.5f);
            
        }
        else if (collision.gameObject.name == "Seller" && red_hat != true )
        {
            Invoke("Start", 0);
            points++;
            Debug.Log("Points:- "+points);
            
        }
    }
}

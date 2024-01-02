using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class Hat : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;

    public Motion motion;

    private Transform pos;

    private bool red_hat = false;
    private float xSpeed;

    [SerializeField ]private TMP_Text pointsDisplay;
    [SerializeField ]private float ySpeed;
    [SerializeField ]private float xSpeedRange;

    [SerializeField ]private GameObject endPanel;

    private int points = 0;
    public int no_of_chances = 3;
    [Header("Chances")]
    [SerializeField]private GameObject Chance1;
    [SerializeField]private GameObject Chance2;
    [SerializeField]private GameObject Chance3;
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
        
        if (collision.gameObject.name == "Floor" && red_hat != true )
        {
            Debug.Log("Collision with Floor");
            no_of_chances--;
            Checking_Chances();
            red_hat = true;
            Invoke("Start", 0.5f);
            
        }
        else if (collision.gameObject.name == "Seller" && red_hat != true )
        {
            Invoke("Start", 0);
            points++;
            pointsDisplay.text = points.ToString();
            Debug.Log("Points:- "+points);
            
        }
    }
    void Checking_Chances(){
        if (no_of_chances==3){
            Chance1.gameObject.SetActive(true);
            Chance2.gameObject.SetActive(true);
            Chance3.gameObject.SetActive(true);
        }else if(no_of_chances==2){
            Chance1.gameObject.SetActive(true);
            Chance2.gameObject.SetActive(true);
            Chance3.gameObject.SetActive(false);
        }else if(no_of_chances==1){
            Chance1.gameObject.SetActive(true);
            Chance2.gameObject.SetActive(false);
            Chance3.gameObject.SetActive(false);
        }else if(no_of_chances<=0){
            Chance1.gameObject.SetActive(false);
            Chance2.gameObject.SetActive(false);
            Chance3.gameObject.SetActive(false);
            //gameObject.SetActive(false);
            motion.rb1.simulated = false;
            motion.rb2.simulated = false;
            motion.anim.enabled = false;

            endPanel.gameObject.SetActive(true);
            
        }


    }
}

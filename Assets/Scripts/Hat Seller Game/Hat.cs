using System.Drawing;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class Hat : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    public Motion motion;
    public CountdownController cc;
    private Transform pos;
    private bool red_hat = false;
    private float xSpeed;
    [SerializeField ]private TMP_Text pointsDisplay;
    [SerializeField ]private TMP_Text totalPointsDisplay;
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
            bc = GetComponent<BoxCollider2D>();
            pos.position = new Vector2(0.0f, 3.6f);
            red_hat = false;
            bc.enabled = true;
            rb.velocity = new Vector2(xSpeed, ySpeed);
            xSpeed = UnityEngine.Random.Range(-xSpeedRange, xSpeedRange);
            hat_drop(0);
         
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
            if(no_of_chances>1){
                SceneAudio.game_audio("seller_voice");
                SceneAudio.game_audio("dropped");
            }
            else if(points>=10){
                SceneAudio.game_audio("applause");
            }else{
                SceneAudio.game_audio("dropped");
            }
            
            no_of_chances--;
            Checking_Chances();
            red_hat = true;
            hat_drop(1);
            Invoke("Start", 0.5f);
            
        }
        else if (collision.gameObject.name == "Seller" && red_hat != true )
        {
            points++;
            BoxCollider2D bc = GetComponent<BoxCollider2D>();
            bc.enabled = false;
            pointsDisplay.text = points.ToString();
            totalPointsDisplay.text = points.ToString();
            Debug.Log("Points:- "+points);
            SceneAudio.game_audio("collected");
            hat_drop(2);
            Invoke("Start", 0.15f);   
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
        void hat_drop(int color_switch){
            GameObject seller = GameObject.Find("Animator");
            GameObject hat = GameObject.Find("Hat");

            SpriteRenderer seller_sprite_renderer = seller.GetComponent<SpriteRenderer>();
            SpriteRenderer hat_sprite_renderer = hat.GetComponent<SpriteRenderer>();
            if (color_switch==2){
                seller_sprite_renderer.color = UnityEngine.Color.green;
                hat_sprite_renderer.color = UnityEngine.Color.green;}
            if (color_switch==1){
                seller_sprite_renderer.color = UnityEngine.Color.red;
                hat_sprite_renderer.color = UnityEngine.Color.red;}
            if (color_switch==0){
                seller_sprite_renderer.color = UnityEngine.Color.white;
                hat_sprite_renderer.color = UnityEngine.Color.white;}
            }
        }
    


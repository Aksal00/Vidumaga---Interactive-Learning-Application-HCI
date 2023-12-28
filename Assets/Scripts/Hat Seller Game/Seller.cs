using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Animator anim;
    
    [SerializeField] private float moveSpeed;
    private float xInput;
    private int facing_direction =1;
    private bool facingRight = true;
    
    [SerializeField] private bool IsMoving;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Check_Input();
        Movements();
        flip_controller();
        AnimatorControllers();
    }

    private void Check_Input()
    {
        xInput = Input.GetAxisRaw("Horizontal");
    }

    private void Movements()
    {
        rb.velocity = new Vector2(xInput * moveSpeed, rb.velocity.y);
    }

    private void AnimatorControllers()
    {
        
        if(rb.velocity.x != 0){
            IsMoving = true;
        }
        else{
            IsMoving = false;
        }
        anim.SetBool("IsMoving",IsMoving);  

    }
    private void flip()
    {
        facing_direction = facing_direction*-1;
        facingRight = !facingRight;
        transform.Rotate(0,180,0);
    }
    private void flip_controller()
    {
        if(rb.velocity.x>0 && !facingRight)
        {
            flip();
        }
        else if(rb.velocity.x<0 && facingRight)
        {
            flip();
        }
    }


}

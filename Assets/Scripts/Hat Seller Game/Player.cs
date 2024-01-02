using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    
    public Hat hat;
    public Motion motion;
    public GameObject PauseMenu;
    public GameObject Starting_Menu;

    private Transform pos;
    
    [SerializeField] private float moveSpeed;
    private float xInput;
    private int facing_direction =1;
    private bool facingRight = true;
    
    [SerializeField] private bool IsMoving;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pos = GetComponent<Transform>();
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
        //rb.velocity = new Vector2(xInput * moveSpeed, rb.velocity.y);
        if (!PauseMenu.activeSelf && !Starting_Menu.activeSelf && hat.no_of_chances>0)
        {   
            motion.anim.enabled = true;
            Vector3 Mouse_Position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Mouse_Position.z =0f;
            if (pos.position.x < (Mouse_Position.x-0.2))
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            }
            else if (pos.position.x > (Mouse_Position.x+0.2))
            {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
        else
        {
            motion.anim.enabled = false;
        }
    }

    private void AnimatorControllers()
    {
        
        if(rb.velocity.x != 0){
            IsMoving = true;
        }
        else{
            IsMoving = false;
        }
        motion.anim.SetBool("IsMoving",IsMoving);  

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

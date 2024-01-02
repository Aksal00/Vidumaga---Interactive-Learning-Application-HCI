using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Motion : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject Hat;

    public GameObject Seller;

    public Rigidbody2D rb1;

    public Rigidbody2D rb2;
    public Animator anim;

    void Start()
    {
        rb1 = Hat.GetComponent<Rigidbody2D>();
        rb2 = Seller.GetComponent<Rigidbody2D>();
        anim = Seller.GetComponentInChildren<Animator>();
    }

}

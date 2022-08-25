using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{

    public float fuerzaSalto=25;
    public float velocity = 10;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
         Debug.Log("Hola mundo");
        rb = GetComponent<Rigidbody2D>();
        sr= GetComponent<SpriteRenderer>();
        animator =GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
         rb.velocity = new Vector2(0, rb.velocity.y);
        animator.SetInteger("estadoRey",0);
        if(Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(2, rb.velocity.y);
            sr.flipX=false;
            animator.SetInteger("estadoRey",3);
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-2, rb.velocity.y);
            sr.flipX=true;
            animator.SetInteger("estadoRey",3);
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            rb.velocity =new Vector2(rb.velocity.x, 2);
            animator.SetInteger("estadoRey",2);
            rb.AddForce(new Vector2(0, fuerzaSalto),ForceMode2D.Impulse);
        }
        if (Input.GetKey("z")){
            animator.SetInteger("estadoRey",4);
        }
         if(Input.GetKey(KeyCode.RightArrow) && Input.GetKey("x"))
        {
            rb.velocity = new Vector2(5, rb.velocity.y);
            sr.flipX=false;
            animator.SetInteger("estadoRey",1);
        }
        if(Input.GetKey(KeyCode.LeftArrow)&& Input.GetKey("x"))
        {
            rb.velocity = new Vector2(-5, rb.velocity.y);
            sr.flipX=true;
            animator.SetInteger("estadoRey",1);
        }


        
    }
}

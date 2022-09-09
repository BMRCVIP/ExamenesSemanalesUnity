using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class movimiento2 : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject Bullet;

    //public TextMeshProUGUI vidaText;
    public int Vida =100;

    public float fuerzaSalto=40;
    public float velocity;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;
    const int ANIMATION_PARADO=0;
    const int ANIMATION_CORRER=1;
    const int ANIMATION_SALTAR=2;
    const int ANIMATION_CAMINAR=3;
    const int ANIMATION_ATAQUE=4;
    // Start is called before the first frame update
    //Triggers
    private Vector3 lastCheckPosition;
    void Start()
    {
         Debug.Log("Hola mundo");
        rb = GetComponent<Rigidbody2D>();
        sr= GetComponent<SpriteRenderer>();
        animator =GetComponent<Animator>();

        //vidaText ="Vida: "+Vida;
    }
    // Update is called once per frame
    void Update()
    {

         transform.eulerAngles = new Vector3(0, 180, 0);
            rb.velocity = new Vector2(-2, rb.velocity.y);
            sr.flipX=false;
            changeAnimation(ANIMATION_CAMINAR);

//No tocar
        //rb.velocity = new Vector2(0, rb.velocity.y);
       //changeAnimation(ANIMATION_PARADO);
        /*if(Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(2, rb.velocity.y);
            sr.flipX=false;
            changeAnimation(ANIMATION_CAMINAR);
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-2, rb.velocity.y);
            sr.flipX=true;
            changeAnimation(ANIMATION_CAMINAR);
        }
        
        if (Input.GetKey("z")){
            changeAnimation(ANIMATION_ATAQUE);
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
            changeAnimation(ANIMATION_CORRER);
        }
       else if(Input.GetKeyUp(KeyCode.Space))
        {
            rb.velocity =new Vector2(rb.velocity.x, 2);
            changeAnimation(ANIMATION_SALTAR);
            rb.AddForce(new Vector2(0, fuerzaSalto),ForceMode2D.Impulse);  

        } */
    }
   
    private void changeAnimation(int animation){
        animator.SetInteger("estadoRey",animation);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Puede saltar");
        if(other.gameObject.tag=="Enemy")
        {
            Debug.Log("Deberias estar muerto");       
        }
        if(other.gameObject.tag=="BaseMuerte"){
            if(lastCheckPosition!= null){
                transform.position=lastCheckPosition;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("trigger");
        lastCheckPosition =transform.position;
    }
}

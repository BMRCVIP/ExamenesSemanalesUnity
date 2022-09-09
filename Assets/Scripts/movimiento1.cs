using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movimiento1 : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject Bullet;

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
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("a"))
        {
            Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
        }

        transform.eulerAngles = new Vector3(0, 0, 0);
            rb.velocity = new Vector2(2, rb.velocity.y);
            sr.flipX=false;
            changeAnimation(ANIMATION_CAMINAR);


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

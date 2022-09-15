using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class movimiento : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject Bullet;

    //
    private GameManagerController gameManager;


    public AudioClip jumpClip;
    public AudioClip bulletClip;
    public AudioClip LeftArrowClip;
    public AudioClip RightArrowClip;
    public AudioClip UpArrowClip;
    public AudioClip DownArrowClip;

    AudioSource audioSource;

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
    const int ANIMATION_DESLIZAR=5;
    const int ANIMATION_ESCALAR=6;
    // Start is called before the first frame update
    //Triggers
    private Vector3 lastCheckPosition;
    void Start()
    {
         Debug.Log("Hola mundo");
        rb = GetComponent<Rigidbody2D>();
        sr= GetComponent<SpriteRenderer>();
        animator =GetComponent<Animator>();
        audioSource=GetComponent<AudioSource>();

        //vidaText ="Vida: "+Vida;
    }
    // Update is called once per frame
    void Update()
    {
        gameManager= FindObjectOfType<GameManagerController>();
        rb.velocity = new Vector2(0, rb.velocity.y);
       changeAnimation(ANIMATION_PARADO);
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            rb.velocity = new Vector2(2, rb.velocity.y);
            sr.flipX=false;
            changeAnimation(ANIMATION_CAMINAR);
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            rb.velocity = new Vector2(-2, rb.velocity.y);
            sr.flipX=false;
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
        if(Input.GetKeyDown("a"))
        {
            audioSource.PlayOneShot(bulletClip);
            Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            //audioSource.PlayOneShot(DownArrowClip);
            rb.velocity = new Vector2(4, rb.velocity.y);
            changeAnimation(ANIMATION_DESLIZAR);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //rb.velocity = new Vector2(2, 0);
            rb.velocity = new Vector2(rb.velocity.x, 2);
            changeAnimation(ANIMATION_ESCALAR);
            //AddForce es un metodo que se puede usar para aplicar una fuerza a un objeto
            rb.AddForce(new Vector2(0, fuerzaSalto));
        }
       else if(Input.GetKeyUp(KeyCode.Space))
        {
            audioSource.PlayOneShot(jumpClip);
            rb.velocity =new Vector2(rb.velocity.x, 2);
            changeAnimation(ANIMATION_SALTAR);
            rb.AddForce(new Vector2(0, fuerzaSalto),ForceMode2D.Impulse);  

        }

        //Para que el personaje se mueva solo
        /*transform.eulerAngles = new Vector3(0, 0, 0);
            rb.velocity = new Vector2(3, rb.velocity.y);
            sr.flipX=false;
            changeAnimation(ANIMATION_CORRER);

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            rb.velocity = new Vector2(-2, rb.velocity.y);
            sr.flipX=false;
            changeAnimation(ANIMATION_CAMINAR);
        }
        if (Input.GetKey("z")){
            changeAnimation(ANIMATION_ATAQUE);
        }
         if(Input.GetKey(KeyCode.RightArrow) && Input.GetKey("x"))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            rb.velocity = new Vector2(5, rb.velocity.y);
            sr.flipX=false;
            animator.SetInteger("estadoRey",1);
        }
        if(Input.GetKey(KeyCode.LeftArrow)&& Input.GetKey("x"))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            rb.velocity = new Vector2(-5, rb.velocity.y);
            sr.flipX=false;
            changeAnimation(ANIMATION_CORRER);
        }
       else if(Input.GetKeyUp(KeyCode.Space))
        {
            rb.velocity =new Vector2(rb.velocity.x, 2);
            changeAnimation(ANIMATION_SALTAR);
            rb.AddForce(new Vector2(0, fuerzaSalto),ForceMode2D.Impulse);  

        } */
//No tocar
        
    }
   
    private void changeAnimation(int animation){
        animator.SetInteger("estadoRey",animation);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Puede saltar");
        
        if(other.gameObject.tag=="piso")
        {
           
            Debug.Log("piso");        
        }
        if(other.gameObject.tag=="BaseMuerte")
        {
            if(lastCheckPosition!= null){
                transform.position=lastCheckPosition;
            }
        }
        if(other.gameObject.tag=="bronze")
        {
            audioSource.PlayOneShot(DownArrowClip);
            Destroy(other.gameObject);
            //
            gameManager.GanarPuntos(10);
            //guardar información
            gameManager.SaveGame();

        }
        if(other.gameObject.tag=="silver")
        {
            audioSource.PlayOneShot(DownArrowClip);
            Destroy(other.gameObject);
            //
            gameManager.GanarPuntos(20);
            //guardar información
            gameManager.SaveGame();

        }
         if(other.gameObject.tag=="gold")
        {
            audioSource.PlayOneShot(DownArrowClip);
            Destroy(other.gameObject);
            //
            gameManager.GanarPuntos(30);
            //guardar información
            gameManager.SaveGame();

        }
    }
    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("trigger");
        lastCheckPosition =transform.position;
    }
}

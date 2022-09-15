using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//El nombre del archivo deben ser iguales a los de la clase
public class movPersonaje : MonoBehaviour
{
    public float fuerzaSalto;
    public float velocity;
    //ESTO ES PARA LA BALA
     public Transform FirePoint, verificarpisoCalabaza;
    public GameObject Bullet;
    //es para el salto
    public float radioVer;
    public bool tocandoPiso=true;
    public LayerMask QueEsPiso;
    //
    private AudioSource SonidoSalto;
    private int Health=5;
    ///
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;
//para dewtectar ubicacion de trgger y regrearlo
    private Vector3 lastCheckPosition;

   //bool puedaSaltar=true;

    // Start is called before the first frame update
    void Start()
    {
        
        //debug.log es una funcion que se puede usar para imprimir en la consola del editor
         Debug.Log("Hola mundo");
        //metodo getcomponent para obtener el componente del objeto
        rb = GetComponent<Rigidbody2D>();
        //RigiBody2D es una clase que se puede usar para hacer movimientos de objetos
        sr= GetComponent<SpriteRenderer>();
        animator =GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
    

    
        rb.velocity = new Vector2(0, rb.velocity.y);
        animator.SetInteger("EstadoPersonaje",0);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            //rb.velocity = new Vector2(2, 0);
            rb.velocity = new Vector2(5, rb.velocity.y);
            //movimiendo de la imagen
            sr.flipX=false;
            animator.SetInteger("EstadoPersonaje",1);
            //mover 
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            //rb.velocity = new Vector2(2, 0);
            rb.velocity = new Vector2(-5, rb.velocity.y);
            //movimiento izquierda
            sr.flipX=false;
            animator.SetInteger("EstadoPersonaje",1);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //rb.velocity = new Vector2(2, 0);
            rb.velocity = new Vector2(rb.velocity.x, 2);
            animator.SetInteger("EstadoPersonaje",5);
            //AddForce es un metodo que se puede usar para aplicar una fuerza a un objeto
            rb.AddForce(new Vector2(0, fuerzaSalto));
        }
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            //rb.velocity = new Vector2(2, 0);
            rb.velocity = new Vector2(10, rb.velocity.y);
            animator.SetInteger("EstadoPersonaje",4);
        }
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            //rb.velocity = new Vector2(2, 0);
            rb.velocity = new Vector2(-10, rb.velocity.y);
            animator.SetInteger("EstadoPersonaje",4);
        }
        //metodo para detectar si el objeto colisiona con otro objeto
        /*if (Input.GetKeyDown(KeyCode.Space) && puedaSaltar)
        {
            //rb.velocity = new Vector2(2, 0);
            rb.velocity = new Vector2(rb.velocity.x, 2);
            animator.SetInteger("EstadoPersonaje",2);
            //AddForce es un metodo que se puede usar para aplicar una fuerza a un objeto
            rb.AddForce(new Vector2(0, fuerzaSalto));
            puedaSaltar=false;
        }*/
       /* if (Input.GetKeyUp(KeyCode.Space) && puedaSaltar)
        {
            //rb.velocity = new Vector2(2, 0);
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
            animator.SetInteger("EstadoPersonaje",2);
            //AddForce es un metodo que se puede usar para aplicar una fuerza a un objeto
            rb.AddForce(new Vector2(0, fuerzaSalto));
            puedaSaltar=false;
        }*/       
        if (Input.GetKeyDown(KeyCode.Space) && tocandoPiso==true){
            //rb.velocity = new Vector2(2, 0);
            transform.eulerAngles = new Vector3(0, 0, 0);
             rb.velocity = new Vector2(rb.velocity.x, 2);
            animator.SetInteger("EstadoPersonaje",2);
            //AddForce es un metodo que se puede usar para aplicar una fuerza a un objeto
            rb.AddForce(new Vector2(0, fuerzaSalto),ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown("x"))
        {

            Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
        }
    }

    //sobreescribir el metodo OnCollisionEnter2D para detectar si el objeto colisiona con otro objeto
  /*  void OnCollisionEnter2D(Collision2D other)
    //col es una variable que se puede usar para obtener informacion del objeto que colisiona con el objeto que tiene el script
    //other es una variable que se puede usar para obtener informacion del objeto que tiene el script    
    {
        if(other.gameObject.name=="Saquare1"||other.gameObject.name=="Circle")
        {
            animator.SetInteger("EstadoPersonaje",3);
        }
        Debug.Log("Colisiono con: " + other.gameObject.name);

    }*/
    //privTE VOID metodo crado por mi mismo

     void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Puede saltar");
        //puedaSaltar=false;

        if(other.gameObject.tag=="Enemy")
        {
            Debug.Log("Deberias estar muerto");       
        }

        /*if(other.gameObject.name=="Darkhole"){
            if(lastCheckPosition!= null){
                transform.position=lastCheckPosition;
            }

        }*/
        if(other.gameObject.tag=="Restaurar"){
            if(lastCheckPosition!= null){
                transform.position=lastCheckPosition;
            }

        }
    }

    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("trigger");
        lastCheckPosition =transform.position;
    }

    public void Hit()
    {
        Health = Health - 1;
        if(Health ==0) Destroy(gameObject);
    }
}
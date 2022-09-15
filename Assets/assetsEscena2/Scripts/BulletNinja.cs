using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletNinja : MonoBehaviour
{
    //
    public AudioClip Sound;
    private GameManagerController gameManager;
    Rigidbody2D MyRb;
    public float speed;
    //
    void Start()
    {
        MyRb = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
        Destroy(this.gameObject, 3f);
    }
    void Update()
    {
        gameManager= FindObjectOfType<GameManagerController>();
        MyRb.velocity = transform.right*speed;   
    }
    /*void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="Enemy")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            gameManager.GanarPuntos(1);
        }
    }*/

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        movPersonaje per = collision.collider.GetComponent<movPersonaje>();
        gruntMovimiento grunt = collision.collider.GetComponent<gruntMovimiento>();
        if (movPersonaje!=null)
        {
           movPersonaje.Hit();
        }
        if (grunt!=null)
        {
            grunt.Hit();
        }
    }*/
}

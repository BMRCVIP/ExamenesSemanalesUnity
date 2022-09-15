using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    //
    private GameManagerController gameManager;
    Rigidbody2D MyRb;
    public float speed;
    //
    void Start()
    {
        MyRb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 3f);
    }
    void Update()
    {
        gameManager= FindObjectOfType<GameManagerController>();
        MyRb.velocity = transform.right*speed;   
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(this.gameObject);
        /*if(other.gameObject.tag=="Enemy")
        {
            Destroy(other.gameObject);
            //
            gameManager.GanarPuntos(10);
            //guardar información
            gameManager.SaveGame();

        }*/
        if(other.gameObject.tag=="Enemy")
        {
            Destroy(other.gameObject);
            Debug.Log("Deberias estar muerto");
            gameManager.PerderVida();
        }
        
    }
}

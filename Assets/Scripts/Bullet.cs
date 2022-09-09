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
        if(other.gameObject.tag=="Enemy")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            gameManager.GanarPuntos(1);
        }
    }
}

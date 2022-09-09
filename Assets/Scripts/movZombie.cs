using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movZombie : MonoBehaviour
{

    public float fuerzaSalto=40;
    public float velocity;
    Rigidbody2D rb;
    
    Animator animator;
    const int ANIMATION_CORRER=1;


    // Start is called before the first frame update
    void Start()
    {
        rb =GetComponent<Rigidbody2D>();
        animator =GetComponent<Animator>();
        animator =GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(2, rb.velocity.y);
            changeAnimation(ANIMATION_CORRER);
        
    }
    private void changeAnimation(int animation){
        animator.SetInteger("estadoRey",animation);
    }
}

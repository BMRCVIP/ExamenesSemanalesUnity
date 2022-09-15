using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gruntMovimiento : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject movPersonaje, Bullet;
    private float LastShoot;
     public Transform FirePoint;
     private int Health=3;
    // Update is called once per frame
    void Update()
    {
        Vector3 direction = movPersonaje.transform.position - transform.position;
        if (direction.x > 0f)transform.localScale = new Vector3(11.18f,11.18f, 11.18f);
        else transform.localScale = new Vector3(-11.18f,11.18f,11.18f);



        float distance = Mathf.Abs(movPersonaje.transform.position.x - transform.position.x);
        if (distance < 20.18f && Time.time > LastShoot + 14.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }
    private void Shoot()
    {
        Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
        Debug.Log("Disparo");
       
    }
     public void Hit()
    {
        Health = Health - 1;
        if(Health ==0) Destroy(gameObject);
    }



}

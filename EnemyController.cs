using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;

    // Which way the enemy is going
    public Vector2 startDirection;

    public bool shouldChangeDirection;

    // point in space where the enemy ship change direction
    public float changeDirectionXPoint;

    // and if the enemy ship reach that point it will change to a different direction
    public Vector2 changedDirection;

    public GameObject shotToFire;
    public Transform firePoint; // Where we are going to launch the shots from
    public float timeBetweenShots; // How long we wait between shots
    private float shotCounter; // Count down between those shots

    public bool canShoot;
    private bool allowShooting;

    public int currentHealth;
    public GameObject deathEffect;

    // Start is called before the first frame update
    void Start()
    {
        shotCounter = timeBetweenShots;        
    }

    void Update()
    {
        //transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);        

        if(!shouldChangeDirection)
        {
            // Enemy movment (x,y,z)
            transform.position += new Vector3(startDirection.x * moveSpeed * Time.deltaTime, 
                                              startDirection.y * moveSpeed * Time.deltaTime, 
                                              0f);
        } else 
        {
            if(transform.position.x > changeDirectionXPoint)
            {
                transform.position += new Vector3(startDirection.x * moveSpeed * Time.deltaTime, 
                                                  startDirection.y * moveSpeed * Time.deltaTime, 
                                                  0f);
            } else 
            {
                transform.position += new Vector3(changedDirection.x * moveSpeed * Time.deltaTime, 
                                                  changedDirection.y * moveSpeed * Time.deltaTime, 
                                                  0f);
            }
        }
         if(allowShooting)
         {
            shotCounter -= Time.deltaTime;
            if(shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                Instantiate(shotToFire, firePoint.position, firePoint.rotation);
            }
         }
    }

    public void HurtEnemy()
    {
        currentHealth--;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
            Instantiate(deathEffect, transform.position, transform.rotation);
        }
    }
    // OnBecameInvisible() = Checking if the object has gone off the screen
    private void OnBecameInvisible()
    {
        // gameObject will be destroyed when the item becomes invisible
        Destroy(gameObject);
    }

    private void OnBecameVisible()
    {
        if(canShoot)
        {
            allowShooting = true;
        }
    }
}

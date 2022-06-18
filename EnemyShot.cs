using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public float shotSpeed = 7f;
    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.position -= new Vector3(shotSpeed * Time.deltaTime, 0f, 0f);
    }

    /* 
    OnTriggerEnter2D = Player shots
    Collider2D = Trigger is entering an another trigger (Circle collider for the meteor = other)
    */
    private void OnTriggerEnter2D(Collider2D other)
    {
        // transform.position, rotation = The position of the player shot
        Instantiate(impactEffect, transform.position, transform.rotation);
        
        if(other.tag == "Player")
        {
            HealthManager.instance.HurtPlayer();
        }

        // this = This scripts (GameObject that is attached to this script)
        Destroy(this.gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}


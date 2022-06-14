using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D theRB;

    public Transform bottomLeftLimit, topRightLimit;

    // Position of the player shots
    public Transform shotPoint;
    // Object that will duplicate
    public GameObject shot;

    public float timeBetweenShots = .1f;
    private float shotCounter;

    // Start is called before the first frame update (This will start as soons as the game starts)
    void Start()
    {
        
    }

    // Update is called once per frame (It happens repeatedly over and over again 
    // 60fpx: Update will happen 60times per sec)
    void Update()
    {
        /* 
            new Vector2 = A variable that can have a x & y value
            x = Input.GetAxisRaw("Horizontal") 
            Input = Default input system (Player presses a key)
            GetAxisRaw("Horizontal") = Unity's default axies (Move left and right) if a player 
            presses a button like a or d it gives a # to represnet that(left -1, right +1)
            y = Input.GetAxisRaw("Vertical") 
        */
       theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;
        /* 
            new Vector3 = z,y and x 
        */
       transform.position = new Vector3(
           Mathf.Clamp(transform.position.x, bottomLeftLimit.position.x, topRightLimit.position.x),
           Mathf.Clamp(transform.position.y, bottomLeftLimit.position.y, topRightLimit.position.y),
           transform.position.z);

        /*
            GetButtonDown = Check if the button is being pressed
            Fire1 = Default setting that is built in unity
        */  
       if(Input.GetButtonDown("Fire1"))
       {
           Instantiate(shot, shotPoint.position, shotPoint.rotation);

           shotCounter = timeBetweenShots;
       }

        /*
            GetButton = holding the button
        */
       if(Input.GetButton("Fire1"))
       {
           // Time.deltaTime = Is how long it takes to go from one frame to the next(How long has it been since the last update was called)
           shotCounter -= Time.deltaTime;
           if(shotCounter <= 0)
           {
               Instantiate(shot, shotPoint.position, shotPoint.rotation);
               // reset the timer
               shotCounter = timeBetweenShots;
           }
       }


    }
}

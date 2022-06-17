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

    // Start is called before the first frame update
    void Start()
    {
        
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

    }

    // OnBecameInvisible() = Checking if the object has gone off the screen
    private void OnBecameInvisible()
    {
        // gameObject will be destroyed when the item becomes invisible
        Destroy(gameObject);
    }
}

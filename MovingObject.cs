using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);        
    }

    // OnBecameInvisible() = Checking if the object has gone off the screen
    private void OnBecameInvisible()
    {
        // gameObject will be destroyed when the item becomes invisible
        Destroy(gameObject);
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            // go to the generic HealthManager script and look at the instance 
            // and run any functions that I have inside or access any of the variables
           HealthManager.instance.HurtPlayer(); 
        }
    }
}

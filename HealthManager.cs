using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    /*
        static = If there is multiple Healthmanager scripts every single copy of the scripts will have the same thing filled in here 
        one change will change all of it
    */
    public static HealthManager instance;

    // Keep track how much health I have in game
    public int currentHealth;
    // Starting health
    public int maxHealth;

    // What we bring in to the world when the player dies;
    public GameObject deathEffect;

    // Called when the object is activated, Awake is activated before Start
    private void Awake()
    {
        // Static instance will be set to this version of the script
        instance = this;

    }

    // Start is called before the first frame update, called when the object is brought into the screen
    void Start()
    {
        // When the game starts 
        currentHealth = maxHealth;
    }

    // Update is called once per frame, updated every frame
    void Update()
    {
        
    }

    /*
        For example when we meteor hit a player call this HurtPlayer function
    */
    public void HurtPlayer()
    {
        currentHealth--;

        if(currentHealth <= 0)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
            // Make the player disapear, rather than distroying our ship, Deactivating the object
            gameObject.SetActive(false);
        }
    }
}

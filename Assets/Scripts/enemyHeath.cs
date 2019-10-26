using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHeath : MonoBehaviour
{
    public float enemyMaxHealth;

    float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = enemyMaxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //allows other objects to effect enemy health
    public void addDamage (float damage)
    {
        currentHealth = currentHealth - damage;
        if (currentHealth <= 0) makeDead();
    }

    //kills the enemy
    void makeDead()
    {
        Destroy(gameObject);
    }
}

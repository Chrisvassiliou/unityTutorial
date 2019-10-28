using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float fullHealth;
    public GameObject deathFX;

    float currentHealth;
    playerController moveControl;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = fullHealth;
        moveControl = GetComponent<playerController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addDamage (float damage)
    {
        if(damage<=0)
        {
            return;
        }
        currentHealth = currentHealth - damage;

        if(currentHealth<=0)
        {
            makeDead();
        }
    }

    public void makeDead()
    {
        Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}

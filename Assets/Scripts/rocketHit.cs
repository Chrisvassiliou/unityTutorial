using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketHit : MonoBehaviour
{

    public float weaponDamage;

    projectileController myPC;

    public GameObject explosionEffect;

    // Start is called before the first frame update
    void Awake()
    {
        myPC = GetComponentInParent<projectileController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //when triggered, starts explosion effects, stops projectile movement
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            myPC.removeForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if(collision.tag == "Enemy")
            {
                enemyHeath hurtEnemy = collision.gameObject.GetComponent<enemyHeath>();
                hurtEnemy.addDamage(weaponDamage);
            }
        }
    }

    //in case it misses initial contact
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            myPC.removeForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if(collision.tag == "Enemy")
            {
                enemyHeath hurtEnemy = collision.gameObject.GetComponent<enemyHeath>();
                hurtEnemy.addDamage(weaponDamage);
            }
        }
    }
}

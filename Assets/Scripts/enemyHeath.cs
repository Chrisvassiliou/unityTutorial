using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHeath : MonoBehaviour
{
    public float enemyMaxHealth;
    public GameObject deathFX;
    public Slider enemySlider;

    float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = enemyMaxHealth;
        enemySlider.maxValue = currentHealth;
        enemySlider.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //allows other objects to effect enemy health
    public void addDamage (float damage)
    {
        enemySlider.gameObject.SetActive(true);

        currentHealth = currentHealth - damage;

        enemySlider.value = currentHealth;
        if (currentHealth <= 0) makeDead();

    }

    //kills the enemy
    void makeDead()
    {
        Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}

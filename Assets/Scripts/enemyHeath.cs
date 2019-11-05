using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHeath : MonoBehaviour
{
    public float enemyMaxHealth;
    public GameObject deathFX;
    public Slider enemySlider;
    public AudioClip enemyDeathSound;

    //health drops
    public bool drops;
    public GameObject theDrop;

    float currentHealth;

    AudioSource enemyAS;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = enemyMaxHealth;
        enemySlider.maxValue = currentHealth;
        enemySlider.value = currentHealth;

        enemyAS = GetComponent<AudioSource>();
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

        //how to get this noise to play when enemy dies? 
            
        enemySlider.value = currentHealth;
        if (currentHealth <= 0)
        {

            GameObject enemyDeathSoundObj = new GameObject("Death sound");
            enemyDeathSoundObj.AddComponent<AudioSource>();
            AudioSource deathAS = enemyDeathSoundObj.GetComponent<AudioSource>();
            deathAS.PlayOneShot(enemyDeathSound);
            
            makeDead();
        }
    }

    //kills the enemy
    void makeDead()
    {
        Instantiate(deathFX, transform.position, transform.rotation);

        Destroy(gameObject);
        Destroy(transform.parent.gameObject);

        //drops appearing
        if (drops == true)
        {
            Instantiate(theDrop, transform.position, transform.rotation);
        }
    }
}

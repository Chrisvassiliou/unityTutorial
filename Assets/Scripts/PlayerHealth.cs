﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float fullHealth;
    public GameObject deathFX;
    public AudioClip playerHurtSound;
    public AudioClip playerHealSound;
    

    float currentHealth;
    playerController moveControl;

    AudioSource playerAS;
    
    //HUD variables
    //have to add ui library up top!
    public Slider healthSlider;
    public Image damageImage;
    public Text gameOverScreen;
    public restartGame gameManager;
    public Text winGameScreen;

    //for blood screen. uses lurp, same effect as for smoothing the camera.
    bool damaged;
    Color damagedColor = new Color(0f, 0f, 0f, 0.5f);
    float smoothColor = 5f;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = fullHealth;
        moveControl = GetComponent<playerController>();

        //HUD initialisation
        healthSlider.maxValue = fullHealth;
        healthSlider.value = fullHealth;

        damaged = false;
        playerAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //this if checks for damage, displays the damage screen, and then slowly transitions from theat image back to clear.
        if(damaged)
        {
            damageImage.color = damagedColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, smoothColor * Time.deltaTime);
        }
        damaged = false;
    }

    public void addDamage (float damage)
    {
        if(damage<=0)
        {
            return;
        }
        currentHealth = currentHealth - damage;

        //first option to call player grunting sound on damage
        playerAS.clip = playerHurtSound;
        playerAS.Play();

        //second option for sounds
        // playerAS.PlayOneShot(playerHurtSound);
        healthSlider.value = currentHealth;
        damaged = true;

        if(currentHealth<=0)
        {
            //you can't use the player object to make the death noise - make a new object and destroy it
            
            
            makeDead();
        }
    }

    public void addHealth(float healthAmount)
    {
        //add health + health sound
        currentHealth += healthAmount;
        if (currentHealth > fullHealth)
        {
            currentHealth = fullHealth;
            
        }
        healthSlider.value = currentHealth;
        playerAS.clip = playerHealSound;
        playerAS.Play();
    }

    public void makeDead()
    {
        //death sounds and destroy player
        GameObject PlayerDeathSoundObj = new GameObject("Death sound");
        PlayerDeathSoundObj.AddComponent<AudioSource>();
        AudioSource deathAS = PlayerDeathSoundObj.GetComponent<AudioSource>();
        deathAS.PlayOneShot(playerHurtSound);
        Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);
        damageImage.color = damagedColor;

        //death screen and game over screen
        Animator gameOverAnim = gameOverScreen.GetComponent<Animator>();
        gameOverAnim.SetTrigger("gameOver");
        gameManager.restartTheGame();
    }

    public void winGame()
    {
        Destroy(gameObject);
        gameManager.restartTheGame();
        Animator winGameAnim = winGameScreen.GetComponent<Animator>();
        winGameAnim.SetTrigger("gameOver");
    }
}

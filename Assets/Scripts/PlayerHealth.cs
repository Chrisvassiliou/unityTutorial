using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float fullHealth;
    public GameObject deathFX;

    float currentHealth;
    playerController moveControl;

    //HUD variables
    //have to add ui library up top!
    public Slider healthSlider;
    public Image damageImage;

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
        healthSlider.value = currentHealth;
        damaged = true;

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

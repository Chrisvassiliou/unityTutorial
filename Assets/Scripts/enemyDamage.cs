using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    //damage enemy does and how long between damage
    public float damage;
    public float damageRate;
    //player gets pushed back when hitting enemy
    public float pushBackForce;

    //next time damage can occur
    float nextDamage;


    // Start is called before the first frame update
    void Start()
    {
        nextDamage = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //makes player take damage when they stay inside the collider
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag=="Player" && nextDamage<Time.time)
        {
            PlayerHealth pHealth = other.gameObject.GetComponent<PlayerHealth>();
            pHealth.addDamage(damage);
            nextDamage = Time.time + damageRate;

            pushBack(other.transform);
        }
    }

    //will push character in a specific direction. could use forces but this is the code way.
    //pass in character object, push away  from pushing object in y direction with a vector, multiply vector by 1, find rigidbody, set velocity to 0, add force in y direction
    void pushBack(Transform pushedObject)
    {
        Vector2 pushDirection = new Vector2(0, (pushedObject.position.y - transform.position.y)).normalized;
        pushDirection *= pushBackForce;
        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
    }
}

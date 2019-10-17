using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //movement variables
    public float maxSpeed;

    //jumping variables
    bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

    Rigidbody2D myRB;
    Animator myAnim;
    bool facingRight;

    //shooting variables
    public Transform gunTip;
    public GameObject missile;
    float shotSpeed = 0.5f;
    float nextShot = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //initialise animator and rigidbody components
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        facingRight = true;
    }

    void Update()
    {
        //check if grounded
        if (grounded && Input.GetAxis("Jump")>0)
        {
            myAnim.SetBool("grounded", grounded );
            myRB.AddForce(new Vector2(0, jumpHeight)); 
        }

        //player shooting
        if (Input.GetAxisRaw("Fire1") > 0) fireRocket();

    }
    // Update is called once per frame
    // fixed update makes sure physics engine works properly
    void FixedUpdate()
    {
        //check if grounded using variables and little circle. if not grounded, then falling
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        myAnim.SetBool("grounded", grounded);

        //jumping code
        myAnim.SetFloat("verticalSpeed", myRB.velocity.y);

        //make character move by checking if player is pressing horizontal buttons
        float move = Input.GetAxis("Horizontal");

        //set animation speed value to move value
        myAnim.SetFloat("speed", Mathf.Abs(move));
        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);

        //decides when to flip the character
        if (move > 0 && !facingRight)
        {
            flip();
        }
        else if (move<0&&facingRight)
        {
            flip();
        }

    }

    //flip the character when called
    void flip()
    {
        facingRight = !facingRight;
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }

    void fireRocket()
    {
        if(Time.time > nextShot)
        {
            nextShot = Time.time + shotSpeed;
            if(facingRight)
            {
                Instantiate(missile, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if(!facingRight)
            {
                Instantiate(missile, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
            }
        }
    }
}

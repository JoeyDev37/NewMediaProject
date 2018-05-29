using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Player Controller will hold anything that has to do with the movement / speed variables for the player.

    
    [SerializeField] private int currentSpeed; //Player movement speed
    [SerializeField] private float boostSlowDuration; //Boost/Slow duration time

    private Rigidbody2D RB2D;
    [SerializeField] private float boostSlowCountdownTimer; //Boost/Slow timer

    private bool boostedOrSlowed = false;


    private float horizontalVelocity;
    private float verticalVelocity;


    public int defaultSpeed;

    private void Start()
    {
        //Initialize Variables
        RB2D = GetComponent<Rigidbody2D>();

        boostSlowCountdownTimer = boostSlowDuration;
        currentSpeed = defaultSpeed;

    }

    void FixedUpdate()
    {
        //Checks if the player is boosted or slowed
        if(boostedOrSlowed == true)
        {
            BoostSlowCountdown();
        }

        Move();
	}


    /* For if we want to add boosts or slows */
    // Sounded Cool so I did it - Colton
    public void ChangeSpeed(int newSpeed)
    {
        currentSpeed = newSpeed;
        boostedOrSlowed = true;
    }

    public void BoostSlowCountdown()
    { 
        //Decrements the time the player is boosted or slowed
        boostSlowCountdownTimer -= Time.deltaTime;

        //If the timer is less than 0 then we want to reset our speed and the timer and change the boostedSlowed bool to false;
        if(boostSlowCountdownTimer < 0)
        {
            boostSlowCountdownTimer = boostSlowDuration;
            boostedOrSlowed = false;
            currentSpeed = defaultSpeed;
        }
    }
    
    private void Move()
    {

        //Colton - Replacing transform.translate to use Unity's physics system with rigidbody2d. However, if you would like to create your own collision system, feel free to do that
        //Kinda just being lazy and letting Unity do the work :U If you have any questions feel free to DM me on Discord

        /*
        if(Input.GetKey("w"))
        {
            transform.Translate(0, currentSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(0, -currentSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(-currentSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(currentSpeed * Time.deltaTime, 0, 0);
        }
        */


        horizontalVelocity = Input.GetAxisRaw("Horizontal");
        verticalVelocity = Input.GetAxisRaw("Vertical");

        Vector2 moveVector = new Vector2(horizontalVelocity, verticalVelocity) * currentSpeed;

        RB2D.velocity = moveVector;
    }

}

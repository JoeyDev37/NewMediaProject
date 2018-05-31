using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedChangers : MonoBehaviour {
    //Handles anything to do with the powerups that relate to changing the speed of the player via the playercontroller.cs

    public PlayerController PlayerController;

    public int speedUpSpeed;
    public int slowDownSpeed;

    //The variable that is sent into the PlayerController.ChangeSpeed when collided witht he Player
    private int changeSpeed;

	// Use this for initialization
	void Start () {

        speedUpSpeed = PlayerController.defaultSpeed * 2;
        slowDownSpeed = PlayerController.defaultSpeed / 2;


        //Sets the changespeed variable
		if(transform.tag == "SpeedBoost")
        {
            changeSpeed = speedUpSpeed;
        }
        else if(transform.tag == "SlowDown")
        {
            changeSpeed = slowDownSpeed;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            PlayerController.ChangeSpeed(changeSpeed);
            Destroy(gameObject);
        }
    }
}

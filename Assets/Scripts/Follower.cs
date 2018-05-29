using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour {

    //Follower script, handles anything to do with the follower

    public int happinessValue;

    private bool isFollowerOfPlayer;
    private PlayerStats PlayerStats;

    public GameObject FollowersList;

	// Use this for initialization
	void Start () {
        happinessValue = 1;
	}
	

    //TODO Have the followers follow the player
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            if(isFollowerOfPlayer == false)
            {
                PlayerStats = collision.gameObject.GetComponent<PlayerStats>();

                PlayerStats.IncrementHappiness(happinessValue);

                isFollowerOfPlayer = true;
            }
        }
    }
}

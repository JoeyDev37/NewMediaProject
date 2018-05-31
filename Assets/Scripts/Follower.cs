using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour {

    //Follower script, handles anything to do with the follower
    
    public int happinessValue;

    private bool isFollowerOfPlayer;
    private PlayerStats PlayerStats;

    public GameObject FollowersList;

    private StateMachine stateMachine;

    private Transform player;
    private TextMesh text;

    void Awake()
    {
        stateMachine = new StateMachine();
        text = transform.gameObject.GetComponentInChildren<TextMesh>();

        if (text == null)
            Debug.Log("REACHED");
    }

	// Use this for initialization
	void Start ()
    {
        happinessValue = 1;
        stateMachine.ChangeState(new IdleState(text));
	}
	

    //TODO Have the followers follow the player
	// Update is called once per frame
	void Update ()
    {
        float distanceFromPlayer = 0f;

        if(player != null)
            distanceFromPlayer = Vector3.Distance(transform.position, player.position);

        if(distanceFromPlayer > 1f) //Don't continue to move if close to the player
            stateMachine.ExecuteStateUpdate();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            if(isFollowerOfPlayer == false) //Checks if the friend is already following the player
            {
                player = collision.transform;

                PlayerStats = collision.gameObject.GetComponent<PlayerStats>();

                PlayerStats.IncrementHappiness(happinessValue);

                isFollowerOfPlayer = true;

                stateMachine.ChangeState(new FollowingState(transform.gameObject, collision, text));
            }
        }
    }
}

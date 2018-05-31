using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKiller : MonoBehaviour {
    public PlayerStats PlayerStats;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the player has all possible followers then he is ready to extract.
        if (collision.transform.tag == "Player")
        {
            PlayerStats = collision.gameObject.GetComponent<PlayerStats>();

            PlayerStats.ResetPosition();
        }
    }
}

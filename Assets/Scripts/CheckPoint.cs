using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    public PlayerStats PlayerStats;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            PlayerStats = collision.gameObject.GetComponent<PlayerStats>();

            PlayerStats.SpawnArea.transform.localPosition = transform.position - new Vector3(0, 0, 3.5f);
            

        }
    }
}

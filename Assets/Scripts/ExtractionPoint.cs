using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ExtractionPoint : MonoBehaviour {

    public float extractionTime = 5f;
    public float extractionTimeCountdown;

    public bool canExtract;

    public PlayerStats PlayerStats;

	// Use this for initialization
	void Start () {
        extractionTimeCountdown = extractionTime;
	}
	
	// Update is called once per frame
	void Update () {
        //The countdown timer starts
        if (canExtract)
        {
            extractionTimeCountdown -= Time.deltaTime;
        }
        //Go to the endgame menu
        if(extractionTimeCountdown < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the player has all possible followers then he is ready to extract.
        if (collision.transform.tag == "Player")
        {
            PlayerStats = collision.gameObject.GetComponent<PlayerStats>();

            if(PlayerStats.HappinessSlider.value == PlayerStats.HappinessSlider.maxValue)
            {
                canExtract = true;
            }
        }
    }
}

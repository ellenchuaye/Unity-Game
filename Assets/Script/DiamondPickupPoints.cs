using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondPickupPoints : MonoBehaviour {

    private PlayerController playerControl;
    private AudioSource fairySound;
    public int scoreToGive;
    private ScoreManager theScoreManager;

    // Use this for initialization
    void Start () {
        
        playerControl = FindObjectOfType<PlayerController>();
        theScoreManager = FindObjectOfType<ScoreManager>();
        fairySound = GameObject.Find("FairyDustSound").GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            theScoreManager.AddScore(scoreToGive);
            gameObject.SetActive(false);
            playerControl.ifBoosted();
            fairySound.Play();
           

        }
    }
}

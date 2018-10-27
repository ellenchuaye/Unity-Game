using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HwdPickupPoints : MonoBehaviour {

    public int scoreToGive;

    private ScoreManager theScoreManager;

    private AudioSource teleportSound;

    // Use this for initialization
    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
        teleportSound = GameObject.Find("TeleportSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            theScoreManager.AddScore(scoreToGive);
            gameObject.SetActive(false);
            teleportSound.Play();

        }
    }
}


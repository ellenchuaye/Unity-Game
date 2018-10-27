using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;
    public CameraController camControl;
    private Vector3 camStartPoint;

    private PlatformDestroyer[] platformList;

    private ScoreManager theScoreManager;//only one

    public DeathMenu theDeathScreen;

    public GameObject pauseMenu;

    public AudioSource inGame;

    public GameObject[] starfish;

    // Use this for initialization
    void Start () {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;
        camStartPoint = camControl.transform.position;

        theScoreManager = FindObjectOfType<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RestartGame()// so can be called from another script
    {
        //StartCoroutine("RestartGameCo");
        theScoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);
        pauseMenu.SetActive(false);

        theDeathScreen.gameObject.SetActive(true);
    }

    public void Reset()
    {
        theDeathScreen.gameObject.SetActive(false);
        camControl.reset();
        for (int i = 0; i < starfish.Length; i++)
        {
            starfish[i].SetActive(true);
        }
        platformList = FindObjectsOfType<PlatformDestroyer>(); //delete platformdestroyer for first few platforms so it will be permanently there
                                                               // all other platforms will have platformdestroyer script. Find em. delete em to prevent duplicates and mass of platforms.
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        camControl.transform.position = camStartPoint;
        thePlayer.gameObject.SetActive(true);
        pauseMenu.SetActive(true);
        inGame.Play();


        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
    }

   /* public IEnumerator RestartGameCo()//co-routine
    {
        theScoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f); //adding delay; half a second
        platformList = FindObjectsOfType <PlatformDestroyer>(); //delete platformdestroyer for first few platforms so it will be permanently there
                                                                // all other platforms will have platformdestroyer script. Find em. delete em to prevent duplicates and mass of platforms.
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        camControl.transform.position = camStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
    }*/

}

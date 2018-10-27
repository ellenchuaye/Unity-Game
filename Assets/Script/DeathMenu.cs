using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour {

    public string mainMenuLevel;

    public AudioSource deathSound;
    

    public void RestartGame()
    {
        FindObjectOfType<GameManager>().Reset();
        deathSound.Stop();
    }
    public void QuitToMain()
    {
        Application.LoadLevel(mainMenuLevel);
        deathSound.Stop();
    }

}

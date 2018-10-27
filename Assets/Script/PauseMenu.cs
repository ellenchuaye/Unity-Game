using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public string mainMenuLevel;

    public GameObject pauseMenu;

    public CameraController camControl;

    public void RestartGame()
    {
        Time.timeScale = 1f;
        FindObjectOfType<GameManager>().Reset();
        pauseMenu.SetActive(false);
        gameObject.SetActive(true);
    }
    public void QuitToMain()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(mainMenuLevel);
    }
    public void PauseGame()
    {
        Time.timeScale = 0f; //default is 1f (normal). 0 means wont move at all
        pauseMenu.SetActive(true);
        camControl.stop();
        gameObject.SetActive(false);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        camControl.resume();
        gameObject.SetActive(true);
    }
}

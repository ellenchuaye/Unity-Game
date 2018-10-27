using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public string playGameLevel;

    public GameObject tip;

    public void PlayGame()
    {
        StartCoroutine("PlayGameCo");
    }


    public IEnumerator PlayGameCo()
    {
        tip.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Application.LoadLevel(playGameLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame()
    {
        //Gets the next scene in the build settings
        SceneManager.LoadScene(1);

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

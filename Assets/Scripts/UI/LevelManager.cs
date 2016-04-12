using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

    // UI elements to enable / disable for later use.
    public GameObject CreditsUI;
	// MainMenu Ui
    // load level 1
    public void StartLevel(int Scene)
    {
        SceneManager.LoadScene(Scene);
    }

    
    public void CreditsShow(bool value)
    {
        if(value)
        {
            CreditsUI.SetActive(true);
        }
        else
        {
            CreditsUI.SetActive(false);
        }
    }
	// quit game
	public void QuitGame()
	{
		Application.Quit();
	}
	//End Screen
    // Restart the game ( load scene 1 )
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
	public void EndScreen()
	{
		SceneManager.LoadScene(2);
	}
}

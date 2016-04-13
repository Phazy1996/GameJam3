using UnityEngine;
using UnityEngine.SceneManagement;

using System.Collections;

public class LevelManager : MonoBehaviour {

    // UI elements to enable / disable for later use.
    [SerializeField]
    GameObject CreditsUI;
    [SerializeField]
    GameObject EndScreenUI;
    [SerializeField]
    GameObject PlayButton;
    [SerializeField]
    GameObject CreditsButton;
    [SerializeField]
    GameObject QuitButton;
    [SerializeField]
    GameObject GameTitle;

    bool PauzeEnabled = false;

    XInput xinput;

    void Start()
    {
        EndScreenUI.SetActive(false);
        xinput = GetComponent<XInput>();
    }

	// MainMenu Ui
    // load level 1

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauzeScreenEnabled();
        }
        if(PauzeEnabled)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PauzeScreenDisabled();
                
            }
        }
    }

    public void StartLevel(int Scene)
    {
        SceneManager.LoadScene(Scene);
    }

    
    public void CreditsShow(bool value)
    {
        if(value)
        {
            CreditsUI.SetActive(true);
            PlayButton.SetActive(false);
            CreditsButton.SetActive(false);
            QuitButton.SetActive(false);
            GameTitle.SetActive(false);
        }
        else
        {
            CreditsUI.SetActive(false);
            PlayButton.SetActive(true);
            CreditsButton.SetActive(true);
            QuitButton.SetActive(true);
            GameTitle.SetActive(true);
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
        Time.timeScale = 1;
        SceneManager.LoadScene(3);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void EndScreen()
    {
        SceneManager.LoadScene(2);
    }
	public void PauzeScreenEnabled()
	{
        if(Application.loadedLevel == 3)
        {
            EndScreenUI.SetActive(true);
            Time.timeScale = 0;
            PauzeEnabled = true;
        }

        
	}

    public void PauzeScreenDisabled()
    {
        EndScreenUI.SetActive(false);
        Time.timeScale = 1;
        PauzeEnabled = false;
    }
}

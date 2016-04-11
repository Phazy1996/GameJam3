using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {


    public GameObject CreditsUI;
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
    public void QuitGame()
    {
        Application.Quit();
    }
}

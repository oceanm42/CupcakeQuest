using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public GameObject howToPlayUI;

    public void Play()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void HowToPlay()
    {
        howToPlayUI.SetActive(true);
    }

    public void CloseHowToPlay()
    {
        howToPlayUI.SetActive(false);
    }
}

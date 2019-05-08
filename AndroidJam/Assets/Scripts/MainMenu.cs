using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartPresentation()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void CreditMenu()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings-1);
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }

}

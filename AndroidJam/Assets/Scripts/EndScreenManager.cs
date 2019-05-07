using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenManager : MonoBehaviour
{
    public void OpenFacebook()
    {
        Application.OpenURL("https://www.facebook.com/StudioDeLaPie");

    }

    public void OpenTwitter()
    {
        Application.OpenURL("https://twitter.com/StudioDeLaPie");
    }

    public void OpenItch()
    {
        Application.OpenURL("https://studio-de-la-pie.itch.io/");
    }

    public void GoBackMenu()
    {
        SceneManager.LoadScene(0);
    }
}

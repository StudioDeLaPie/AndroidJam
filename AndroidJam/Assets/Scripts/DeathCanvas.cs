using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCanvas : MonoBehaviour
{
    public void RetourMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Rejouer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

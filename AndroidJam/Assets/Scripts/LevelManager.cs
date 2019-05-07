using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int nbPiecesTotal;
    public int nbPiecesCollected = 0;
    public UpdaterUI updaterUI;

    // Start is called before the first frame update
    void Start()
    {
        nbPiecesTotal = GameObject.FindGameObjectsWithTag("Piece").Length;
        updaterUI.Init(this);
    }

    public void IncreasePieceCount()
    {
        nbPiecesCollected++;
        updaterUI.UpdatePieceCount();
        if (nbPiecesCollected >= nbPiecesTotal)
            GetComponent<PlayableDirector>().Play();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

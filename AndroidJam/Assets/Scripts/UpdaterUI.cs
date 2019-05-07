using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdaterUI : MonoBehaviour
{
    public Player player;

    public TextMeshProUGUI UI_Oxygen;
    public TextMeshProUGUI UI_Life;
    public Button pieceReparation;

    private void Start()
    {
        pieceReparation.interactable = false;
    }

    void Update()
    {
        UI_Oxygen.text = player.Oxygen.ToString("000.0");
        UI_Life.text = player.Life.ToString("000.0");
    }

    public void PieceReparationUI(bool havePiece)
    {
        pieceReparation.interactable = havePiece;
    }
}

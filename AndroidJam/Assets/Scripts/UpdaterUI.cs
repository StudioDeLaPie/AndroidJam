using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdaterUI : MonoBehaviour
{
    public Player player;

    public Slider slider_Oxygen;
    public Slider slider_Life;
    public Button pieceReparation;

    private void Start()
    {
        pieceReparation.interactable = false;
        slider_Oxygen.maxValue = player.maxOxygen;
        slider_Life.maxValue = player.maxLife;
    }

    void Update()
    {
        slider_Oxygen.value = player.Oxygen;
        slider_Life.value = player.Life;
    }

    public void PieceReparationUI(bool havePiece)
    {
        pieceReparation.interactable = havePiece;
    }
}

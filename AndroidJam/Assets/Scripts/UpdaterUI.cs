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
    public Slider sliderPieces;
    public TextMeshProUGUI textPieces;
    public Button imgPieceReparation;
    public LevelManager level;


    public void Init(LevelManager _level)
    {
        imgPieceReparation.interactable = false;
        slider_Oxygen.maxValue = player.maxOxygen;
        slider_Life.maxValue = player.maxLife;

        level = _level;

        sliderPieces.maxValue = level.nbPiecesTotal;
        UpdatePieceCount();
    }

    void Update()
    {
        slider_Oxygen.value = player.Oxygen;
        slider_Life.value = player.Life;

    }

    public void PieceReparationUI(bool havePiece)
    {
        imgPieceReparation.interactable = havePiece;
    }

    public void UpdatePieceCount()
    {
        sliderPieces.value = level.nbPiecesCollected;
        textPieces.text = level.nbPiecesCollected + " / " + level.nbPiecesTotal;
    }
}

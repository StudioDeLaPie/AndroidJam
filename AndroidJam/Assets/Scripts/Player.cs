using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float oxygen;
    public float maxOxygen;
    private float life;
    public float maxLife;

    public float oxygenLost = 0.1f;
    public float oxygenGain = 0.5f;
    public float lifeLost = 0.2f;

    public Animator animator;

    public UpdaterUI UpdaterUI;

    private bool inRespiration = false;

    private bool isBreathableEnvironement;


    public bool pieceReparation = false;

    private void Start()
    {
        oxygen = maxOxygen;
        life = maxLife;
    }

    void Update()
    {
        DecreaseOxygen();
        inRespiration = false;

    }

    public void IncreaseOxygen()
    {
        oxygen = Mathf.Clamp(oxygen + oxygenGain, 0, maxOxygen);
    }

    public void DecreaseOxygen()
    {
        if (!inRespiration)
        {
            oxygen -= oxygenLost;
            if (oxygen < 0)
            {
                oxygen = 0;
                DecreaseLife();
            }
        }
    }

    public void DecreaseLife()
    {
        life -= lifeLost;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Respiration()
    {
        inRespiration = true;

        if (isBreathableEnvironement)//Si je suis dans une zone d'oxygen
        {
            IncreaseOxygen();
        }
        else
        {
            DecreaseLife();
        }
    }

    public bool TakePieceReparation()
    {
        if (pieceReparation)
        {
            return false; //Le joueur a deja une pièce
        }
        else//Si le joueur n'a pas de pièce
        {
            pieceReparation = true;
            UpdaterUI.PieceReparationUI(true);
            return true; //C'est bon le player a récupéré la pièce
        }

    }

    public void lossPieceReparation()
    {
        pieceReparation = false;
        UpdaterUI.PieceReparationUI(false);
    }


    public float Oxygen { get => oxygen; set => oxygen = value; }
    public float Life { get => life; set => life = value; }
    public bool IsBreathableEnvironement { get => isBreathableEnvironement; set => isBreathableEnvironement = value; }
}

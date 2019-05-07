using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{

    private int nbPiecesTotal;
    private int nbPiecesCollected = 0;

    private void Start()
    {
        nbPiecesTotal = GameObject.FindGameObjectsWithTag("Piece").Length;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Player>().lossPieceReparation();
    }
}

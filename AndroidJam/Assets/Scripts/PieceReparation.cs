using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceReparation : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        bool playerTakeThePiece = collision.GetComponent<Player>().TakePieceReparation();

        if (playerTakeThePiece)
        Destroy(gameObject);
    }
}

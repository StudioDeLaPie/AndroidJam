using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Player>().IsBreathableEnvironement = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Player>().IsBreathableEnvironement = false;
    }
}

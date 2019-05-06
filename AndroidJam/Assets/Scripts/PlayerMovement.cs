using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Input.acceleration.x, 0, 0);
    }
}

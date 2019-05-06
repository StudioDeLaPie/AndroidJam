using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float speedPlayer = 1;
    public float minAngleToMove = 0.1f;

    private float horizontalMove = 0;
    private bool jump = false;

    private float widthScreen;
    private float heightScreen;

    void Start()
    {
        widthScreen = Screen.width;
        heightScreen = Screen.height;
    }

    void Update()
    {
        //SI le téléphone penche assez on déplace le joueur
        if (Mathf.Abs(Input.acceleration.x) > minAngleToMove)
            horizontalMove = Input.acceleration.x * speedPlayer;
        else
            horizontalMove = 0;

        //Si on detecte un touchScreen
        if(Input.touches.Length > 0)
        {
            foreach (Touch touch in Input.touches) //Position (0,0) est en bas à gauche de l'écran
            {
                if(touch.position.x > widthScreen / 2) //Si on touche a droite de l'écran
                {
                    jump = true;
                }
                if(touch.position.x < widthScreen / 2)//Si on touche a gauche de l'écran
                {
                    Debug.Log("Respire Connard !");
                }
            }
        }
    }

    private void FixedUpdate()
    {
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
            jump = false;
    }
}

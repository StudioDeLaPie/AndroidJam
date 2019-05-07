using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float speedPlayer = 1;
    public float minAngleToMove = 0.1f;
    public float maxAngleToMove = 0.3f;

    public Animator animator;
    public SoundsPlayer playerSounds;

    private float horizontalMove = 0;
    private bool jump = false;
    private bool respirationPressed = false;

    private float widthScreen;
    private float heightScreen;
    private Player player;

    void Start()
    {
        widthScreen = Screen.width;
        heightScreen = Screen.height;
        player = GetComponent<Player>();
    }

    void Update()
    {
        //Si le téléphone penche assez on déplace le joueur
        if (Mathf.Abs(Input.acceleration.x) > minAngleToMove)
        {
            //Debug.Log(jump);
            horizontalMove = Mathf.Sign(Input.acceleration.x) * Mathf.Clamp(Mathf.Abs(Input.acceleration.x), minAngleToMove, maxAngleToMove) * speedPlayer;
            if (controller.Grounded)
                playerSounds.PlayFootStep();
            else
            {
                playerSounds.StopFootStep();
            }
        }
        else
        {
            horizontalMove = 0;
        }

        //Si on detecte un touchScreen
        if (Input.touches.Length > 0)
        {
            foreach (Touch touch in Input.touches) //Position (0,0) est en bas à gauche de l'écran
            {
                if (touch.position.x > widthScreen / 2) //Si on touche a droite de l'écran
                {
                    jump = true;
                    animator.SetBool("IsJump", true);
                }

                if (touch.position.x < widthScreen / 2)//Si on touche a gauche de l'écran
                {
                    player.Respiration();
                    respirationPressed = true;
                }
                else//La touche saut est préssée sans la touche respiration
                {
                    playerSounds.CanPlayGoodInspiration = true;
                }
            }
        }
        else//Aucune touche n'est préssée 
        {
            playerSounds.CanPlayGoodInspiration = true;
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public void OnLand()
    {
        animator.SetBool("IsJump", jump);
    }
}

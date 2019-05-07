using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Presentation : MonoBehaviour
{
    public List<Canvas> canvas = new List<Canvas>();
    int index = 0;
    private float widthScreen;
    private float heightScreen;
    private bool isTouching = false;

    void Start()
    {
        widthScreen = Screen.width;
        heightScreen = Screen.height;
    }

    void Update()
    {
        if (Input.touches.Length > 0 && !isTouching)
        {
                isTouching = true;
            foreach (Touch touch in Input.touches) //Position (0,0) est en bas à gauche de l'écran
            {
                if (touch.position.x > widthScreen / 2 && index < canvas.Count-1) //Si on touche a droite de l'écran
                {
                    index++;
                }
                if (touch.position.x < widthScreen / 2 && index > 0)//Si on touche a gauche de l'écran
                {
                    index--;
                }
            }
        }
        else if(Input.touches.Length <= 0)
        {
            isTouching = false;
        }


        foreach (Canvas canva in canvas)
        {
            canva.gameObject.SetActive(false);
        }
        canvas[index].gameObject.SetActive(true);
    }

    public void ButtonStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

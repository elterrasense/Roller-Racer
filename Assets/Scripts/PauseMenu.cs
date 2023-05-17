using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuUI;
    public static bool GameIsPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        { 
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                PauseGame();
            }
        }
    }

    void PauseGame ()
    {
        // Pausa el juego
        PauseMenuUI.SetActive(true);  
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        // Continua el juego
        Time.timeScale = 1;
        PauseMenuUI.SetActive(false);
        GameIsPaused = false;
    }

    public void QuitButton()
    {
        // Vuelve al menu principal
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menus");
    }
    
}

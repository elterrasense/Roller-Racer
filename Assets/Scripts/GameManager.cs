using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public GameObject PauseCanvas;
    private static bool GameIsPaused = false;
  

    void Start()
    {
        PauseCanvas.SetActive(false);
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
        PauseCanvas.SetActive(true);  
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        // Continua el juego
        Time.timeScale = 1;
        PauseCanvas.SetActive(false);
        GameIsPaused = false;
    }

    public void QuitButton()
    {
        // Vuelve al menu principal
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menus");
    }

    public void TryAgain()
    {
        // Carga de nuevo la escena
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public GameObject PauseCanvas;
    public float timeRemaining;
    private bool timerIsRunning = false;
    private static bool GameIsPaused = false;
    public TextMeshProUGUI timerObject;
    public GameObject GameOverCanvas;
  

    void Start()
    {
        PauseCanvas.SetActive(false);
        // Activa la cuenta atras
        timerIsRunning = true;
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

        // Llama al metodo para la cuenta atras en cada update
        Timer();

        // Muestra la cuenta atras en el TextMesh
        DisplayTime(timeRemaining);
    }

    void Timer()
    {
        // Comprueba si el timer deberia estar corriendo
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                GameOver();
            }
        }
    }

    void GameOver() {
        // Activa la pantalla de fin del juego
        Time.timeScale = 0f;
        GameOverCanvas.SetActive(true);
    }

    void DisplayTime(float timeToDisplay)
    {
        // Convierte el tiempo restante a minutos y segundos y lo imprime
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerObject.SetText(string.Format("{0:00}:{1:00}", minutes, seconds));
    }

    void PauseGame()
    {
        // Pausa el juego si la pantalla de GameOver no esta activa
        if (!GameOverCanvas.activeSelf) {
            PauseCanvas.SetActive(true);  
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
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
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
}

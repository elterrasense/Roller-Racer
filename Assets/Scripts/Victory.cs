using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Victory : MonoBehaviour
{
    public GameObject VictoryCanvas;
    public GameObject UICanvas;
    public TextMeshProUGUI TimeTaken;
    public TextMeshProUGUI GemsTaken;
    private Inventory ballInventory; // Instanciamos el inventario del jugador
    private GameManager gm; // Instanciamos el GameManager para obtener el tiempo
    public GameObject gmObject;
    public GameObject ball;

    void Start()
    {
        VictoryCanvas.SetActive(false);
        gm = gmObject.GetComponent<GameManager>();
        ballInventory = ball.GetComponent<Inventory>();
    }

    private void OnTriggerEnter(Collider other)
    { // Mostramos la pantalla de victoria con el tiempo y la puntuación.
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            VictoryCanvas.SetActive(true);
            UICanvas.SetActive(false);
            
            // Convierte el tiempo restante a minutos y segundos y lo imprime
            float timeLeft = 180 - gm.timeRemaining;
            float minutes = Mathf.FloorToInt(timeLeft / 60);  
            float seconds = Mathf.FloorToInt(timeLeft % 60);
            GemsTaken.SetText("GEMS ACQUIRED: " + ballInventory.quantity + "/9");
            TimeTaken.SetText(string.Format("TIME TAKEN: {0:00}:{1:00}", minutes, seconds));
        }
    }
}

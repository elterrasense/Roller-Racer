using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public GameObject player;
    public enum gameStates { Playing, Victory, GameOver };
    public gameStates gameState = gameStates.Playing;
    public GameObject mainCanvas;
    public GameObject victoryCanvas;
    public TextMeshProUGUI scoreText;

    private BullInventari bullInventari;
    private int coins;
    //private isLive live;
    public bool buttonPressed = false;

    void Start()
    {
        if (gm == null)
            gm = gameObject.GetComponent<GameManager>();
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        //live = player.GetComponent<isLive> ();
            gameState = gameStates.Playing;
        // Desactivamos el Canvas gameOver, just in case.
        victoryCanvas.SetActive(false);
        mainCanvas.SetActive(false);

        bullInventari = GameObject.FindGameObjectWithTag("Player").GetComponent<BullInventari>();
        
    }

    void Update()
    {
        coins = bullInventari.Cantidad;
        switch (gameState)
        {
            case gameStates.Playing:
                Debug.Log("Gamestate PLAYING");
                Debug.Log("COINS: " + coins);
                if (coins >= 5)
                {
                    gameState = gameStates.Victory;
                    scoreText.SetText(coins.ToString());
                    mainCanvas.SetActive(false);
                    victoryCanvas.SetActive(true);
                }
                break;
            case gameStates.Victory:
                Debug.Log("Gamestate VICTORY");
                // nothing
                break;
        }
    }

}
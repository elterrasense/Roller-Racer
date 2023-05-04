using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {
  public string LevelToLoad; //En esta variable indicarewmos (desde el editor)el nombre del nivel a cargar
  public void loadLevel() {
    //Carga el nivel que contiene la variable publica-
    SceneManager.LoadScene(LevelToLoad); 
  }
}
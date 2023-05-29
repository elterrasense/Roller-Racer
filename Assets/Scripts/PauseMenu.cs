using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pause;
    public GameObject settings;

    public void SettingsButton()
    {
        pause.SetActive(false);
        settings.SetActive(true);
    }

    public void BackButton()
    {
        pause.SetActive(true);
        settings.SetActive(false);
    }
}

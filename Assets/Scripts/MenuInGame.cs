using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuInGame : MonoBehaviour {

    public GameObject panelPause, pauseButton, panelCredits;
    SoundController refSound;

    private void Start()
    {
        refSound = FindObjectOfType<SoundController>();
    }

    // Mette in pausa
    public void Pause()
    {
        refSound.audioSource.Play();

        Time.timeScale = 0;
        panelPause.SetActive(true);
        pauseButton.SetActive(false);
    }

    // Apre i Credits
    public void CreditsOn()
    {
        refSound.audioSource.Play();
        Time.timeScale = 0;
        panelCredits.SetActive(true);
        pauseButton.SetActive(false);
    }

    // Chiude i Credits
    public void CreditsOff()
    {
        refSound.audioSource.Play();
        Time.timeScale = 1;
        panelCredits.SetActive(false);
        pauseButton.SetActive(true);
    }

    // Riprende il gioco
    public void Resume()
    {
        refSound.audioSource.Play();
        Time.timeScale = 1;
        panelPause.SetActive(false);
        pauseButton.SetActive(true);
        
    }

    // Esce e torna al Main Menu
    public void Exit()
    {
        Application.Quit();
    }
}
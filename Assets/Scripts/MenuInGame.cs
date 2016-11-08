using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuInGame : MonoBehaviour {

    public GameObject panelPause, pauseButton;
    SoundController refSound;

    private void Start()
    {
        refSound = FindObjectOfType<SoundController>();
    }

    // Mette in pausa
    public void Pause()
    {
        Time.timeScale = 0;
        panelPause.SetActive(true);
        pauseButton.SetActive(false);
        refSound.audioSource.Play();
    }

    // Riprende il gioco
    public void Resume()
    {
        Time.timeScale = 1;
        panelPause.SetActive(false);
        pauseButton.SetActive(true);
        refSound.audioSource.Play();
    }

    // Esce e torna al Main Menu
    public void Exit()
    {
        SceneManager.LoadScene(0);
        //Debug.Log("Dovrei uscire ma ancora non c'è");
    }
}

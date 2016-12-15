using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public GameObject CanvasFade;

	public void NewGame ()
    {
		StartCoroutine (FadeToScene ());
        
	}
	
	
	public void Credits ()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

	public IEnumerator FadeToScene () {
		CanvasFade.GetComponent<Fade> ().FadeIn ();
		yield return new WaitForSeconds (0.8f);
		SceneManager.LoadScene("Game_Scena");
	}
} 
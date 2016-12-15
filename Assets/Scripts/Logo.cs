using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour {

	public GameObject fadePanel;

	public void Start () {
		fadePanel.GetComponent<CanvasGroup> ().alpha = 1;
		fadePanel.GetComponent<Fade> ().FadeOut ();
		StartCoroutine(WaitAndLoad());
	}

	IEnumerator WaitAndLoad ()
    {
		yield return new WaitForSeconds(2.2f);
		fadePanel.GetComponent<Fade> ().FadeIn ();
		yield return new WaitForSeconds (0.8f);
        SceneManager.LoadScene("MainMenu");
    }



}

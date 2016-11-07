using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	
	public void NewGame ()
    {
        SceneManager.LoadScene("Daniele_Upgrade");
	}
	
	
	public void Credits ()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

   
} 
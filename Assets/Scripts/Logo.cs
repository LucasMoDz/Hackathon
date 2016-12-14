using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour {

	
	IEnumerator Start ()
    {
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("Game_Scena");
    }
	
    
	
	void Update () {
	
	}
}

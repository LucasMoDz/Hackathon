using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour
{
	IEnumerator Start ()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("MainMenu");
    }
}
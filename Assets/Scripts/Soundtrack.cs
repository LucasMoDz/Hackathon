using UnityEngine;
using System.Collections;

public class Soundtrack : MonoBehaviour {

    private bool isFirstSound;

	void Awake ()
    {
        DontDestroyOnLoad(this);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(this.gameObject);
        }

        if (!isFirstSound)
        {
            this.GetComponent<AudioSource>().Play();
            isFirstSound = true;
        }
    }
}

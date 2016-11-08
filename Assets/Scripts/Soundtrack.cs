using UnityEngine;
using System.Collections;

public class Soundtrack : MonoBehaviour {

	
	void Start ()
    {
        DontDestroyOnLoad(this.gameObject);
        //this.GetComponent<AudioSource>().Play();
	}

}

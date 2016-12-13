using UnityEngine;
using System.Collections;

public class NoRayCast : MonoBehaviour {

    StatsMenu elementi;
	

	void OnEnable ()
    {
		elementi = FindObjectOfType<StatsMenu>();
        elementi.active = false;
	}

	void Start () {

	}

	void OnDisable ()
	{
		elementi.active = true;
	}
}

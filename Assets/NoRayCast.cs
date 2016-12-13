using UnityEngine;
using System.Collections;

public class NoRayCast : MonoBehaviour {

    StatsMenu elementi;
	
	void Start () {

        elementi = FindObjectOfType<StatsMenu>();

            }
	
	
	void Update ()
    {
        elementi.active = false;
	}
}

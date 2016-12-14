using UnityEngine;
using System.Collections;

public class ScaleSample : MonoBehaviour {

	public bool playB = false;

	void Start(){

		if(playB == false){
			iTween.ScaleAdd(gameObject, iTween.Hash("x", .05, "y", .05, "easeType", "easeInOutBack", "loopType", "pingPong", "delay", .1));
		}
		else
		{
			iTween.ScaleAdd(gameObject, iTween.Hash("x", .2, "y", .2, "easeType", "easeInOutBack", "loopType", "pingPong", "delay", .1));
		}
	}
}

using UnityEngine;
using System.Collections;

public class ShakeSample : MonoBehaviour {

	public bool playB;

	void Start(){
		
		if (!playB) {
			iTween.ShakeScale (gameObject, iTween.Hash ("x", .009, "y", .009, "easeType", "easeInOutBack", "loopType", "pingPong", "delay", .1));
		} else {
			iTween.RotateBy(gameObject, iTween.Hash("x", .1, "easeType", "easeInOutBack", "loopType", "pingPong", "delay", .05));
		}
	}
}

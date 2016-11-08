using UnityEngine;
using System.Collections;

public class CellMultiplier : MonoBehaviour {

	public int value;
	private GameManager refGM;
	public bool addBool;
	public bool subtractBool;


	// Use this for initialization
	void Start ()
    {
		refGM = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (this.gameObject.transform.childCount > 0 && !addBool) {
			addBool = true;
			subtractBool = false;
			Debug.Log ("NEWS ATTACHED");
			if (refGM.newsAttachedCount < 6) {
				refGM.newsAttachedCount++;
			}
		} else if(this.gameObject.transform.childCount <= 0 && !subtractBool){
			addBool = false;
			subtractBool = true;
			if (refGM.newsAttachedCount > 0) {
				refGM.newsAttachedCount--;
			}

			Debug.Log ("NEWS DETACHED");

		}
	}
}

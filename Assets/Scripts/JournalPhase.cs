using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JournalPhase : MonoBehaviour {

	public int newsPositionID;
	public GameObject newsSelectionTab;
	public GameObject[] journalPiece;
	public GameObject[] newsToSelect;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OpenNewsTab () {
		newsSelectionTab.SetActive (true);
		newsPositionID = EventSystem.current.currentSelectedGameObject.gameObject.GetComponent<CellMultiplier> ().newsPositionID;
	}


	public void SelectionNews () {
		newsSelectionTab.SetActive (false);
		string textToPass = EventSystem.current.currentSelectedGameObject.gameObject.transform.GetChild(0).GetComponent<Text> ().text;
		for(int i = 0; i < journalPiece.Length; i++) {
			if(journalPiece[i].GetComponent<CellMultiplier>().newsPositionID == newsPositionID){
				journalPiece[i].transform.GetChild(0).GetComponent<Text> ().text = textToPass;
			}
		}
	}
}

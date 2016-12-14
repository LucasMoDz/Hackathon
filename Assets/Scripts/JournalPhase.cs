using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JournalPhase : MonoBehaviour {

	public int newsPositionID;
	public GameObject newsSelectionTab;
	public GameObject[] journalPiece;
	public GameObject[] newsToSelect;
	private GameManager refGM;

	// Use this for initialization
	void Start () {
		refGM = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OpenNewsTab () {
		newsSelectionTab.SetActive (true);
		GameObject buttonClicked = EventSystem.current.currentSelectedGameObject.gameObject;
		newsPositionID = buttonClicked.GetComponent<NewsID> ().newsPositionID;
		buttonClicked.GetComponent<Button> ().interactable = false;
		/*for(int i = 0; i < journalPiece.Length; i++) {
			if(journalPiece[i].GetComponent<CellMultiplier>().newsPositionID == newsPositionID){
				journalPiece[i].transform.GetChild(0).GetComponent<Text> ().text = textToPass;
			}
		}*/
	}
    
	public void SelectionNews() 
	{
		refGM.newsAttachedCount++;
		newsSelectionTab.SetActive(false);
		GameObject buttonClicked = EventSystem.current.currentSelectedGameObject.gameObject;
		string textToPass = buttonClicked.transform.GetChild(0).GetComponent<Text> ().text;
		string descriptionToPass = buttonClicked.transform.GetComponent<News>().description;
		EventSystem.current.currentSelectedGameObject.gameObject.GetComponent<Button> ().interactable = false; 

		for(int i = 0; i < journalPiece.Length; i++)
        {
			if(journalPiece[i].GetComponent<NewsID>().newsPositionID == newsPositionID)
            {
				journalPiece[i].transform.GetChild(0).GetComponent<Text>().text = textToPass;

                if (descriptionToPass != "")
                    journalPiece[i].transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = descriptionToPass;
                else
                {
                    journalPiece[i].transform.GetChild(1).gameObject.SetActive(true);
                    journalPiece[i].transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = "";
                }
            }
		}
	}
}
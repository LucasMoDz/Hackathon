using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public List<GameObject> buttonList = new List<GameObject>();
	public List<GameObject> cellNewsList = new List<GameObject>();
    public List<GameObject> newsChoosed = new List<GameObject>();

	public Canvas canvasMain;
	public Canvas canvasJournal;
	public Canvas canvasNews;

    public int buttonClicked;
    private const int TOTAL_NUMBER_OF_BUTTONS = 5;
    
    public bool AllButtonsAreClicked()
    {
        if (buttonClicked == TOTAL_NUMBER_OF_BUTTONS)
            return true;
        else
            return false;
    }


	public void StartPlay () {
		//Chiamato dal bottne start attiva e fa comparire il CanvasNews
		//Starta l'apparizione delle notizie
		//Spegne il CanvasMain
		canvasMain.GetComponent<CanvasGroup>().interactable = false;
		canvasMain.GetComponent<CanvasGroup>().blocksRaycasts = false;

		canvasMain.GetComponent<Fade>().FadeOut();
		canvasNews.gameObject.SetActive(true);
		canvasNews.GetComponent<Fade>().FadeIn();

	}


    public void EndNewsPhase()
    {
		Debug.Log ("FASE SCELTA NEWS FINITA");
		//Fade Out della schermata di scelta news
		canvasNews.GetComponent<Fade>().FadeOut();


		//Fade In della schermata di impaginazione con il giornale
		canvasJournal.gameObject.SetActive(true);
		canvasJournal.GetComponent<Fade>().FadeIn();


		//Stoppare le coroutine di tutti i bottoni soprattutto se alcuni non sono stati cliccati
		//Spostare tutti i bottoni imparentandoli alle celle e assegnandone la stessa dimensione. 
		//Spegnere ad ogni bottone il component Button e accendere il component Drag & Drop. 
		for (int i = 0; i <= buttonList.Count-1; i++) {
			buttonList[i].gameObject.GetComponent<CoroutineButton>().StopAllCoroutines();
			buttonList[i].gameObject.GetComponent<CoroutineButton>().enabled = false;

			buttonList [i].GetComponent<Button> ().enabled = false;
			buttonList [i].transform.SetParent (cellNewsList [i].transform);
			buttonList [i].transform.position = cellNewsList [i].transform.position;
			buttonList [i].GetComponent<RectTransform> ().sizeDelta = cellNewsList [i].GetComponent<RectTransform> ().sizeDelta;
			GameObject child = buttonList [i].transform.GetChild(0).gameObject;
			child.GetComponent<RectTransform> ().sizeDelta = buttonList [i].GetComponent<RectTransform> ().sizeDelta;

			buttonList [i].AddComponent<DragAndDropItem>();
			Debug.Log ("Il bottone: " + buttonList [i].gameObject.name + " ha completato il setting");
		}
			


    }
}
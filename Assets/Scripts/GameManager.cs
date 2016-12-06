using UnityEngine;
using System.Collections;
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

	public GameObject publishButton;
	public GameObject descrizioneRoom;

    public int buttonClicked;
    private const int TOTAL_NUMBER_OF_BUTTONS = 5;
	public int newsAttachedCount;

	int like, dislike;
	bool test = false;

    public bool AllButtonsAreClicked()
    {
        if (buttonClicked == TOTAL_NUMBER_OF_BUTTONS)
            return true;
        else
            return false;
    }
    
	void Update () {
		if (newsAttachedCount == 5) {
			newsAttachedCount = 0;
			for (int i = 0; i <= cellNewsList.Count - 1; i++) {
				cellNewsList [i].SetActive (false);
			}
			publishButton.SetActive (true);
		}


		if (AllButtonsAreClicked() && !test)
		{
			EndNewsPhase();
			test = true;
			//StopAllCoroutines();
		}
	}

	public void StartPlay () {
		//Chiamato dal bottone start attiva e fa comparire il CanvasNews
		StartCoroutine(PlayCoroutine());

	}


    public void EndNewsPhase()
    {
		Debug.Log ("FASE SCELTA NEWS FINITA");
		StartCoroutine(JournalPhase());
    }


	public IEnumerator JournalPhase () {
		//Fade Out della schermata di scelta news
		canvasNews.GetComponent<Fade>().FadeOut();
		yield return new WaitForSeconds (1f);

		//yield return null;

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
		canvasNews.gameObject.SetActive(false);

	}


	public void PointCalculator() {
		
		StartCoroutine(CalcCoroutine());

	}


	public IEnumerator CalcCoroutine () {
		//Fade Out del Canvas Journal
		//Fade In del CanvasResults
		//Prendere i valori dai bottoni delle news moltiplicarli per il valore multiplier delle celle in cui si trovano
		//I punteggi positivi andranno in like e quelli negativi in dislike.
		//Passare i valori all'interfaccia in CanvasResults

		canvasJournal.GetComponent<Fade>().FadeOut();
		yield return new WaitForSeconds (1f);
		canvasJournal.gameObject.SetActive(false);



		//Fa apparire il CanvasMain
		canvasMain.GetComponent<Fade>().FadeIn();

		canvasMain.GetComponent<CanvasGroup>().interactable = true;
		canvasMain.GetComponent<CanvasGroup>().blocksRaycasts = true;

	}


	public IEnumerator PlayCoroutine () {
		//Starta l'apparizione delle notizie
		//Spegne il CanvasMain
		canvasMain.GetComponent<CanvasGroup>().interactable = false;
		canvasMain.GetComponent<CanvasGroup>().blocksRaycasts = false;

		canvasMain.GetComponent<Fade>().FadeOut();
		yield return new WaitForSeconds (1f);

		canvasNews.gameObject.SetActive(true);
		canvasNews.GetComponent<Fade>().FadeIn();


	}
}
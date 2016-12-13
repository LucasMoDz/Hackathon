using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public List<GameObject> buttonList = new List<GameObject>();
	public List<GameObject> cellNewsList = new List<GameObject>();
	public List<GameObject> title_CellList = new List<GameObject>();
    public List<GameObject> newsChoosed = new List<GameObject>();
    
	public Canvas canvasMain;
	public Canvas canvasJournal;
	public Canvas canvasNews;

    private CreateRSSList listRss;

	public GameObject publishButton;
	public GameObject descrizioneRoom;
	public GameObject timerBar;

	public GameObject globalLevelSystem;

    public int buttonClicked;
    private const int TOTAL_NUMBER_OF_BUTTONS = 5;
	public int newsAttachedCount;

	int like, dislike;
	bool test = false;

    void Awake()
    {
        listRss = FindObjectOfType<CreateRSSList>();
    }

    public bool AllButtonsAreClicked()
    {
        if (buttonClicked == TOTAL_NUMBER_OF_BUTTONS)
            return true;
        else
            return false;
    }
    
	void Update ()
    {
		if (newsAttachedCount == 5)
        {
			newsAttachedCount = 0;

            for (int i = 0; i <= cellNewsList.Count - 1; i++)
                cellNewsList[i].SetActive(false);

			publishButton.SetActive (true);
		}

		if (AllButtonsAreClicked() && !test)
		{
			EndNewsPhase();
			test = true;
		}
	}

	public void StartPlay ()
    {
		//Chiamato dal bottone start attiva e fa comparire il CanvasNews
        if (listRss.newsHaveBeenDownloaded)
		    StartCoroutine(PlayCoroutine());
	}
    
    public void EndNewsPhase()
    {
		//Debug.Log ("FASE SCELTA NEWS FINITA");
		StartCoroutine(JournalPhaseNew());
    }
    
	public IEnumerator JournalPhase ()
    {
		//Fade Out della schermata di scelta news
		canvasNews.GetComponent<Fade>().FadeOut();
		yield return new WaitForSeconds (1f);

		//Fade In della schermata di impaginazione con il giornale
		canvasJournal.gameObject.SetActive(true);
		canvasJournal.GetComponent<Fade>().FadeIn();

		//Stoppare le coroutine di tutti i bottoni soprattutto se alcuni non sono stati cliccati
		//Spostare tutti i bottoni imparentandoli alle celle e assegnandone la stessa dimensione. 
		//Spegnere ad ogni bottone il component Button e accendere il component Drag & Drop.

		/*
		for (int i = 0; i <= buttonList.Count-1; i++) {
			buttonList[i].gameObject.GetComponent<CoroutineButton>().StopAllCoroutines();
			buttonList[i].gameObject.GetComponent<CoroutineButton>().enabled = false;

			buttonList [i].GetComponent<Button> ().enabled = false;
			buttonList [i].transform.SetParent (canvasNews.transform);
			buttonList [i].transform.position = cellNewsList [i].transform.position;
			buttonList [i].GetComponent<RectTransform> ().sizeDelta = cellNewsList [i].GetComponent<RectTransform> ().sizeDelta;
			GameObject child = buttonList [i].transform.GetChild(0).gameObject;
			child.GetComponent<RectTransform> ().sizeDelta = buttonList [i].GetComponent<RectTransform> ().sizeDelta;

			buttonList [i].AddComponent<DragAndDropItem>();
			Debug.Log ("Il bottone: " + buttonList [i].gameObject.name + " ha completato il setting");
		}*/

		for (int i = 0; i <= buttonList.Count-1; i++)
        {
			buttonList[i].transform.GetChild(0).gameObject.GetComponent<CoroutineButton>().StopAllCoroutines();
			buttonList[i].transform.GetChild(0).gameObject.GetComponent<CoroutineButton>().enabled = false;

			buttonList [i].transform.GetChild(0).GetComponent<Button> ().enabled = false;
			buttonList [i].transform.GetChild(0).transform.SetParent (cellNewsList [i].transform);
			cellNewsList [i].transform.GetChild(0).transform.position = cellNewsList [i].transform.position;
			cellNewsList [i].transform.GetChild(0).GetComponent<RectTransform> ().sizeDelta = cellNewsList [i].GetComponent<RectTransform> ().sizeDelta;
			GameObject child = cellNewsList [i].transform.GetChild(0).transform.GetChild(0).gameObject;
			child.GetComponent<RectTransform> ().sizeDelta = cellNewsList [i].GetComponent<RectTransform> ().sizeDelta;

			cellNewsList [i].transform.GetChild (0).gameObject.GetComponent<DragAndDropItem> ().enabled = true;
			//Debug.Log ("Il bottone: " + buttonList [i].gameObject.name + " ha completato il setting");
		}

		canvasNews.gameObject.SetActive(false);
	}
    
	public IEnumerator JournalPhaseNew ()
    {
		//Fade Out della schermata di scelta news
		canvasNews.GetComponent<Fade>().FadeOut();
		yield return new WaitForSeconds (1f);

		//Fade In della schermata di impaginazione con il giornale
		canvasJournal.gameObject.SetActive(true);
		canvasJournal.GetComponent<Fade>().FadeIn();

		for (int i = 0; i <= buttonList.Count - 1; i++)
        {
			buttonList [i].transform.GetChild (0).gameObject.GetComponent<CoroutineButton> ().StopAllCoroutines ();
			buttonList [i].transform.GetChild (0).gameObject.GetComponent<CoroutineButton> ().enabled = false;

			buttonList [i].transform.GetChild (0).GetComponent<Button> ().enabled = false;

			canvasJournal.GetComponent<JournalPhase> ().newsToSelect [i].transform.GetChild (0).GetComponent<Text> ().text = buttonList [i].transform.GetChild (0).transform.GetChild(0).gameObject.GetComponent<Text> ().text;
		}

		canvasNews.gameObject.SetActive(false);
	}
    
	public IEnumerator PlayCoroutine ()
    {
		//Starta l'apparizione delle notizie
		//Spegne il CanvasMain
		canvasMain.GetComponent<CanvasGroup>().interactable = false;
		canvasMain.GetComponent<CanvasGroup>().blocksRaycasts = false;

		canvasMain.GetComponent<Fade>().FadeOut();

		yield return new WaitForSeconds (1f);

		//esegue il lerp della camera
		Camera.main.GetComponent<LerpCamera>().ChangeProjection = true;

		canvasNews.gameObject.SetActive(true);
		canvasNews.GetComponent<Fade>().FadeIn();
		timerBar.GetComponent<TimeBar> ().DecreaseCo();
	}
    
	public void PointCalculator()
    {
        StartCoroutine(CalcCoroutine());
	}
    
	public IEnumerator CalcCoroutine ()
    {
		//Fade Out del Canvas Journal
		//Fade In del CanvasResults
		//Prendere i valori dai bottoni delle news moltiplicarli per il valore multiplier delle celle in cui si trovano
		//I punteggi positivi andranno in like e quelli negativi in dislike.
		//Passare i valori all'interfaccia in CanvasResults
		canvasJournal.GetComponent<Fade>().FadeOut();

		//esegue il lerp della camera
		Camera.main.GetComponent<LerpCamera>().GoForward = false;
		Camera.main.GetComponent<LerpCamera>().ChangeProjection = true;

		yield return new WaitForSeconds (1f);
		Camera.main.GetComponent<LerpCamera>().GoForward = true;

		canvasJournal.gameObject.SetActive(false);

		//ResetButtons ();
		ResetFlow ();

		//yield return new WaitForSeconds (1f);

		//Fa apparire il CanvasMain
		canvasMain.GetComponent<Fade>().FadeIn();

		canvasMain.GetComponent<CanvasGroup>().interactable = true;
		canvasMain.GetComponent<CanvasGroup>().blocksRaycasts = true;

		yield return new WaitForSeconds (1f);
		globalLevelSystem.GetComponent<GlobalLevelSystem> ().IncreaseExp (150);
	}


	public void ResetFlow ()
	{
		newsChoosed.Clear ();
		buttonClicked = 0;
		test = false;
		timerBar.GetComponent<Image> ().fillAmount = 1;

		publishButton.SetActive (false);

		for (int i = 0; i <= cellNewsList.Count-1; i++)
		{
			buttonList [i].transform.GetChild(0).GetComponent<Button> ().enabled = true;
			buttonList [i].transform.GetChild(0).gameObject.GetComponent<Button>().interactable = true;
			buttonList [i].transform.GetChild(0).gameObject.GetComponent<CoroutineButton>().enabled = true;
			buttonList [i].transform.GetChild(0).transform.GetComponentInChildren<Text>().fontStyle = FontStyle.Normal;
			buttonList [i].transform.GetChild (0).gameObject.GetComponent<News> ().titleNews = "";

			canvasJournal.GetComponent<JournalPhase> ().journalPiece [i].transform.GetChild (0).GetComponent<Text> ().text = "Seleziona la notizia";
			canvasJournal.GetComponent<JournalPhase> ().newsToSelect [i].GetComponent<Button> ().interactable = true;
		}

	}

	public void ResetButtons ()
    {
		newsChoosed.Clear ();
		buttonClicked = 0;
		test = false;
		timerBar.GetComponent<Image> ().fillAmount = 1;

		for (int i = 0; i <= cellNewsList.Count - 1; i++)
			cellNewsList [i].SetActive (true);

		for (int i = 0; i <= title_CellList.Count - 1; i++) 
			title_CellList [i].GetComponent<Image>().color = new Color32 (255, 255, 255, 0);

		publishButton.SetActive (false);

		for (int i = 0; i <= cellNewsList.Count-1; i++)
        {
			title_CellList [i].transform.GetChild(0).transform.SetParent (buttonList [i].transform);
			buttonList [i].transform.GetChild(0).transform.position = buttonList [i].transform.position;
			buttonList [i].transform.GetChild(0).GetComponent<RectTransform> ().sizeDelta = buttonList [i].GetComponent<RectTransform> ().sizeDelta;
			GameObject child = buttonList [i].transform.GetChild(0).transform.GetChild(0).gameObject;
			child.GetComponent<RectTransform> ().sizeDelta = buttonList [i].GetComponent<RectTransform> ().sizeDelta;

			buttonList [i].transform.GetChild(0).GetComponent<Button> ().enabled = true;
			buttonList [i].transform.GetChild(0).gameObject.GetComponent<Button>().interactable = true;
			buttonList [i].transform.GetChild(0).gameObject.GetComponent<CoroutineButton>().enabled = true;
			buttonList [i].transform.GetChild(0).transform.GetComponentInChildren<Text>().fontStyle = FontStyle.Normal;
			buttonList [i].transform.GetChild (0).gameObject.GetComponent<News> ().titleNews = "";
			buttonList [i].transform.GetChild (0).gameObject.GetComponent<DragAndDropItem> ().enabled = false;
			//cellNewsList [i].transform.GetChild(0).gameObject.AddComponent<DragAndDropItem>();
			//Debug.Log ("Il bottone: " + buttonList [i].gameObject.name + " ha completato il setting");
		}



	}
}
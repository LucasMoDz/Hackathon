using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class GlobalLevelSystem : MonoBehaviour {

	bool isLevelUp;


	public GameObject expBar_Full;      
	public GameObject levelUpImage;

	public Text expCollText;
	public Text playerLevelText;
	public Text nCoinsText;
	public Text nLikeText;
	public Text nFollowerText;

	float value = 0;

	GameObject canvasUI;
	//SpriteRenderer feedback;

	[Header("Global Level and Stats")]
	[Space(10)]
	public int globalPlayerLevel = 1;
	//public int currentStats1;
	//public int currentStats2;
	//public int currentStats3;

	public float expToLevelUp;
	public float expCollected;
	//public int startingStats1;
	//public int startingStats2;
	//public int startingStats3;


	void Awake()
	{

		/*
		//Settiamo i parametri di inizio gioco
		if (playerLevel == 1)
		{
			//Set the starting stats of the player
			currentStats1 = startingStats1;
			currentStats2 = startingStats2;
			currentStats3 = startingStats3;
		}
		*/

	}


	void Start()
	{
		expBar_Full.GetComponent<Slider> ().maxValue = expToLevelUp;

	}


	/*
	IEnumerator FeedbackOff (){
		yield return new WaitForSeconds (0.3f);
		this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
	}
	*/


	//Metodo chiamato per incrementare gli exp globali del Player
	public void IncreaseExp(float expToAdd){
		//expCollected += expToAdd;
		StartCoroutine (ExpUp (expToAdd));
		//StartCoroutine (ExpUIHandler (expToAdd));
	}


	public IEnumerator ExpUp (float exp) {
		//Debug.Log ("EXP INCREASE PROVA");
		while (value < exp) 
		{
			value += 1f;
			expCollected += 1f;
			expBar_Full.GetComponent<Slider> ().value = expCollected;
			//Debug.Log ("EXP INCREASE: " + expCollected.ToString ());
			yield return null;
		} 
		value = 0;
	}


	//Gestisce la visibilità dei punti exp nella UI
	public IEnumerator ExpUIHandler (int expValue){
		Debug.Log ("UI EXP");
		expCollText.gameObject.SetActive (true);
		expCollText.text = ("  +"+ expValue +" exp");
		yield return new WaitForSeconds (1f);
		expCollText.gameObject.SetActive (false);
	}


	//Gestisce il level up globale
	IEnumerator LevelUp()
	{
		//Increase the global level
		globalPlayerLevel++;

		//Activate the feedback image
		if (levelUpImage == null) {
			//levelUpImage = GameObject.FindGameObjectWithTag ("LevelUpIcon");
		}
		//levelUpImage.GetComponent<Image>().enabled = true;

		//Save the previous required exp
		float expToPreviousLevelUp = expToLevelUp;

		//Set the new exp required to level up to the next level
		expToLevelUp = expToPreviousLevelUp * 1.5f;

		//Update exp collected starting from zero
		expCollected = expCollected - (int) expToPreviousLevelUp;
		if (expCollected < 0) {
			expCollected = 0;
		}

		//Increase Stats each level up
		//startingStats1++;
		//currentStats1 = startingStats1;

		//Increase Attack if the player level is pair
		if (globalPlayerLevel % 2 == 0)
		{
			//currentStats2++;
		}

		//Increase Mana if the player level is odd
		if (globalPlayerLevel % 2 != 0)
		{
			//currentStats3 = currentStats3 + 3;
			//startingStats3 = startingStats3 + 3;
		}
		//currentStats3 = startingStats3;


		//Aggiorna le barre con i nuovi valori max

		expBar_Full.GetComponent<Slider> ().maxValue = expToLevelUp;


		//Deactivate the feedback image
		yield return new WaitForSeconds (1.5f);
		//levelUpImage.GetComponent<Image>().enabled = false;
		//this.gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
		isLevelUp = false;

	}

	public void UpdatePlayer () {

	}


	void Update()
	{

		//Aggiorna la UI: exp
	

		playerLevelText.text = ("Lv. " + globalPlayerLevel.ToString());




		//Check if the player have reached the required exp to level up
		if (expCollected >= expToLevelUp && isLevelUp == false)
		{
			isLevelUp = true;
			StartCoroutine (LevelUp ());
		}

		//Debug button to level up rapidly
	/*	if (Input.GetKeyDown (KeyCode.L)) {
			expCollected = (int)expToLevelUp+100;
		}*/
			
		//Debug button to level up rapidly
		if (Input.GetKeyDown (KeyCode.M)) {
			IncreaseExp(150);
		}
	}
		

}

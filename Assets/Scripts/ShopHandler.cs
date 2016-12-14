using UnityEngine;
using System.Collections;

public class ShopHandler : MonoBehaviour {


	//public GameObject objectToEnable1;
	//public GameObject objectToEnable2;

	//public int costForObject1;
	//public int costForObject2;

	private CoinAndLikes refCoinsAndLikes;

	// Use this for initialization
	void Start () {
		refCoinsAndLikes = FindObjectOfType<CoinAndLikes>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void BuyObject (int cost) {
		int myCoin = refCoinsAndLikes.GetComponent<CoinAndLikes> ().coins;
		if (myCoin >= cost) {
			this.gameObject.SetActive (false);
			int newCoin = refCoinsAndLikes.GetComponent<CoinAndLikes> ().coins - cost;
			refCoinsAndLikes.GetComponent<CoinAndLikes> ().coinsText.text = newCoin.ToString ();

		} else {
			//inserire feedback negativo
		}
	}
}

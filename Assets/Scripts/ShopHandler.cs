using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopHandler : MonoBehaviour
{
	private CoinAndLikes refCoinsAndLikes;
    
	void Awake ()
    {
		refCoinsAndLikes = FindObjectOfType<CoinAndLikes>();
	}
	
	public void BuyObject (int cost)
    {
		int myCoin = refCoinsAndLikes.GetComponent<CoinAndLikes> ().coins;

		if (myCoin >= cost)
        {
			this.gameObject.SetActive (false);

            Button buttonPressed = EventSystem.current.currentSelectedGameObject.gameObject.GetComponent<Button>();
            buttonPressed.interactable = false;

            int newCoin = refCoinsAndLikes.GetComponent<CoinAndLikes> ().coins - cost;
			refCoinsAndLikes.GetComponent<CoinAndLikes> ().coinsText.text = newCoin.ToString ();
		}
	}
}
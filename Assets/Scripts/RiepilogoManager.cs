using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RiepilogoManager : MonoBehaviour
{
    CoinAndLikes coinsandlikes;
    GameManager refgm;
    public Text textCoins, textLikes, textExp;

	void Start ()
    {
        coinsandlikes = FindObjectOfType<CoinAndLikes>();
        refgm = FindObjectOfType<GameManager>();
	}

   public void SetTexts()
    {
        textCoins.text = coinsandlikes.coins.ToString();
        textLikes.text = coinsandlikes.likes.ToString();
        textExp.text = refgm.exp.ToString();
    }
}
using UnityEngine;
using UnityEngine.UI;

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
        textCoins.text = coinsandlikes.coinsEarned.ToString();
        textLikes.text = coinsandlikes.likesEarned.ToString();
        textExp.text = refgm.exp.ToString();
    }
}
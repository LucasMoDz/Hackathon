using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinAndLikes : MonoBehaviour
{
    public Text coinsText, likesText;
	public int coins, likes;
    
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (FindObjectsOfType(GetType()).Length > 1)
            Destroy(this.gameObject);

        coinsText.text = coins.ToString();
        likesText.text = likes.ToString();
    }

    public void SetCoinsAndLikes()
    {
        int coinsEarned = Random.Range(50, 250);
        int likesEarned = Random.Range(200, 800);

        StartCoroutine(SetCoinsCO(coinsEarned));
        StartCoroutine(SetLikesCO(likesEarned));
    }

    private IEnumerator SetCoinsCO(int _coinsEarned)
    {
        while (_coinsEarned > 0)
        {
            _coinsEarned--;
            coins++;
            coinsText.text = coins.ToString();
            yield return new WaitForEndOfFrame();
        }

        yield break;
    }

    private IEnumerator SetLikesCO(int _likesEarned)
    {
        while (_likesEarned > 0)
        {
            _likesEarned--;
            likes++;
            likesText.text = likes.ToString();
            yield return new WaitForEndOfFrame();
        }

        yield break;
    }
}
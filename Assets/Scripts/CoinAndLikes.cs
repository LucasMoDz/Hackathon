using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinAndLikes : MonoBehaviour
{
    public Text coinsText, likesText;
    public int coins = 100;
    public int likes = 0;

    public int coinsEarned, likesEarned;
    
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
        coinsEarned = Random.Range(50, 250);
        likesEarned = Random.Range(200, 800);
    }

    public void StartAnimationOfStatistics()
    {
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

        coinsEarned = 0;
        yield break;
    }

    private IEnumerator SetLikesCO(int _likesEarned)
    {
        while (_likesEarned > 0)
        {
            _likesEarned -= 2;
            likes += 2;
            likesText.text = likes.ToString();
            yield return new WaitForEndOfFrame();
        }

        likesEarned = 0;
        yield break;
    }
}
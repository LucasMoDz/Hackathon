using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeBar : MonoBehaviour
{
    public Image barTime;
    private float seconds = 60;
    
    private void Start()
    {
        StartCoroutine(DecreaseBar());
    }

    private IEnumerator DecreaseBar()
    {
        while (barTime.fillAmount > 0)
        {
            yield return new WaitForSeconds(1);
            barTime.fillAmount -= 0.0167f;
        }
    }
}
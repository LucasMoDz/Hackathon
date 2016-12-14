using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorCongratulations : MonoBehaviour
{
    private float timeLeft;
    private Color targetColor;

    public void LoopColor()
    {
        StartCoroutine(StartLoopColor());
    }

	private IEnumerator StartLoopColor()
    {
        while (true)
        {
            if (timeLeft <= Time.deltaTime)
            {
                this.GetComponent<Text>().color = targetColor;

                targetColor = new Color(Random.value, Random.value, Random.value);
                timeLeft = 1.0f;
            }
            else
            {
                this.GetComponent<Text>().color = Color.Lerp(this.GetComponent<Text>().color, targetColor, Time.deltaTime / timeLeft);
                timeLeft -= Time.deltaTime;
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
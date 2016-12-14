using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorCongratulations : MonoBehaviour
{
	private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.05f, 0.5f));
            this.GetComponent<Text>().color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            yield return new WaitForEndOfFrame();
        }
    }
}
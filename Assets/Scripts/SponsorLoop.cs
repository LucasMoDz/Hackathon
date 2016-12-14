using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SponsorLoop : MonoBehaviour
{
    private int index = 0;
    public Sprite[] sponsorSprites;
    
    private IEnumerator Start()
    {
        while (true)
        {
            this.GetComponent<Image>().sprite = sponsorSprites[index];
            yield return new WaitForSeconds(Random.Range(3, 6));

            if (index < sponsorSprites.Length -1)
                index++;
            else
                index = 0;

            yield return new WaitForEndOfFrame();
        }
    }
}
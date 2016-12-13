using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SponsorLoop : MonoBehaviour
{
    public Sprite[] sponsorSprites;
    
    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3, 6));
            this.GetComponent<Image>().sprite = sponsorSprites[Random.Range(0, sponsorSprites.Length)];
        }
    }
}
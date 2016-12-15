using UnityEngine;
using UnityEngine.UI;

public class SponsorLoop : MonoBehaviour
{
    private int index = 0;
    public Sprite[] sponsorSprites;
    
    public void StartLoop()
    {
        StartLoopCO();
    }

    private void StartLoopCO()
    {
        this.GetComponent<Image>().sprite = sponsorSprites[index];

        if (index < sponsorSprites.Length -1)
            index++;
        else
            index = 0;
    }
}
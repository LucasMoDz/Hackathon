using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public List<GameObject> newsChoosed = new List<GameObject>();
    public int buttonClicked;
    private const int TOTAL_NUMBER_OF_BUTTONS = 5;
    
    public bool AllButtonsAreClicked()
    {
        if (buttonClicked == TOTAL_NUMBER_OF_BUTTONS)
            return true;
        else
            return false;
    }

    public void Feedback()
    {
        
    }
}
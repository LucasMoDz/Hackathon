using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Journal : MonoBehaviour {

    public int like, dislike;

    GameManager refGM;
    //Calculator refCalc;

	void Start () 
	{
        refGM = FindObjectOfType<GameManager>();
        //refCalc = FindObjectOfType<Calculator>();
        //foreach (var news in refGM.newsChoosed)
        //{

        //}
	}

    // Moltiplica il peso della news con il moltiplicatore della cella sul Journal
    public void FinalJournalValue(News _button, CellMultiplier cell)
    {
        //Journal refJournal = FindObjectOfType<Journal>();

        int final = _button.weight * cell.value;
        if (!_button.isTrue)
        {
            dislike += final;
        }
        else
        {
            like += final;
        }
    }
}

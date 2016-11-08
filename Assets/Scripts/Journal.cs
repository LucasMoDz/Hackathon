using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Journal : MonoBehaviour {

    public int like, dislike;
    
    GameManager refGM;
    CellMultiplier refCellMultipler;

	void Start () 
	{
        refGM = FindObjectOfType<GameManager>();

        for (int i = 0; i < refGM.newsChoosed.Count; i++)
        {
            FinalJournalValue(refGM.newsChoosed[i].GetComponent<News>(), refCellMultipler);
        }
	}

    // Moltiplica il peso della news con il moltiplicatore della cella sul Journal
    public void FinalJournalValue(News _button, CellMultiplier cell)
    {
        int final = _button.weight * cell.value;

        if (!_button.isTrue)
            dislike += final;
        else
            like += final;
    }
}

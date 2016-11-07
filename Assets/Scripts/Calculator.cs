using UnityEngine;

public class Calculator : MonoBehaviour
{
    // Calcola il peso della singola news
	public void CalcNewsValue(News _button)
    {
        if (_button.isTrue && _button.isInteresting)
        {
            _button.GetComponent<News>().weight = 10;
        }

        else if (_button.isTrue && !_button.isInteresting)
        {
            _button.GetComponent<News>().weight = 5;
        }

        else if (!_button.isTrue)
        {
            _button.GetComponent<News>().weight = -2;
        }
    }

    // Moltiplica il peso della news con il moltiplicatore della cella sul Journal
	public void FinalJournalValue(News _button, CellMultiplier cell)
	{
        int final =_button.weight * cell.value;
	}
}
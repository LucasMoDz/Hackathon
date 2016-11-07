using UnityEngine;

public class Calculator : MonoBehaviour
{

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

	public void JournalValue()
	{
        
	}
}
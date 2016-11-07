using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Calculator : MonoBehaviour {
	
	private void Start ()
	{
	}
	
	public void CalcNewsValue(Button _button)
	{
		if (_button.isTrue && _button.isInteresting) 
		{
			return _button.GetComponent<News> ().weight = 10f;
		}
		else if (_button.isTrue && !_button.isInteresting) 
		{
			return _button.GetComponent<News> ().weight = 5f;
		}
		else if (!_button.isTrue) 
		{
			return _button.GetComponent<News> ().weight = -2f;
		}
	}

	public void JournalValue()
	{




	}
}

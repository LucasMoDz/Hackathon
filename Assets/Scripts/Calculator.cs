using UnityEngine;

public class Calculator : MonoBehaviour
{
	public void CalcNewsValue(News _button)
    {
        if (_button.isTrue && _button.isInteresting)
            _button.weight = 10;
        
        else if (_button.isTrue && !_button.isInteresting)
            _button.weight = 5;

        else if (!_button.isTrue)
            _button.weight = -2;
    }
}
using UnityEngine;
using System;

public class Prova : MonoBehaviour
{
	private void Start ()
    {
        string prova = "Sono un ca\"ne";
        string s = "\"";
        Debug.Log(s.Length);
        
        foreach (var item in prova.ToCharArray())
        {
            if (String.Compare("\"", item.ToString()) == 0)
                Debug.Log("E' uguale");
        }
        
	}
}
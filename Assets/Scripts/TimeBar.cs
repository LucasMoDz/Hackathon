﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeBar : MonoBehaviour
{
    public Image barTime;
    private float seconds = 60;
    private GameManager refGameManager;
    
    private void Awake()
    {
        refGameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        //StartCoroutine(DecreaseBar());
    }

	public void DecreaseCo () {
		StartCoroutine(DecreaseBar());
	}

    public IEnumerator DecreaseBar()
    {
        while (barTime.fillAmount > 0)
        {
            yield return new WaitForSeconds(1);
            barTime.fillAmount -= 0.0167f;
        }

		refGameManager.EndNewsPhase();
        yield break;
    }
}
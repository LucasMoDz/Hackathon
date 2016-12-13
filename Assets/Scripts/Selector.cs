using UnityEngine;
using System.Collections;

public class Selector : MonoBehaviour {

    public GameObject redattore;
    StatsMenu elementi;

	void Start ()
    {
        elementi = FindObjectOfType<StatsMenu>();
	}
	
	
	public void Selettore ()
    {
        elementi.panel.gameObject.SetActive(true);
        elementi.CallPanelNew(redattore.GetComponent<Stats>().nameof,
                            redattore.GetComponent<Stats>().image,
                            redattore.GetComponent<Stats>().level,
                            redattore.GetComponent<Stats>().digitale,
                            redattore.GetComponent<Stats>().typewriting,
                            redattore.GetComponent<Stats>().graphics,
                            redattore.GetComponent<Stats>().fama);
    }
}

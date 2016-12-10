using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuShop : MonoBehaviour {

    public GameObject panelShop;
    bool isInMenu;

	void Start ()
    {

    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!isInMenu)
            {
                panelShop.SetActive(true);
                isInMenu = true;
            }
            else
            {
                panelShop.SetActive(false);
                isInMenu = false;
            }
        }
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public struct ShopItem
{
    public string itemName, itemPrice;
    public Sprite itemSprite;
    public Button itemButton;
}

public class MenuShop : MonoBehaviour {

    public ShopItem[] shopItemContainer;
    public GameObject panelShop;
    bool isInMenu;

	void Start ()
    {
        for (int i = 0; i < shopItemContainer.Length; i++)
        {
            shopItemContainer[i].itemButton.transform.GetChild(0).GetComponent<Image>().sprite = shopItemContainer[i].itemSprite;
            shopItemContainer[i].itemButton.transform.GetChild(1).GetComponent<Text>().text = shopItemContainer[i].itemName;
            shopItemContainer[i].itemButton.transform.GetChild(2).GetComponent<Text>().text = shopItemContainer[i].itemPrice + "€";
        }
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

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public struct ShopItem
{
    public string itemName, itemPrice;
    public Sprite itemSprite;
    //public Mesh itemMesh;
}

public class MenuShop : MonoBehaviour {

    public ShopItem[] ShopItemContainer;
    Button[] buttonArray;
    Text textItem, priceItem;
    public GameObject panelShop;
    bool isInMenu;

	void Start ()
    {
        buttonArray = panelShop.GetComponentsInChildren<Button>();

        for (int i = 0; i < ShopItemContainer.Length; i++)
        {
            buttonArray[i].image.sprite = ShopItemContainer[i].itemSprite;
            textItem = buttonArray[i].GetComponentInChildren<Text>();
            textItem.GetComponentInChildren<Text>().text = "dick";
            textItem.text = ShopItemContainer[i].itemName;
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

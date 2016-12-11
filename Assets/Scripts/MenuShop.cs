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
    Text textItem;
    public GameObject panelShop;
    bool isInMenu;

	void Start ()
    {
        buttonArray = panelShop.GetComponentsInChildren<Button>();

        for (int i = 0; i < ShopItemContainer.Length; i++)
        {
            // Assegna la sprite corrispondente
            buttonArray[i].image.sprite = ShopItemContainer[i].itemSprite;
            // Prende il testo di ogni bottone...
            textItem = buttonArray[i].GetComponentInChildren<Text>();
            // ... e ci scrive sopra il nome
            textItem.text = ShopItemContainer[i].itemName;
            // Prende il prezzo, figlio di ogni nome...
            
            // ... e lo setta
            
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

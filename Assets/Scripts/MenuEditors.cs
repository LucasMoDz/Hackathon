using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

[Serializable]
public struct PanelEditors
{
    public string editorName, editorLevel;
    public Sprite editorSprite;
    public Button editorButton;
    //public Stats redattore;
}

public class MenuEditors : MonoBehaviour
{
    public GameObject panelStats;
    public GameObject editorPanel;

    StatsMenu refStatsmenu;
    public PanelEditors[] editorContainers;
        
    void Awake()
    {
        Debug.Log(this.gameObject);

        refStatsmenu = FindObjectOfType<StatsMenu>();
    }

    void Start()
    {
        for (int i = 0; i < editorContainers.Length; i++)
        {
            Stats mioRedattore = editorContainers[i].editorButton.GetComponent<Selector>().redattore.GetComponent<Stats>();
            editorContainers[i].editorButton.transform.GetChild(0).GetComponent<Image>().sprite = mioRedattore.image;
            editorContainers[i].editorButton.transform.GetChild(1).GetComponent<Text>().text = mioRedattore.nameof;
            editorContainers[i].editorButton.transform.GetChild(2).GetComponent<Text>().text = "Lv. " + mioRedattore.level;
        }
    }

   
}
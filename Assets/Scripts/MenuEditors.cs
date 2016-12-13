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
}

public class MenuEditors : MonoBehaviour
{
    public GameObject panelStats;
    public GameObject editorPanel;

    StatsMenu refStatsmenu;
    public PanelEditors[] editorContainers;
        
    void Awake()
    {
        refStatsmenu = FindObjectOfType<StatsMenu>();
    }

    void Start()
    {
        for (int i = 0; i < editorContainers.Length; i++)
        {
            editorContainers[i].editorButton.transform.GetChild(0).GetComponent<Image>().sprite = editorContainers[i].editorSprite;
            editorContainers[i].editorButton.transform.GetChild(1).GetComponent<Text>().text = editorContainers[i].editorName;
            editorContainers[i].editorButton.transform.GetChild(2).GetComponent<Text>().text = "Lv. " + editorContainers[i].editorLevel;
        }
    }
    
    public void GetStats()
    {
        Stats buttonPressed = EventSystem.current.currentSelectedGameObject.GetComponent<Stats>();
        panelStats.SetActive(true);
        //refStatsmenu.CallPanel(buttonPressed.name, buttonPressed.level.ToString(), buttonPressed.exp, buttonPressed.research, buttonPressed.typing, buttonPressed.editing, buttonPressed.network);
    }
}
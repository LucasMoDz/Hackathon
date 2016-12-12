using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public struct PanelEditors
{
    public string editorName, editorLevel;
    public Sprite editorSprite;
    public Button editorButton;
}

public class MenuEditors : MonoBehaviour
{
    public PanelEditors[] editorContainers;
    public GameObject editorPanel;
    bool isInMenu;

    void Start()
    {
        for (int i = 0; i < editorContainers.Length; i++)
        {
            editorContainers[i].editorButton.transform.GetChild(0).GetComponent<Image>().sprite = editorContainers[i].editorSprite;
            editorContainers[i].editorButton.transform.GetChild(1).GetComponent<Text>().text = editorContainers[i].editorName;
            editorContainers[i].editorButton.transform.GetChild(2).GetComponent<Text>().text = "Lv. " + editorContainers[i].editorLevel;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (!isInMenu)
            {
                editorPanel.SetActive(true);
                isInMenu = true;
            }
            else
            {
                editorPanel.SetActive(false);
                isInMenu = false;
            }
        }
    }
}
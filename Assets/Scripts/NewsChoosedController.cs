using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NewsChoosedController : MonoBehaviour
{
    private GameManager gm;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }

    public void SaveButton()
    {
        gm.newsChoosed.Add(EventSystem.current.currentSelectedGameObject.gameObject);
        EventSystem.current.currentSelectedGameObject.gameObject.GetComponent<CoroutineButton>().StopAllCoroutines();

        EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().fontStyle = FontStyle.Bold;
        EventSystem.current.currentSelectedGameObject.gameObject.GetComponent<Button>().interactable = false;
    }
}
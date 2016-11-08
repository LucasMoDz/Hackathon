using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NewsChoosedController : MonoBehaviour
{
    private GameManager gm;
    private Archive archive;
    //private SoundController refSC;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        archive = FindObjectOfType<Archive>();
        //refSC = FindObjectsOfType<SoundController>();
    }

    public void SaveButton()
    {
        //refSC.audioSource.Play();

        gm.buttonClicked++;
		Debug.Log (" " + gm.buttonClicked);

        if (!EventSystem.current.currentSelectedGameObject.gameObject.GetComponent<News>().isTrue)
            archive.listFalseNews.RemoveAt(EventSystem.current.currentSelectedGameObject.gameObject.GetComponent<CoroutineButton>().randomValue_2);
        else
            archive.listTrueNews.RemoveAt(EventSystem.current.currentSelectedGameObject.gameObject.GetComponent<CoroutineButton>().randomValue_2);

        gm.newsChoosed.Add(EventSystem.current.currentSelectedGameObject.gameObject);
        EventSystem.current.currentSelectedGameObject.gameObject.GetComponent<CoroutineButton>().StopAllCoroutines();
        
        EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().fontStyle = FontStyle.Bold;
        EventSystem.current.currentSelectedGameObject.gameObject.GetComponent<Button>().interactable = false;
    }
}
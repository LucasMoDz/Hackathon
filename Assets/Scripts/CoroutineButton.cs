using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoroutineButton : MonoBehaviour
{
    private Archive archive;
    private Calculator refCalculator;
    private GameManager refGM;

    public int randomValue_2;

    private void Awake()
    {
        archive = FindObjectOfType<Archive>();
        refCalculator = FindObjectOfType<Calculator>();
        refGM = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (refGM.AllButtonsAreClicked())
        {
			refGM.EndNewsPhase();
            StopAllCoroutines();
        }
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    public IEnumerator Spawn()
    {
        while (true)
        {
            this.gameObject.SetActive(true);

            ChooseList();
            
            float random = Random.Range(4, 8);

            yield return new WaitForSeconds(random);
            yield return null;
        }
    }
    
    private void ChooseList()
    {
        int randomValue = Random.Range(1, 101);

        // 70 % scelta lista vera, 30 % scelta lista falsa
        if (randomValue <= 70)
        {
            randomValue_2 = Random.Range(0, archive.listTrueNews.Count);

            // Lista vera
            this.gameObject.GetComponent<News>().isTrue = archive.listTrueNews[randomValue_2].isTrue;
            this.gameObject.GetComponent<News>().isInteresting = archive.listTrueNews[randomValue_2].isInteresting;
            this.gameObject.GetComponent<News>().titleNews = archive.listTrueNews[randomValue_2].titleNews;
        }

        else
        {
            randomValue_2 = Random.Range(0, archive.listFalseNews.Count);

            // Lista falsa
            this.gameObject.GetComponent<News>().isTrue = archive.listFalseNews[randomValue_2].isTrue;
            this.gameObject.GetComponent<News>().isInteresting = archive.listFalseNews[randomValue_2].isInteresting;
            this.gameObject.GetComponent<News>().titleNews = archive.listFalseNews[randomValue_2].titleNews;
        }

        // Aggiorno il testo del button
        this.gameObject.GetComponentInChildren<Text>().text = this.GetComponent<News>().titleNews;
        
        // Assegno un peso
        refCalculator.CalcNewsValue(this.GetComponent<News>());
    }
}
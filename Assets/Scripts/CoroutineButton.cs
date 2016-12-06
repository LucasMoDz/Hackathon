using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoroutineButton : MonoBehaviour
{
    private Archive archive;
    private Calculator refCalculator;
    private GameManager refGM;
    
    private bool test;

    private int sizeListTrue, sizeListFalse;
    private float random_second;
    public int randomValue_true;
    public int randomValue_false;
    RSSReader rssReader;

    private void Awake()
    {
        archive = FindObjectOfType<Archive>();
        refCalculator = FindObjectOfType<Calculator>();
        refGM = FindObjectOfType<GameManager>();
        
        random_second = Random.Range(4, 8);
        rssReader = new RSSReader("http://xml.corriereobjects.it/rss/homepage.xml");

        int nRandom = Random.Range(0, rssReader.channelNews.newsList.Count);
        this.gameObject.GetComponent<News>().titleNews = rssReader.channelNews.newsList[nRandom].title;
    }

    /*void Update()
    {
      
        sizeListFalse = archive.listFalseNews.Count - 1;
        sizeListTrue = archive.listTrueNews.Count - 1;
        
        // Aggiorno i valori random secondo la lunghezza della lista aggiornata
        randomValue_true = Random.Range(0, sizeListTrue);
        randomValue_false = Random.Range(0, sizeListFalse);
       
        
    }
     */
    private void Start()
    {
        StartCoroutine(Spawn());
    }
    
    public IEnumerator Spawn()
    {
        while (true)
        {
            // Soltanto la prima volta
            if (!test)
            {
                yield return new WaitForSeconds(0.1f);
                this.gameObject.SetActive(true);
                ChooseList();
                test = true;
            }
            
            yield return new WaitForSeconds(random_second);

            ChooseList();
            random_second = Random.Range(6, 9);
            
            yield return null;
        }
    }
    
    private void ChooseList()
    {
        /*
        int randomValue = Random.Range(1, 101);

        // 70 % scelta lista vera, 30 % scelta lista falsa
        if (randomValue <= 70)
        {
            // Lista vera
            this.gameObject.GetComponent<News>().isTrue = archive.listTrueNews[randomValue_true].isTrue;
            this.gameObject.GetComponent<News>().isInteresting = archive.listTrueNews[randomValue_true].isInteresting;
            this.gameObject.GetComponent<News>().titleNews = archive.listTrueNews[randomValue_true].titleNews;
        }
        else
        {
            // Lista falsa
            this.gameObject.GetComponent<News>().isTrue = archive.listFalseNews[randomValue_false].isTrue;
            this.gameObject.GetComponent<News>().isInteresting = archive.listFalseNews[randomValue_false].isInteresting;
            this.gameObject.GetComponent<News>().titleNews = archive.listFalseNews[randomValue_false].titleNews;
        }

        this.gameObject.GetComponentInChildren<Text>().text = this.GetComponent<News>().titleNews;
        
        // Assegno un peso
        refCalculator.CalcNewsValue(this.GetComponent<News>());
        */
        
        int nRandom = Random.Range(0, rssReader.channelNews.newsList.Count);
        this.gameObject.GetComponent<News>().titleNews = rssReader.channelNews.newsList[nRandom].title.Replace("\n", "").Replace("\r", "").Replace("\t", "");
        this.gameObject.GetComponentInChildren<Text>().text = this.GetComponent<News>().titleNews;
    }
}
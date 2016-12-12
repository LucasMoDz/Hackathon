using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CreateRSSList : MonoBehaviour
{
    public Image loadingImage;
    public Text loadingText;

    // VERO SOLTANTO QUANDO HA FINITO DI SCARICARE TUTTE LE NEWS, E' LA CONDIZIONE DELLO 'START'
    internal bool newsHaveBeenDownloaded;

    // Lista di notizie (classe) vere (con titolo, breve descrizione e link all'immagine) e di notizie false (solo titolo)
    internal List<News> totalNewsList;
    
    public int maxNews;

    private WWW connectionRequest;
    public RSSReader readerChronicle, readerEconomy, readerSport, readerEntertainment;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (FindObjectsOfType(GetType()).Length > 1)
            Destroy(this.gameObject);

        totalNewsList = new List<News>();

        StartCoroutine(LoadingCO());
    }

    private IEnumerator LoadingCO()
    {
        float myAlpha = 0;

        while (!newsHaveBeenDownloaded)
        {
            loadingImage.transform.Rotate(this.transform.forward, -11);

            myAlpha = Mathf.PingPong(Time.time, 1);
            loadingText.GetComponent<Text>().color = new Color(0, 0, 0, myAlpha);

            yield return new WaitForEndOfFrame();
        }

        loadingImage.gameObject.SetActive(false);
        loadingText.gameObject.SetActive(false);

        yield break;
    }
    
    private IEnumerator Start()
    {
        #region CreationList

        connectionRequest = new WWW("http://xml.corriereobjects.it/rss/cronache.xml");
        yield return connectionRequest;

        yield return new WaitForSeconds(0.5f);

        readerChronicle = new RSSReader(connectionRequest.url);
        yield return readerChronicle;

        foreach (var rssNewsChronicle in readerChronicle.newsList)
        {
            News news = new News(true, rssNewsChronicle.title, rssNewsChronicle.linkImage, rssNewsChronicle.description);

            if (news.titleNews != "")
                totalNewsList.Add(news);
        }
        
        connectionRequest = new WWW("http://xml.corriereobjects.it/rss/economia.xml");
        yield return connectionRequest;
        readerEconomy = new RSSReader(connectionRequest.url);
        yield return readerEconomy;

        foreach (var rssNewsEconomy in readerEconomy.newsList)
        {
            News news = new News(true, rssNewsEconomy.title, rssNewsEconomy.linkImage, rssNewsEconomy.description);

            if (news.titleNews != "")
                totalNewsList.Add(news);
        }

        connectionRequest = new WWW("http://xml.corriereobjects.it/rss/sport.xml");
        yield return connectionRequest;
        readerSport = new RSSReader(connectionRequest.url);
        yield return readerSport;

        foreach (var rssNewsSport in readerSport.newsList)
        {
            News news = new News(true, rssNewsSport.title, rssNewsSport.linkImage, rssNewsSport.description);

            if (news.titleNews != "")
                totalNewsList.Add(news);
        }
        
        connectionRequest = new WWW("http://xml.corriereobjects.it/rss/spettacoli.xml");
        yield return connectionRequest;
        readerEntertainment = new RSSReader(connectionRequest.url);
        yield return readerEntertainment;
        
        foreach (var rssNewsEntertainment in readerEntertainment.newsList)
        {
            News news = new News(true, rssNewsEntertainment.title, rssNewsEntertainment.linkImage, rssNewsEntertainment.description);

            if (news.titleNews != "")
                totalNewsList.Add(news);
        }

        newsHaveBeenDownloaded = true;
        
        if (maxNews > totalNewsList.Count)
            maxNews = totalNewsList.Count - 1;
        #endregion
    }
}
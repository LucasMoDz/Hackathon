using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateRSSList : MonoBehaviour
{
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
    }
    
    IEnumerator Start()
    {
        #region CreationList

        connectionRequest = new WWW("http://xml.corriereobjects.it/rss/cronache.xml");
        yield return connectionRequest;
        readerChronicle = new RSSReader(connectionRequest.url);

        foreach (var rssNewsChronicle in readerChronicle.channelNews.newsList)
        {
            News news = new News(true, rssNewsChronicle.title);

            if (news.titleNews != "")
                totalNewsList.Add(news);
        }

        Debug.Log("Le news di cronaca sono " + readerChronicle.channelNews.newsList.Count);

        connectionRequest = new WWW("http://xml.corriereobjects.it/rss/economia.xml");
        yield return connectionRequest;
        readerEconomy = new RSSReader(connectionRequest.url);

        foreach (var rssNewsEconomy in readerEconomy.channelNews.newsList)
        {
            News news = new News(true, rssNewsEconomy.title);

            if (news.titleNews != "")
                totalNewsList.Add(news);
        }

        Debug.Log("Le news di economia sono " + readerEconomy.channelNews.newsList.Count);

        connectionRequest = new WWW("http://xml.corriereobjects.it/rss/sport.xml");
        yield return connectionRequest;
        readerSport = new RSSReader(connectionRequest.url);

        foreach (var rssNewsSport in readerSport.channelNews.newsList)
        {
            News news = new News(true, rssNewsSport.title);

            if (news.titleNews != "")
                totalNewsList.Add(news);
        }

        Debug.Log("Le news di sport sono " + readerSport.channelNews.newsList.Count);

        connectionRequest = new WWW("http://xml.corriereobjects.it/rss/spettacoli.xml");
        yield return connectionRequest;
        readerEntertainment = new RSSReader(connectionRequest.url);

        foreach (var rssNewsEntertainment in readerEntertainment.channelNews.newsList)
        {
            News news = new News(true, rssNewsEntertainment.title);

            if (news.titleNews != "")
                totalNewsList.Add(news);
        }

        if (maxNews > totalNewsList.Count)
            maxNews = totalNewsList.Count - 1;

        Debug.Log("Le news d'intrattenimento sono " + readerEntertainment.channelNews.newsList.Count);
        #endregion

        Debug.Log("Le news totali sono " + totalNewsList.Count);
    }
}
using UnityEngine;

public class RSSTester : MonoBehaviour
{
	RSSReader rssEconomy, rssSport, rssReport, rssEntertainment;
    
    void Start ()
	{
		// Si collega al FeedRss del Corriere
		rssEconomy = new RSSReader("http://xml.corriereobjects.it/rss/economia.xml");
        //rssSport = new RSSReader("http://xml.corriereobjects.it/rss/sport.xml");
        //rssReport = new RSSReader("http://xml.corriereobjects.it/rss/cronache.xml");
        //rssEntertainment = new RSSReader("http://xml.corriereobjects.it/rss/spettacoli.xml");
        
        // Stampa le notizie
        foreach (RSSReader.News news in rssEconomy.channelNews.newsList)
		{
            //Debug.Log("Item Title: " + news.title);
			//Debug.Log("Item link: " + news.link);
			Debug.Log("Item description: " + news.description);
            Debug.Log("\n");
		}
        
        /*
        foreach (RSSReader.News news in rssSport.channelNews.newsList)
        {
            Debug.Log("Item Title: " + news.title.Replace("\n", "").Replace("\r", "").Replace("\t", ""));
            //Debug.Log("Item link: " + news.link);
            //Debug.Log("Item description: " + news.description);
            Debug.Log("\n");
        }

        foreach (RSSReader.News news in rssReport.channelNews.newsList)
        {
            Debug.Log("Item Title: " + news.title.Replace("\n", "").Replace("\r", "").Replace("\t", ""));
            //Debug.Log("Item link: " + news.link);
            //Debug.Log("Item description: " + news.description);
            Debug.Log("\n");
        }

        foreach (RSSReader.News news in rssEntertainment.channelNews.newsList)
        {
            Debug.Log("Item Title: " + news.title.Replace("\n", "").Replace("\r", "").Replace("\t", ""));
            //Debug.Log("Item link: " + news.link);
            //Debug.Log("Item description: " + news.description);
            Debug.Log("\n");
        }

        PolishString();
        */
    }
    
    private void PolishString()
    {
        string news = "Notizia del Corriere De&ABlla Sera";
        string charToRemove = "&AB";

        int index = news.IndexOf(charToRemove);
        news = news.Remove(index, charToRemove.Length);

        Debug.Log(news);
    }
}
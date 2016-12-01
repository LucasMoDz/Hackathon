using System.Collections.Generic;
using System.Xml;

public class RSSReader
{
    private const string RSS_STRING = "rss";
    private const string CHANNEL_STRING = "channel";
    private const string ITEM_STRING = "item";

    private const string TITLE_PARAM = "title";
    private const string LINK_PARAM = "link";
    private const string DESCRIPTION_PARAM = "description";

    XmlTextReader rssReader;
	XmlDocument xmlDoc;

	XmlNode nodeRss;
	XmlNode nodeChannel;
	XmlNode nodeItem;

	public Channel channelNews;
	
	// Channel padre di tutte le news (item)
	public struct Channel
	{
		public string title;
		public string link;
		public List<News> newsList;
	}
	
	// Le info di ogni news
	public struct News
	{
		public string title;
		public string link;
		public string description;
	}	
	
	// Costruttore che richiede l'URL come parametro
	public RSSReader (string _feedURL)
	{
		// Crea nuovo Channel
		channelNews = new Channel ();

        // Inizializza la lista all'interno della struct Channel
		channelNews.newsList = new List<News>();

        // Crea un nuovo Reader XML
		rssReader = new XmlTextReader(_feedURL);

        // Crea un nuovo documento XML
		xmlDoc = new XmlDocument();

        // Carica i dati dell'rssReader
        xmlDoc.Load(rssReader);

		// xmlDoc.ChildNodes.Count è il numero di RSS presente nel Feed
		for (int i = 0; i < xmlDoc.ChildNodes.Count; i++) 
		{
			// Apre la sezione RSS
			if (xmlDoc.ChildNodes[i].Name == RSS_STRING)
				nodeRss = xmlDoc.ChildNodes[i];
		}

		// nodeRss.ChildNodes.Count è il numero di Channel presenti nel Feed
		for (int i = 0; i < nodeRss.ChildNodes.Count; i++)
        {
			// Apre la sezione Channel
			if (nodeRss.ChildNodes[i].Name == CHANNEL_STRING)
				nodeChannel = nodeRss.ChildNodes[i];
		}

		// Sono le info del Channel
		channelNews.title = nodeChannel[TITLE_PARAM].InnerText;
		channelNews.link = nodeChannel[LINK_PARAM].InnerText;

		// nodeChannel.ChildNodes.Count è il numero di item presenti nel Feed
		for (int i = 0; i < nodeChannel.ChildNodes.Count; i++)
        {
            // Confronta il nome dei figli di Channel 
			if (nodeChannel.ChildNodes[i].Name == ITEM_STRING)
            {
                // Se è una notizia (item) la mette dentro un nodo
				nodeItem = nodeChannel.ChildNodes[i];

                // Crea una nuova notizia
				News item = new News();

                // Assegna il titolo della notizia
				item.title = nodeItem[TITLE_PARAM].InnerText;
                // Assegna il link della notizia
				item.link = nodeItem[LINK_PARAM].InnerText;
                // Assegna la descrizione della notizia
                item.description = nodeItem[DESCRIPTION_PARAM].InnerText;

                // Aggiunge la notizia creata alla lista di notizie
                channelNews.newsList.Add(item);
			}
		}
	}
}
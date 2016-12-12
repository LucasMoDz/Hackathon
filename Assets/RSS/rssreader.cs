using System.Collections.Generic;
using System.Xml;
using System;

public class RSSReader
{
    private int counter;

    XmlTextReader rssReader;
	XmlDocument xmlDoc;

	XmlNode nodeRss;
	XmlNode nodeChannel;
	XmlNode nodeItem;

	public Channel channelNews;
	
	// Channel padre di tutte le news (item)
	public struct Channel
	{
		//public string title;
		//public string link;
		public List<News> newsList;
	}
	
	// Le info di ogni news
	public struct News
	{
		public string title;
		//public string link;
		public string description;
        public string linkImage;
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
			if (xmlDoc.ChildNodes[i].Name == "rss")
				nodeRss = xmlDoc.ChildNodes[i];
		}

		// nodeRss.ChildNodes.Count è il numero di Channel presenti nel Feed
		for (int i = 0; i < nodeRss.ChildNodes.Count; i++)
        {
			// Apre la sezione Channel
			if (nodeRss.ChildNodes[i].Name == "channel")
				nodeChannel = nodeRss.ChildNodes[i];
		}
        
		// nodeChannel.ChildNodes.Count è il numero di item presenti nel Feed
		for (int i = 0; i < nodeChannel.ChildNodes.Count; i++)
        {
            counter = 0;
            // Confronta il nome dei figli di Channel 
			if (nodeChannel.ChildNodes[i].Name == "item")
            {
                // Se è una notizia (item) la mette dentro un nodo
				nodeItem = nodeChannel.ChildNodes[i];

                // Crea una nuova notizia
                News item = new News();
                
                char[] dirtyLink = nodeItem["info1"].InnerXml.ToCharArray();
                
                for (int j = 0; j < dirtyLink.Length; j++)
                {
                    if (String.Compare("\"", dirtyLink[j].ToString()) == 0)
                        counter++;

                    if (counter == 1 && String.Compare("\"", dirtyLink[j].ToString()) != 0)
                        item.linkImage += dirtyLink[j];
                    else if (counter == 2)
                        break;
                }
                
                UnityEngine.Debug.Log(item.linkImage);
                
                // Assegna il titolo della notizia
				item.title = nodeItem["title"].InnerText;
                // Assegna la descrizione della notizia
                item.description = nodeItem["description"].InnerText;

                // Aggiunge la notizia creata alla lista di notizie
                channelNews.newsList.Add(item);
            }
		}
	}

    private void PolishString(string _dirtyLink)
    {
        string charToRemove = "\"";

        int index = _dirtyLink.IndexOf(charToRemove);
        _dirtyLink = _dirtyLink.Remove(index, charToRemove.Length);
    }
}
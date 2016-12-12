using System.Collections.Generic;
using System.Xml;
using System;

public class RSSReader
{
    public List<News> newsList;

    private XmlTextReader rssReader;
	private XmlDocument xmlDoc;
    
    private XmlNode nodeRss, nodeChannel, nodeItem;
    
    private int counter;
    
	// Le info di ogni news
	public struct News
	{
		public string title;
		public string description;
        public string linkImage;
	}	
	
	// Costruttore che richiede l'URL come parametro
	public RSSReader (string _feedURL)
	{
        // Inizializza la lista delle notizie
		newsList = new List<News>();

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
            // Resetto il contatore per il link dell'immagine
            counter = 0;

            // Confronta il nome dei figli di Channel 
			if (nodeChannel.ChildNodes[i].Name == "item")
            {
                // Se è una notizia (item) la mette dentro un nodo
				nodeItem = nodeChannel.ChildNodes[i];

                // Crea una nuova notizia (struct)
                News item = new News();
                
                // Pulisce la stringa e ottiene i link delle immagini
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
                
                // Assegna il titolo della notizia
				item.title = nodeItem["title"].InnerText;
                // Assegna la descrizione della notizia
                item.description = nodeItem["description"].InnerText;

                // Aggiunge la notizia creata alla lista di notizie
                newsList.Add(item);
            }
		}
	}
}
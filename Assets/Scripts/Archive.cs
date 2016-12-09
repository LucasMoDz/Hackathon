using UnityEngine;
using System.Collections.Generic;

public class Archive : MonoBehaviour
{
    public List<News> listFalseNews;

    private void Awake()
    {
        listFalseNews = new List<News>();
        AddFalseNews();
    }

    private void AddFalseNews()
    {
        News news_1 = new News(false, "IOS vende il nuovo iPhone 7 al prezzo di 199€");
        News news_2 = new News(false, "Il Milan retrocede in serie B");
        News news_3 = new News(false, "Isis attacca Washington, distrutta la Casa Bianca");
        News news_4 = new News(false, "Ricostruito il muro di Berlino");
        News news_5 = new News(false, "Primo uomo sbarcato sul Sole");
        News news_6 = new News(false, "Attacco terroristico a Roma, distrutto il Colosseo");
        News news_7 = new News(false, "Uomo più alto del mondo: 2.70m");
        News news_8 = new News(false, "Clinton diventa presidente degli Stati Uniti");
        News news_9 = new News(false, "Presentato il nuovo iPhone 8");
        News news_10 = new News(false, "Kim Jong Un dichiara guerra al mondo");
        News news_11 = new News(false, "Valentino Rossi si ritira dalla Moto GP");
        News news_12 = new News(false, "Gli Oasis si riuniscono");
        News news_13 = new News(false, "Lionel Messi passa al Milan");
        News news_14 = new News(false, "Cristiano Ronaldo firma per il Virtus Entella");
        News news_15 = new News(false, "Microsoft, annunciato Windows 11");
        News news_16 = new News(false, "Ritorno di Loris Capirossi in 125cc");

        #region Add news on list
        listFalseNews.Add(news_1);
        listFalseNews.Add(news_2);
        listFalseNews.Add(news_3);
        listFalseNews.Add(news_4);
        listFalseNews.Add(news_5);
        listFalseNews.Add(news_6);
        listFalseNews.Add(news_7);
        listFalseNews.Add(news_8);
        listFalseNews.Add(news_9);
        listFalseNews.Add(news_10);
        listFalseNews.Add(news_11);
        listFalseNews.Add(news_12);
        listFalseNews.Add(news_13);
        listFalseNews.Add(news_14);
        listFalseNews.Add(news_15);
        listFalseNews.Add(news_16);
        #endregion
    }
}
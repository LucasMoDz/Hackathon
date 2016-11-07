using UnityEngine;
using System.Collections.Generic;

public class Archive : MonoBehaviour
{
    public List<News> listTrueNews;
    public List<News> listFalseNews;

    private void Awake()
    {
        listTrueNews = new List<News>();
        listFalseNews = new List<News>();

        AddTrueNews();
        AddFalseNews();
    }
    
    private void AddTrueNews()
    {
        News news_1 = new News(true, true, "Clinton vince su Trump");
        News news_2 = new News(true, false, "vnidjwefsfd");
        News news_11 = new News(true, false, "dsdddddd");
        News news_12 = new News(true, false, "zzzzzz");
        News news_13 = new News(true, false, "aaaaaa");
        News news_14 = new News(true, false, "Daniele");
        News news_16 = new News(true, false, "ggggggg");
        News news_17 = new News(true, false, "qqqqqq");
        News news_15 = new News(true, false, "yuuyuyuyuy");

        listTrueNews.Add(news_1);
        listTrueNews.Add(news_11);
        listTrueNews.Add(news_12);
        listTrueNews.Add(news_13);
        listTrueNews.Add(news_14);
        listTrueNews.Add(news_15);
        listTrueNews.Add(news_2);
        listTrueNews.Add(news_16);
        listTrueNews.Add(news_17);
    }

    private void AddFalseNews()
    {
        News news_3 = new News(false, false, "Primo uomo sbarcato sul Sole");
        News news_4 = new News(false, false, "Secondo uomo sbarcato sul Sole");
        News news_5 = new News(false, false, "Terzo uomo sbarcato sul Sole");
        News news_6 = new News(false, false, "Quarto uomo sbarcato sul Sole");
        News news_7 = new News(false, false, "Quinto uomo sbarcato sul Sole");
        News news_8 = new News(false, false, "Sesto uomo sbarcato sul Sole");
        News news_9 = new News(false, false, "Settimo uomo sbarcato sul Sole");
        News news_10 = new News(false, false, "Ottavo uomo sbarcato sul Sole");
        
        listFalseNews.Add(news_3);
        listFalseNews.Add(news_4);
        listFalseNews.Add(news_5);
        listFalseNews.Add(news_6);
        listFalseNews.Add(news_7);
        listFalseNews.Add(news_8);
        listFalseNews.Add(news_9);
        listFalseNews.Add(news_10);
    }
}
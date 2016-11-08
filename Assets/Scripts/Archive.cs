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
        News news_14 = new News(true, true, "Daniele");
        News news_15 = new News(true, false, "yuuyuyuyuy");
        News news_16 = new News(true, false, "ggggggg");
        News news_17 = new News(true, false, "we");
        News news_18 = new News(true, false, "qqqqffqq");
        News news_19 = new News(true, false, "qqqddddqqq");
        News news_20 = new News(true, false, "qqqddqqq");
        News news_21 = new News(true, false, "yt");
        News news_22 = new News(true, false, "qqqdqqq");
        News news_23 = new News(true, false, "trtr");
        News news_24 = new News(true, false, "qqqqqq");
        News news_25 = new News(true, false, "qfghtqqqqq");
        News news_26 = new News(true, false, "qqqqzqqq");
        News news_27 = new News(true, false, "qqqhthtqqq");
        News news_28 = new News(true, false, "zz");
        News news_29 = new News(true, false, "qqqqxcqq");
        News news_30 = new News(true, false, "ccv");

        listTrueNews.Add(news_1);
        listTrueNews.Add(news_2);
        listTrueNews.Add(news_11);
        listTrueNews.Add(news_12);
        listTrueNews.Add(news_13);
        listTrueNews.Add(news_14);
        listTrueNews.Add(news_15);
        listTrueNews.Add(news_16);
        listTrueNews.Add(news_17);
        listTrueNews.Add(news_18);
        listTrueNews.Add(news_19);
        listTrueNews.Add(news_20);
        listTrueNews.Add(news_21);
        listTrueNews.Add(news_22);
        listTrueNews.Add(news_23);
        listTrueNews.Add(news_24);
        listTrueNews.Add(news_25);
        listTrueNews.Add(news_26);
        listTrueNews.Add(news_27);
        listTrueNews.Add(news_28);
        listTrueNews.Add(news_29);
        listTrueNews.Add(news_30);
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

        News news_31 = new News(false, false, "Primo uomo sbarcato sul Sole");
        News news_32 = new News(false, false, "Secondo uomo sbarcato sul Sole");
        News news_33 = new News(false, false, "Terzo uomo sbarcato sul Sole");
        News news_34 = new News(false, false, "Quarto uomo sbarcato sul Sole");
        News news_35 = new News(false, false, "Quinto uomo sbarcato sul Sole");
        News news_36 = new News(false, false, "Sesto uomo sbarcato sul Sole");
        News news_37 = new News(false, false, "Settimo uomo sbarcato sul Sole");
        News news_38 = new News(false, false, "Ottavo uomo sbarcato sul Sole");
        News news_39 = new News(false, false, "Primo uomo sbarcato sul Sole");
        News news_40 = new News(false, false, "Secondo uomo sbarcato sul Sole");
        News news_41 = new News(false, false, "Terzo uomo sbarcato sul Sole");
        News news_42 = new News(false, false, "Quarto uomo sbarcato sul Sole");
        News news_43 = new News(false, false, "Quinto uomo sbarcato sul Sole");
        News news_44 = new News(false, false, "Sesto uomo sbarcato sul Sole");
        News news_45 = new News(false, false, "Settimo uomo sbarcato sul Sole");
        News news_46 = new News(false, false, "Ottavo uomo sbarcato sul Sole");

        listFalseNews.Add(news_3);
        listFalseNews.Add(news_4);
        listFalseNews.Add(news_5);
        listFalseNews.Add(news_6);
        listFalseNews.Add(news_7);
        listFalseNews.Add(news_8);
        listFalseNews.Add(news_9);
        listFalseNews.Add(news_10);

        listFalseNews.Add(news_31);
        listFalseNews.Add(news_32);
        listFalseNews.Add(news_33);
        listFalseNews.Add(news_34);
        listFalseNews.Add(news_35);
        listFalseNews.Add(news_36);
        listFalseNews.Add(news_37);
        listFalseNews.Add(news_38);
        listFalseNews.Add(news_39);
        listFalseNews.Add(news_40);
        listFalseNews.Add(news_41);
        listFalseNews.Add(news_42);
        listFalseNews.Add(news_43);
        listFalseNews.Add(news_44);
        listFalseNews.Add(news_45);
        listFalseNews.Add(news_46);
    }
}
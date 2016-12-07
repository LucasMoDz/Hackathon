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

        //AddTrueNews();
        AddFalseNews();
    }
    
    /*
    private void AddTrueNews()
    {
        News news_1 = new News(true, true, "Renzi: 'Non cacciamo nessuno dal PD'");
        News news_2 = new News(true, false, "Vegetariana da 22 anni prova la carne, ecco la sua reazione");
        News news_3 = new News(true, true, "Il Real Madrid vince la sua 11° Champion's League");
        News news_4 = new News(true, false, "Napoli, agguato nella notte. Morto 21 enne");
        News news_5 = new News(true, false, "Cane conteso tra due ex conviventi. Sarà affido condiviso");
        News news_6 = new News(true, false, "Roma, picchiato brutalmente da un pugile ubriaco");
        News news_7 = new News(true, true, "Iraq, 100 cadaveri decapitati trovati in una fossa comune a Mosul");
        News news_8 = new News(true, true, "Maltempo, Roma chiede stato d'emergenza");
        News news_9 = new News(true, true, "Sisma nel centro Italia, i morti salgono a 150");
        News news_10 = new News(true, true, "Brad Pitt divorzia da Angelina Jolie");
        News news_11 = new News(true, true, "Firenze: auto travolge pedoni, ferito bimbo di 20 mesi");
        News news_12 = new News(true, false, "Le imprese fallite durante la crisi");
        News news_13 = new News(true, true, "Ladispoli devastata da una tromba d'aria");
        News news_14 = new News(true, true, "Attacco terroristico a Parigi, più di 50 i morti");
        News news_15 = new News(true, false, "Diabete, un milione non sa di averlo");
        News news_16 = new News(true, false, "Migrante muore schiacciata per fare da scudo ai figli");
        News news_17 = new News(true, true, "Padre Cavalcoli: 'Terremoto punizione divina'");
        News news_18 = new News(true, false, "Milano, rubate 18 mila bici l'anno");
        News news_19 = new News(true, false, "In Kenya il primo concorso di bellezza per albini");
        News news_20 = new News(true, false, "Cucciolo salvato a Norcia diventerà cane da soccorso");
        News news_21 = new News(true, true, "USA, ecco come gli hacker possono agire");
        News news_22 = new News(true, false, "Sud Corea, un Samsung S7 esplode in un fast food");
        News news_23 = new News(true, false, "Guardia di finanza sequestra la casa di Corona");
        News news_24 = new News(true, false, "Fiat Panda sempre la più amata dagli italiani");
        News news_25 = new News(true, true, "Morto Bernardo Provenzano");
        News news_26 = new News(true, true, "Il matematico e il fisico che salvano i malati dal gioco");
        News news_27 = new News(true, false, "20 milioni di pellegrini a Roma per il Giubileo");
        News news_28 = new News(true, false, "La BCE svela la nuova banconota da 50 euro");
        News news_29 = new News(true, true, "Novara, uccide figlio disabile");
        News news_30 = new News(true, true, "Finto cieco da 24 anni ha incassato 256 mila euro");

        listTrueNews.Add(news_1);
        listTrueNews.Add(news_2);
        listTrueNews.Add(news_3);
        listTrueNews.Add(news_4);
        listTrueNews.Add(news_5);
        listTrueNews.Add(news_6);
        listTrueNews.Add(news_7);
        listTrueNews.Add(news_8);
        listTrueNews.Add(news_9);
        listTrueNews.Add(news_10);
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
    */

    private void AddFalseNews()
    {
        News news_1 = new News(false, false, "Renzi: 'Berlusconi è un idiota'");
        News news_2 = new News(false, false, "Il Milan retrocede in serie B");
        News news_3 = new News(false, false, "Isis attacca Washington, distrutta la Casa Bianca");
        News news_4 = new News(false, false, "Ricostruito il muro di Berlino");
        News news_5 = new News(false, false, "Primo uomo sbarcato sul Sole");
        News news_6 = new News(false, false, "Attacco terroristico a Roma, distrutto il Colosseo");
        News news_7 = new News(false, false, "Trump diventa presidente degli Stati Uniti");
        News news_8 = new News(false, false, "Clinton diventa presidente degli Stati Uniti");
        News news_9 = new News(false, false, "Presentato il nuovo iPhone 8");
        News news_10 = new News(false, false, "Kim Jong Un dichiara guerra al mondo");
        News news_11 = new News(false, false, "Valentino Rossi si ritira dalla Moto GP");
        News news_12 = new News(false, false, "Gli Oasis si riuniscono");
        News news_13 = new News(false, false, "Lionel Messi passa al Milan");
        News news_14 = new News(false, false, "Berlusconi: 'Renzi è un idiota'");
        News news_15 = new News(false, false, "Microsoft, annunciato Windows 11");
        News news_16 = new News(false, false, "Anonimo: 'Berlusconi e Renzi sono due idioti'");

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
    }
}
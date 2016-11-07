using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour {

    public Image upgradeBar;
    public Text nLevel;
    public Text nCoin;
    bool enabledUpgrade = false;
    bool lastUpgrade = false;
    //la variabile experience riceve l'esperienza ottenuta dal giocatore ed il sistema la gestisce 
    //facendolo salire di livello ed essendagli le giuste monete
    public float experience = 350;
    float currentLevel = 100;
    float currentExperience = 0;
    float percentual = 0;
    
    int Level = 0;
    int Coin = 0;
	
	void Start ()
    {
        Experience();
	
	}

    void Experience()
    {
        if (experience >= currentLevel)
        {
            enabledUpgrade = true;
            currentExperience = (experience - currentLevel);
            experience = currentExperience;
            Level += 1;
            UpgradeLevel();
            
        }
        else 
        {
            percentual = (100 / currentLevel * currentExperience) ;
            percentual /= 100;
            lastUpgrade = true;


        }


    }
    //Metodo che contiene i valori di ciascun livello
    void UpgradeLevel()
    {
        switch (Level)
        {
            case 1:
                currentLevel = 200;
                Coin = 20;
                break;
            case 2:
                currentLevel = 300;
                Coin = 40;
                break;
            case 3:
                currentLevel = 400;
                Coin = 60;
                break;
            case 4:
                currentLevel = 500;
                Coin = 80;
                break;
            case 5:
                currentLevel = 600;
                Coin = 100;
                break;
            case 6:
                currentLevel = 700;
                Coin = 120;
                break;
            case 7:
                currentLevel = 800;
                Coin = 140;
                break;
            case 8:
                currentLevel = 900;
                Coin = 160;
                break;
            case 9:
                currentLevel = 1000;
                Coin = 180;
                break;
            case 10:
                currentLevel = 1100;
                Coin = 200;
                break;



        }
    }
	
	//Gestione in fase di update della barra di esperienza
	void Update ()
    {
        if (enabledUpgrade == true)
        {
            upgradeBar.fillAmount += 0.01f;
            if (upgradeBar.fillAmount == 1)
            {
                enabledUpgrade = false;
                upgradeBar.fillAmount = 0;
                nLevel.text = Level.ToString();
                nCoin.text = Coin.ToString();
                Experience();
            }
        }
        if (lastUpgrade == true)
        {
            if (upgradeBar.fillAmount < percentual)
            {
                upgradeBar.fillAmount += 0.01f;
            }
            else
                lastUpgrade = false;
                
        }
	
	}
}

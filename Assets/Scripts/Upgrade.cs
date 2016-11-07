using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour {

    public Image upgradeBar;
    public Text nLevel;
    bool enabledUpgrade = false;
    bool lastUpgrade = false;
    //la variabile experience riceve l'esperienza ottenuta dal giocatore e la gestisce facendolo salire di livello
    public float experience = 350;
    float currentLevel = 100;
    float currentExperience = 0;
    float percentual = 0;
    
    int Level = 1;
	
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
            case 2:
                currentLevel = 200;
                break;
            case 3:
                currentLevel = 300;
                break;
            case 4:
                currentLevel = 400;
                break;
            case 5:
                currentLevel = 500;
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

using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class StatsMenu : MonoBehaviour
{
    bool active = true;
    public RectTransform panel;
    public Text name;
    public Text level;
    public Slider experience;
    public Slider research;
    public Slider typing;
    public Slider editing;
    public Slider network;


    void Start()
    {

    }


  

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out hit) && active)
            {
               
                if (hit.collider.name == "redattore" && active == true)
                {
                        active = false;
                        CallPanel(hit.transform.GetComponent<Stats>().name, 
                        hit.transform.GetComponent<Stats>().level.ToString(), 
                        hit.transform.GetComponent<Stats>().exp,
                        hit.transform.GetComponent<Stats>().research,
                        hit.transform.GetComponent<Stats>().typing,
                        hit.transform.GetComponent<Stats>().editing,
                        hit.transform.GetComponent<Stats>().network);
                }

                
            }
           
        }

    }

    public void CallPanel(string nome,  string livello, float exp, float search, float type, float edit, float net)
    {
        
        panel.gameObject.SetActive(true);
        name.text = nome;
        level.text = livello;
        experience.value = exp / 1000;
        research.value = search / 1000;
        typing.value = type / 1000;
        editing.value = edit / 1000;
        network.value = net / 1000;
        active = true;
    }

    public void ClosePanel()
    {
        panel.gameObject.SetActive(false);
        
    }

    


}

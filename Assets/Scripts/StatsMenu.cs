using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class StatsMenu : MonoBehaviour
{
    public bool active = true;
    public RectTransform panel;
    public Image photo;
    public Text myName;
    public Text level;
    public Text digital;
    public Text type;
    public Text graph;
    public Text fame;
    /*public Slider experience;
    public Slider research;
    public Slider typing;
    public Slider editing;
    public Slider network;*/


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
               
				if (hit.collider.tag == "Redattore" && active == true)
                {
                        active = false;
                    /*CallPanel(hit.transform.GetComponent<Stats>().name, 
                    hit.transform.GetComponent<Stats>().level.ToString(), 
                    hit.transform.GetComponent<Stats>().exp,
                    hit.transform.GetComponent<Stats>().research,
                    hit.transform.GetComponent<Stats>().typing,
                    hit.transform.GetComponent<Stats>().editing,
                    hit.transform.GetComponent<Stats>().network);*/

                    CallPanelNew(hit.transform.GetComponent<Stats>().nameof,
                            hit.transform.GetComponent<Stats>().image,
                            hit.transform.GetComponent<Stats>().level,
                            hit.transform.GetComponent<Stats>().digitale,
                            hit.transform.GetComponent<Stats>().typewriting,
                            hit.transform.GetComponent<Stats>().graphics,
                            hit.transform.GetComponent<Stats>().fama);
                }

                
            }
           
        }

    }



    /*public void CallPanel(string nome, , string livello, float exp, float search, float type, float edit, float net)
    {
        
        panel.gameObject.SetActive(true);
        myName.text = nome;
        level.text = livello;
        experience.value = exp / 1000;
        research.value = search / 1000;
        typing.value = type / 1000;
        editing.value = edit / 1000;
        network.value = net / 1000;
        
    }*/

    public void CallPanelNew(string nome, Sprite s, int livello, float digitale, float typewriting, float graphics, float fama)
    {
        
        panel.gameObject.SetActive(true);
        myName.text = nome.ToString();
        photo.GetComponent<Image>().sprite = s;
        level.text = livello.ToString();
        digital.text = digitale.ToString();
        type.text = typewriting.ToString();
        graph.text = graphics.ToString();
        fame.text = fama.ToString(); 


    }

    public void ClosePanel()
    {
        panel.gameObject.SetActive(false);
        active = true;

    }

    


}

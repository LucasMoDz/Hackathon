using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class StatsMenu : MonoBehaviour
{
    bool active = true;
    public RectTransform panel;
    public Text level;

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
                    CallPanel(hit.transform.GetComponent<Stats>().level.ToString());
                }


            }
           
        }

    }

    public void CallPanel(string livello)
    {
        
        active = true;
        panel.gameObject.SetActive(true);
        level.text = livello;
    }

    public void ClosePanel()
    {
        panel.gameObject.SetActive(false);
    }


}

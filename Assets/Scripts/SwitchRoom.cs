using UnityEngine;
using System.Collections;

public class SwitchRoom : MonoBehaviour
{

    public GameObject fatherRoom;
    public bool switchEnabled = false;
    Transform targetTr;
    int focus = 1;
    public Transform Dx;
    public Transform Sx;
    public Transform Center;



    void Start()
    {
        //transform.position = Vector3.Lerp(transform.position, fatherRoom.transform.GetChild(0).position, Time.deltaTime / 2);

        targetTr = Center;
       // StartCoroutine(Switch());
    }



    IEnumerator Switch()
    {
        switchEnabled = true;

        yield return new WaitForSeconds(2);

        switchEnabled = false;


    }

    public void DxButton()
    {
        if (focus == 2 && switchEnabled == false)
        {
            focus = 1;
            targetTr = Center;
            StartCoroutine(Switch());

        }
        else if (focus == 1 && switchEnabled == false)
        {
            focus = 0;
            targetTr = Dx;
            StartCoroutine(Switch());

        }

    }

    public void SxButton()
    {
        if (focus == 0 && switchEnabled == false)
        {
            focus = 1;
            targetTr = Center;
            StartCoroutine(Switch());

        }
        else if (focus == 1 && switchEnabled == false)
        {
            focus = 2;
            targetTr = Sx;
            StartCoroutine(Switch());

        }

    }

    void Update()
    {


        if (switchEnabled == true)
            transform.position = Vector3.Lerp(transform.position, targetTr.position, Time.deltaTime / 2);



    }
}
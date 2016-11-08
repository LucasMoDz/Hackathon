using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopUp : MonoBehaviour {

    Transform targetTr;
    public GameObject A;
    public GameObject B;
    public int speed = 2;
    bool move = false;
    public int coinInButton = 0;
    public Text addCoinText;
    

    void Start ()
    {
        targetTr = A.transform;
       // PopUpActive();
       


    }
	
    public void AddCoin()
    {
        addCoinText.text = coinInButton.ToString();
    }

    public void PopUpActive()
    {
        if (move == false)
        {
            move = true;
            StartCoroutine(stopPopUp());
        }
    }

    IEnumerator stopPopUp()
    {
        yield return new WaitForSeconds(0.9f);

        move = false;
        targetTr = A.transform;
    }
	
	void Update ()
    {
        Vector3 distance = targetTr.position - this.transform.position;
        Vector3 direction = distance.normalized;

        if(move == true)
            transform.position = transform.position + direction * 35 * speed * Time.deltaTime;

        if (distance.magnitude < 0.8f)
        {
            targetTr = B.transform;

        }
      /*  else if (distance.magnitude < 0.8f && targetTr == B)
        {
            
            targetTr = A.transform;
            move = false;


        }*/

    }
}

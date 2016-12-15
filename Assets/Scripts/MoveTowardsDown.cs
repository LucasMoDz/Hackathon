using UnityEngine;
using System.Collections;

public class MoveTowardsDown : MonoBehaviour
{
    private bool moving;
    internal bool moveUp;

    public GameObject panel;
    public Transform targetB;
    public Transform targetA;
    public float velocityScroll;
    
	public void StartMovementOfPanel()
    {
        if (!moving)
        {
            if (!moveUp)
                StartCoroutine(MoveTowardsDownCO());
            else
                StartCoroutine(MoveTowardsUpCO());
        }
    }
	
    private IEnumerator MoveTowardsDownCO()
    {
        panel.SetActive(true);
        moveUp = !moveUp;
        moving = true;
        
        while ((panel.GetComponent<Transform>().position - targetB.position).magnitude > 5f)
        {
            float step = velocityScroll * Time.deltaTime;
            panel.GetComponent<Transform>().position = Vector2.Lerp(panel.GetComponent<Transform>().position, targetB.position, step); //Vector3.MoveTowards(panel.GetComponent<Transform>().position, targetB.position, step);
            yield return null;
        }

        panel.GetComponent<Transform>().position = targetB.position;
        moving = false;
        yield break;
    }

    private IEnumerator MoveTowardsUpCO()
    {
        panel.SetActive(true);
        moveUp = !moveUp;
        moving = true;

        while ((panel.GetComponent<Transform>().position - targetA.position).magnitude > 5f)
        {
            float step = velocityScroll * Time.deltaTime;
            panel.GetComponent<Transform>().position = Vector2.Lerp(panel.GetComponent<Transform>().position, targetA.position, step);//Vector3.MoveTowards(panel.GetComponent<Transform>().position, targetA.position, step);
            yield return null;
        }

        panel.GetComponent<Transform>().position = targetA.position;
        moving = false;
        yield break;
    }
}
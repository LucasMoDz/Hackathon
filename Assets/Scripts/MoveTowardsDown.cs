using UnityEngine;
using System.Collections;

public class MoveTowardsDown : MonoBehaviour
{
    private bool moving;
    internal bool moveUp;

    public GameObject panel;
    public Transform targetB;
    public Transform targetA;
    public byte velocityScroll;
    
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
        
        while ((panel.GetComponent<Transform>().position - targetB.position).magnitude > 15f)
        {
            panel.GetComponent<RectTransform>().position -= new Vector3(0, 12) * Time.deltaTime * velocityScroll;
            yield return new WaitForEndOfFrame();
        }

        moving = false;
        yield break;
    }

    private IEnumerator MoveTowardsUpCO()
    {
        panel.SetActive(true);
        moveUp = !moveUp;
        moving = true;

        while ((panel.GetComponent<Transform>().position - targetA.position).magnitude > 20f)
        {
            panel.GetComponent<RectTransform>().position += new Vector3(0, 12) * Time.deltaTime * velocityScroll;
            yield return new WaitForEndOfFrame();
        }

        moving = false;
        yield break;
    }
}
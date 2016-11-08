using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// VA INSERITO IN VECTORUP
public class SwitchRoom : MonoBehaviour
{
    private GameManager refGM;

    public Text text;

    private GameObject room;
    private int angleRotation = 90;
    private bool isMoving;

    private int index = 0;

    private string[] titleDrafting = new string[4];

    private void Awake()
    {
        room = this.gameObject;
        refGM = FindObjectOfType<GameManager>();

        titleDrafting[0] = "Cronaca";
        titleDrafting[1] = "Sport";
        titleDrafting[2] = "Intrattenimento";
        titleDrafting[3] = "Economia";

        //text.text = titleDrafting[0];
        //refGM.descrizioneRoom.GetComponent<Text>().text = titleDrafting[0];
    }

    public void RotateClockwise()
    {
        if (!isMoving)
            StartCoroutine(RotateClockwiseCO());
    }

    public void RotateCounterClockwise()
    {
        if (!isMoving)
            StartCoroutine(RotateCounterClockwiseCO());
    }

    public IEnumerator RotateClockwiseCO()
    {
        IndexIncrease();
        RefreshTextTite();

        while (angleRotation != 0)
        {
            isMoving = true;
            room.transform.Rotate(room.transform.up, 1);
            angleRotation -= 1;

            yield return null;
        }

        isMoving = false;
        angleRotation = 90;
        yield break;
    }

    public IEnumerator RotateCounterClockwiseCO()
    {
        IndexDecrease();
        RefreshTextTite();

        while (angleRotation != 0)
        {
            isMoving = true;
            room.transform.Rotate(room.transform.up, -1);
            angleRotation -= 1;

            yield return null;
        }

        isMoving = false;
        angleRotation = 90;
        yield break;
    }

    private void RefreshTextTite()
    {
        //refGM.descrizioneRoom.GetComponent<Text>().text = titleDrafting[index];
        //text.text = titleDrafting[index];
    }

    private void IndexIncrease()
    {
        if (index != titleDrafting.Length - 1)
            index++;
        else
            index = 0;
    }

    private void IndexDecrease()
    {
        if (index != 0)
            index--;
        else
            index = titleDrafting.Length - 1;
    }
}
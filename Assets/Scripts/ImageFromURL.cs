using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageFromURL : MonoBehaviour
{
    public string url = "http://images.earthcam.com/ec_metros/ourcams/fridays.jpg";

    IEnumerator Start()
    {
        WWW www = new WWW(url);
        yield return www;

        this.GetComponent<Image>().sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), Vector2.zero);

        yield break;
    }
}
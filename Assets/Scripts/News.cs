using UnityEngine;

[System.Serializable]
public class News : MonoBehaviour
{
    public bool isTrue;
    public string titleNews, linkImage, description;
    
    public News(bool _isTrue, string _titleNews, string _linkImage, string _description)
    {
        isTrue = _isTrue;
        titleNews = _titleNews;
        linkImage = _linkImage;
        description = _description;
    }
}
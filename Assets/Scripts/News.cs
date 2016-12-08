using UnityEngine;

[System.Serializable]
public class News : MonoBehaviour
{
    public bool isTrue;
    public string titleNews;
    //public int weight;
    
    public News(bool _isTrue, string _titleNews)
    {
        isTrue = _isTrue;
        titleNews = _titleNews;
    }
}
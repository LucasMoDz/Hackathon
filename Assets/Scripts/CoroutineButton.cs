using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoroutineButton : MonoBehaviour
{
    private CreateRSSList listRSSCreated;
    private Archive archive;

    private bool test;
    private float random_second;
    private int nRandom;
    
    private void Awake()
    {
        listRSSCreated = FindObjectOfType<CreateRSSList>();
        archive = FindObjectOfType<Archive>();
    }
    
	private void OnEnable()
	{
		StartCoroutine(Spawn());
	}

    public IEnumerator Spawn()
    {
        random_second = Random.Range(4, 8);

        while (true)
        {
            // Soltanto la prima volta
            if (!test)
            {
                yield return new WaitForSeconds(0.1f);
                this.gameObject.SetActive(true);
                ChooseList();
                test = true;
            }
            
            yield return new WaitForSeconds(random_second);

            ChooseList();
            random_second = Random.Range(6, 9);
            
            yield return null;
        }
    }
    
    private void ChooseList()
    {
        int randomValue = Random.Range(1, 101);

        // 70 % scelta lista vera, 30 % scelta lista falsa
        if (randomValue <= 80)
        {
            nRandom = Random.Range(0, listRSSCreated.maxNews);
            this.gameObject.GetComponent<News>().titleNews = listRSSCreated.totalNewsList[nRandom].titleNews.Replace("\n", "").Replace("\r", "").Replace("\t", "");
			this.gameObject.GetComponent<News>().description = listRSSCreated.totalNewsList[nRandom].description.Replace("\n", "").Replace("\r", "").Replace("\t", "");
			this.gameObject.GetComponent<News>().linkImage = listRSSCreated.totalNewsList[nRandom].linkImage;
        }
        else
        {
            // Lista falsa
            nRandom = Random.Range(0, archive.listFalseNews.Count);
            this.gameObject.GetComponent<News>().titleNews = archive.listFalseNews[nRandom].titleNews;
        }

        this.gameObject.GetComponentInChildren<Text>().text = this.GetComponent<News>().titleNews;
    }
}
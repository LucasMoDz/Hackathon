using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour
{
    public void FadeIn(CanvasGroup _canvasGroup)
    {
        StartCoroutine(FadeInCO(_canvasGroup));
    }

    public void FadeOut(CanvasGroup _canvasGroup)
    {
        StartCoroutine(FadeOutCO(_canvasGroup));
    }

    private IEnumerator FadeInCO(CanvasGroup _canvasGroup)
    {
        while (_canvasGroup.alpha < 1)
        {
            _canvasGroup.alpha += 0.001f;
            yield return null;
        }

        yield break;
    }

    private IEnumerator FadeOutCO(CanvasGroup _canvasGroup)
    {
        while (_canvasGroup.alpha > 0)
        {
            _canvasGroup.alpha -= 0.001f;
            yield return null;
        }

        yield break;
    }
}
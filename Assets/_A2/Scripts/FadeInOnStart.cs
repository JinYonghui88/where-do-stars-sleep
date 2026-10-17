using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOnStart : MonoBehaviour
{
    public float duration = 1f;
    private Graphic graphic;

    private void Start()
    {
        graphic = GetComponent<Graphic>();

        if (graphic != null)
        {
            StartCoroutine(FadeInRoutine());
        }
    }

    private IEnumerator FadeInRoutine()
    {
        Color startColor = graphic.color;
        Color targetColor = startColor;
        targetColor.a = 1f;
        startColor.a = 0f;
        graphic.color = startColor;

        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            graphic.color = Color.Lerp(startColor, targetColor, t / duration);
            yield return null;
        }

        graphic.color = targetColor;
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PulseOnClick : MonoBehaviour
{
    public float growScale = 1.15f;
    public float duration = 0.35f;
    public bool canRepeat = true;

    private Button button;
    private bool isPlaying;

    private void Awake()
    {
        button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(StartPulse);
        }
    }

    public void StartPulse()
    {
        if (!canRepeat && isPlaying)
        {
            return;
        }

        StartCoroutine(PulseRoutine());
    }

    private IEnumerator PulseRoutine()
    {
        isPlaying = true;
        Vector3 startScale = transform.localScale;
        Vector3 targetScale = startScale * growScale;
        float halfDuration = duration * 0.5f;

        for (float t = 0f; t < halfDuration; t += Time.deltaTime)
        {
            transform.localScale = Vector3.Lerp(startScale, targetScale, t / halfDuration);
            yield return null;
        }

        transform.localScale = targetScale;

        for (float t = 0f; t < halfDuration; t += Time.deltaTime)
        {
            transform.localScale = Vector3.Lerp(targetScale, startScale, t / halfDuration);
            yield return null;
        }

        transform.localScale = startScale;
        isPlaying = false;
    }
}

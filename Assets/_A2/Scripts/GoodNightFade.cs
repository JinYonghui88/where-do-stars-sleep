using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoodNightFade : MonoBehaviour
{
    public Image fadeImage;        // 把全屏黑色 Image 拖进来
    public float fadeTime = 3f;    // 淡出几秒
    public string nextScene;       // Credits 场景名（和场景文件一字不差）

    private bool triggered = false;

    private void Awake()
    {
        if (fadeImage != null)
        {
            Color c = fadeImage.color; c.a = 0f;
            fadeImage.color = c;       // 开场全透明
        }
        Button btn = GetComponent<Button>();
        if (btn != null) btn.onClick.AddListener(GoodNight);
    }

    public void GoodNight()
    {
        if (triggered) return;         // 防止连点
        triggered = true;
        StartCoroutine(FadeAndGo());
    }

    private IEnumerator FadeAndGo()
    {
        Color c = fadeImage.color;
        for (float t = 0f; t < fadeTime; t += Time.deltaTime)
        {
            c.a = Mathf.Lerp(0f, 1f, t / fadeTime);
            fadeImage.color = c;
            yield return null;
        }
        c.a = 1f; fadeImage.color = c;
        SceneManager.LoadScene(nextScene);
    }
}
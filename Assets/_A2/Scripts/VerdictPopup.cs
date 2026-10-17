using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class VerdictPopup : MonoBehaviour
{
    public Graphic target;            // 把 VerdictText 拖进这里
    public float fadeInTime = 0.8f;   // 淡入几秒
    public float showTime = 2.5f;     // 停留几秒
    public float fadeOutTime = 1f;    // 淡出几秒

    private Button button;
    private Coroutine current;
    private Color baseColor;

    private void Awake()
    {
        button = GetComponent<Button>();
        if (button != null)
            button.onClick.AddListener(OnStarTapped);

        if (target != null)
        {
            baseColor = target.color;          // 记住本来的颜色
            baseColor.a = 1f;                  // 淡入终点强制不透明，防止字幕永不出现
            Color c = baseColor; c.a = 0f;
            target.color = c;                  // 开局先完全透明
        }
    }

    public void OnStarTapped()
    {
        if (target == null) return;
        if (current != null) StopCoroutine(current);  // 已显示中就重新来一遍
        current = StartCoroutine(ShowAndHide());
    }

    private IEnumerator ShowAndHide()
    {
        Color c = baseColor;

        for (float t = 0f; t < fadeInTime; t += Time.deltaTime)
        {
            c.a = Mathf.Lerp(0f, baseColor.a, t / fadeInTime);
            target.color = c;
            yield return null;
        }
        c.a = baseColor.a; target.color = c;

        yield return new WaitForSeconds(showTime);    // 停留

        for (float t = 0f; t < fadeOutTime; t += Time.deltaTime)
        {
            c.a = Mathf.Lerp(baseColor.a, 0f, t / fadeOutTime);
            target.color = c;
            yield return null;
        }
        c.a = 0f; target.color = c;
    }
}
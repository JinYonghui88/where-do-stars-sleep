using UnityEngine;
using UnityEngine.UI;

public class PlaySFXOnClick : MonoBehaviour
{
    public AudioClip clip;
    public Button button;

    private void Awake()
    {
        Debug.Log(gameObject.name + " 接线成功！");
        if (button == null)
        {
            button = GetComponent<Button>();
        }

        if (button != null)
        {
            button.onClick.AddListener(Play);
        }
    }

    public void Play()
    {
        Debug.Log(gameObject.name + " 的 Play() 跑了");
        if (AudioManager.Instance != null && clip != null)
        {
            AudioManager.Instance.PlaySFX(clip);
        }
    }
}
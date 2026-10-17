using UnityEngine;
using UnityEngine.UI;

public class MuteToggle : MonoBehaviour
{
    private bool muted = false;

    private void Awake()
    {
        Button btn = GetComponent<Button>();
        if (btn != null) btn.onClick.AddListener(ToggleMute);
    }

    private void ToggleMute()
    {
        muted = !muted;
        AudioListener.pause = muted;
    }
}
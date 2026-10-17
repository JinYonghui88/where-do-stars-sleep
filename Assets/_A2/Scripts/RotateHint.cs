using UnityEngine;

public class RotateHint : MonoBehaviour
{
    public GameObject hintPanel;   // 把竖屏提示面板拖进来

    private void Update()
    {
        if (hintPanel == null) return;
        hintPanel.SetActive(Screen.height > Screen.width);   // 竖屏才显示
    }
}
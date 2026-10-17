using UnityEngine;
using UnityEngine.UI;

public class RevealOnClick : MonoBehaviour
{
    public GameObject objectToReveal;
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        if (button != null) button.onClick.AddListener(Reveal);
    }

    public void Reveal()
    {
        if (objectToReveal != null)
            objectToReveal.SetActive(true);
    }
}
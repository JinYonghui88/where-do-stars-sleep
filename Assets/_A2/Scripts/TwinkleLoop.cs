using UnityEngine;

public class TwinkleLoop : MonoBehaviour
{
    public float minScale = 0.92f;
    public float maxScale = 1.08f;
    public float speed = 2f;

    private Vector3 baseScale;
    private float phase;

    private void Start()
    {
        baseScale = transform.localScale;
        phase = Random.value * Mathf.PI * 2f;
    }

    private void Update()
    {
        float wave = (Mathf.Sin(Time.time * speed + phase) + 1f) * 0.5f;
        float scale = Mathf.Lerp(minScale, maxScale, wave);
        transform.localScale = baseScale * scale;
    }
}

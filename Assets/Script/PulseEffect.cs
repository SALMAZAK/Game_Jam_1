using UnityEngine;
using UnityEngine.UI;

public class PulseEffect : MonoBehaviour
{
    public float pulseSpeed = 2f;
    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        float scale = Mathf.PingPong(Time.time * pulseSpeed, 0.2f) + 1f;
        transform.localScale = originalScale * scale;
    }
}
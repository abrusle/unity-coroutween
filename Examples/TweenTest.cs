using Abrusle.CorouTween;
using UnityEngine;

public class TweenTest : MonoBehaviour
{
    [SerializeField] private float duration = 2, startX = 0, endX = 0;

    private Tween _tween;

    private void Awake()
    {
        _tween = new Tween(this, SlideUpdate, duration);
    }

    private void OnEnable()
    {
        _tween.Play(duration);
    }

    private void OnDisable()
    {
        _tween.Stop();
    }

    private void SlideUpdate(float t)
    {
        Vector3 localPosition = transform.localPosition;
        localPosition.x = Mathf.Lerp(startX, endX, t);
        transform.localPosition = localPosition;
    }
}

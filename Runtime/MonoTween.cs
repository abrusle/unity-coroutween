using System;
using UnityEngine;

public class MonoTween : MonoBehaviour, ITween
{
    /// <inheritdoc />
    public event Action AnimationComplete;

    [SerializeField] private float duration;
    [SerializeField] private bool playWhenEnabled;
    
    private Tween _tween;

    private void Awake()
    {
        _tween = new Tween(this);
    }

    private void OnEnable()
    {
        if (playWhenEnabled)
            _tween.Play(duration, StepAnimation);
    }

    private void OnDisable()
    {
        _tween.Stop();
    }

    /// <inheritdoc />
    public void Play(float duration, CorouTween.UpdateAnimationDelegate update = null)
    {
        _tween.Play(duration, update);
    }

    /// <inheritdoc />
    public void Stop()
    {
        _tween.Stop();
    }

    protected virtual void StepAnimation(float t)
    {
        
    }
}
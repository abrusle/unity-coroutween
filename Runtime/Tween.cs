using System;
using UnityEngine;
using static CorouTween;

public class Tween : ITween
{
    public event Action AnimationComplete;

    private UpdateAnimationDelegate UpdateDelegate
    {
        get => _update;
        set
        {
            if (value == _update) return;
            KillTween();
            _update = value;
        }
    }
    
    private Coroutine _coroutine;
    private UpdateAnimationDelegate _update;
    
    private readonly MonoBehaviour _targetBehaviour;

    public Tween(MonoBehaviour targetBehaviour, UpdateAnimationDelegate update = null)
    {
        _targetBehaviour = targetBehaviour;
        _update = update;
    }

    public void Play(float duration, UpdateAnimationDelegate update = null)
    {
        KillTween();
        
        _coroutine = _targetBehaviour.StartTween(duration, update ?? _update, OnComplete);
    }

    public void Stop()
    {
        KillTween();
    }

    private void KillTween()
    {
        if (_coroutine != null)
            _targetBehaviour.StopCoroutine(_coroutine);
    }

    private void OnComplete()
    {
        AnimationComplete?.Invoke();
    }
}
using System;
using System.Collections;
using UnityEngine;

public static class CorouTween
{
    public delegate void UpdateAnimationDelegate(float normalizedTime);

    public static Coroutine StartTween(this MonoBehaviour mono, float duration, UpdateAnimationDelegate update,
        Action onComplete = null)
    {
        return mono.StartCoroutine(AnimationRoutine());

        IEnumerator AnimationRoutine()
        {
            float startTime = Time.time;
            float endTime = startTime + duration;
                
            while (Time.time <= endTime)
            {
                float t = Mathf.InverseLerp(startTime, endTime, Time.time);
                update(t);
                yield return null;
            }

            update(1);
            
            onComplete?.Invoke();
        }
    }
}
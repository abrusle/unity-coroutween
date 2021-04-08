using System;
using System.Collections;
using UnityEngine;

namespace Abrusle.CorouTween
{
    public static class TweeningUtility
    {
        /// <summary>
        /// Delegate for updating objects in an animation loop.
        /// </summary>
        /// <param name="normalizedTime">Current time in the animation normalized between 0 and 1.</param>
        public delegate void UpdateAnimationDelegate(float normalizedTime);

        /// <summary>
        /// Start a coroutine-based animation hosted on the given MonoBehaviour.
        /// </summary>
        /// <param name="mono">The MonoBehaviour responsible for the animation.</param>
        /// <param name="duration">The duration of the animation in seconds.</param>
        /// <param name="update">Action called every frame of the animation. The callback is supplies with the normalizedTime of the animation.</param>
        /// <param name="onComplete">Callback when the animation finished.</param>
        /// <returns></returns>
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
}

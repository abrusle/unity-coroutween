using System;
using UnityEngine;

namespace Abrusle.CorouTween
{
    using static TweeningUtility;

    public class Tween
    {
        /// <summary>
        /// Event invoked when the animation finishes playing.
        /// </summary>
        public event Action AnimationComplete;

        /// <summary>
        /// True when the Tween is playing.
        /// </summary>
        public bool IsPlaying => _coroutine != null && _hostBehaviour != null;

        private Coroutine _coroutine;
        private Action _onComplete;

        private readonly UpdateAnimationDelegate _update;
        private readonly MonoBehaviour _hostBehaviour;
        private readonly float _duration;

        public Tween(MonoBehaviour hostBehaviour, UpdateAnimationDelegate update, float duration)
        {
            _hostBehaviour = hostBehaviour;
            _update = update;
            _duration = duration;
        }

        /// <summary>
        /// Plays an animation.
        /// </summary>
        /// <param name="durationOverride"></param>
        /// <param name="onComplete"></param>
        public void Play(float? durationOverride = null, Action onComplete = null)
        {
            KillTween();
            _onComplete = onComplete;
            _coroutine = _hostBehaviour.StartTween(durationOverride ?? _duration, _update, OnComplete);
        }

        /// <summary>
        /// Stops an animation
        /// </summary>
        public void Stop()
        {
            KillTween();
        }

        private void KillTween()
        {
            if (_coroutine != null)
            {
                _hostBehaviour.StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }

        private void OnComplete()
        {
            _coroutine = null;
            _onComplete?.Invoke();
            AnimationComplete?.Invoke();
        }
    }
}
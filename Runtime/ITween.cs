using System;

namespace Abrusle.CorouTween
{
    public interface ITween
    {
        /// <summary>
        /// Event invoked when the animation finishes playing.
        /// </summary>
        event Action AnimationComplete;

        /// <summary>
        /// Plays an animation.
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="update"></param>
        void Play(float duration, TweeningUtility.UpdateAnimationDelegate update = null);

        /// <summary>
        /// Stops an animation
        /// </summary>
        void Stop();
    }
}
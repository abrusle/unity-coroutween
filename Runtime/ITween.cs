using System;

public interface ITween
{
    event Action AnimationComplete;
    
    void Play(float duration, CorouTween.UpdateAnimationDelegate update = null);

    void Stop();
}
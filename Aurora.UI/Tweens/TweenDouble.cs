﻿namespace Aurora.UI.Tweens
{
    public sealed class TweenDouble : Tween<TweenDouble, double>
    {

        internal sealed override double Lerp(double from, double to, double time)
        {
            return from + (to - from) * time;
        }
    }
}

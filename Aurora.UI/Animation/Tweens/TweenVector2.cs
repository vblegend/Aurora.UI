﻿using Microsoft.Xna.Framework;
using Aurora.UI.Animation;


namespace Aurora.UI.Tweens.Tweens
{
    public sealed class TweenVector2 : Tween<TweenVector2, Vector2>
    {

        internal sealed override Vector2 Lerp(Vector2 from, Vector2 to, double time)
        {
            return Vector2.Lerp(from, to, (float)time);
        }

    }
}

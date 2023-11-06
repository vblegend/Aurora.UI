﻿using Microsoft.Xna.Framework;


namespace Aurora.Disktop.Tweens
{

    public interface ITweenUpdateable
    {
        bool Update(GameTime time);
    }



    public partial class Tween
    {
        public bool IsCompleted { get; protected set; }
        public TimeSpan Duration = new TimeSpan(0, 0, 1);
        public EasingFunction Easing = Tweens.Easing.Linear.None;
    }


    public abstract class Tween<DataType> : Tween, ITweenUpdateable
    {
        private DataType from;
        private DataType to;
        private DataType value;
        private TimeSpan? _startTime;

        /// <summary>
        /// 改变值
        /// </summary>
        /// <param name="to"></param>
        /// <param name="duration"></param>
        public void ChangeTo(DataType to, TimeSpan duration)
        {
            if (duration.Ticks == 0)
            {
                value = to;
            }
            from = value;
            this.to = to;
            Duration = duration;
            IsCompleted = duration.Ticks == 0;
            _startTime = null;
            return;
        }

        /// <summary>
        /// 改变当前值和目标值
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public Tween<DataType> ChangeTo(DataType from, DataType to, TimeSpan duration)
        {
            if (!_startTime.HasValue)
            {
                this.from = from;
                this.to = to;
                Duration = duration;
                IsCompleted = false;
            }
            return this;
        }

        bool ITweenUpdateable.Update(GameTime time)
        {
            if (IsCompleted) return false;
            if (Duration.Ticks == 0) return false;
            if (!_startTime.HasValue)
            {
                _startTime = time.TotalGameTime;
            }
            var elapsed = (time.TotalGameTime - _startTime.Value) / Duration;
            elapsed = elapsed > 1 ? 1 : elapsed;
            var value = Easing(elapsed);
            this.value = Lerp(from, to, value);

            if (elapsed == 1)
            {
                _startTime = null;
                IsCompleted = true;
                return false;
            }
            return true;
        }

        public DataType Value
        {
            get
            {
                return value;
            }
        }





        internal abstract DataType Lerp(DataType from, DataType to, double time);
    }







}

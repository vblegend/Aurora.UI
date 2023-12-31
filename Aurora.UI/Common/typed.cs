﻿

using Microsoft.Xna.Framework;


namespace Aurora.UI.Common
{
    public enum ButtonIndexs
    {
        /// <summary>
        /// 显示默认帧
        /// </summary>
        Default = 0,
        /// <summary>
        /// 显示鼠标悬浮帧
        /// </summary>
        Hover = 1,
        /// <summary>
        /// 显示鼠标按下帧
        /// </summary>
        Pressed = 2,
        /// <summary>
        /// 显示禁用帧
        /// </summary>
        Disabled = 0
    }

    public enum XamlDragDrop
    {
        /// <summary>
        /// 不允许拖出和放入
        /// </summary>
        None = 0,
        /// <summary>
        /// 只允许拖出
        /// </summary>
        OnlyDrag = 2,
        /// <summary>
        /// 只允许放下
        /// </summary>
        OnlyDrop = 4,
        /// <summary>
        /// 允许拖出和放入
        /// </summary>
        DragAndDrop = OnlyDrag | OnlyDrop,
    }

    public enum XamlHorizontalAlignment
    {
        Left = 0,
        Center = 1,
        Right = 2,
        Stretch = 3
    }

    public enum XamlVerticalAlignment
    {
        Top = 0,
        Center = 1,
        Bottom = 2,
        Stretch = 3
    }

    public struct Thickness
    {
        public Thickness(Int32 value)
        {
            this.Left = this.Top = this.Right = this.Bottom = value;
        }

        public Thickness(Int32 lr, Int32 tb)
        {
            this.Left = this.Right = lr;
            this.Top = this.Bottom = tb;
        }

        public Thickness(Int32 left, Int32 top, Int32 right, Int32 bottom)
        {
            this.Left = left;
            this.Right = right;
            this.Top = top;
            this.Bottom = bottom;
        }

        public override string ToString()
        {
            return $"Left:{Left}, Top:{Top}, Right:{Right}, Bottom:{Bottom}";
        }


        public static bool operator ==(Thickness a, Thickness b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Thickness a, Thickness b)
        {
            return !a.Equals(b);
        }

        public override bool Equals(object obj)
        {
            if (obj is Thickness)
            {
                return Equals((Thickness)obj);
            }

            return false;
        }

        public bool Equals(Thickness other)
        {
            if (this.Left == other.Left && this.Right == other.Right)
            {
                return this.Top == other.Top && this.Bottom == other.Bottom;
            }

            return false;
        }

        public Int32 Left;
        public Int32 Top;
        public Int32 Right;
        public Int32 Bottom;
    }


    public enum XamlDirection
    {
        /// <summary>
        /// 从左到右
        /// </summary>
        LeftToRight = 0,
        /// <summary>
        /// 从下到上
        /// </summary>
        BottomToTop = 1,
        /// <summary>
        /// 从右到左
        /// </summary>
        RightToLeft = 2,
        /// <summary>
        /// 从上到下
        /// </summary>
        TopToBottom = 3
    }


    public enum XamlOrientation
    {
        /// <summary>
        /// 横向的
        /// </summary>
        Horizontal,
        /// <summary>
        /// 纵向的
        /// </summary>
        Vertical,
    }


}

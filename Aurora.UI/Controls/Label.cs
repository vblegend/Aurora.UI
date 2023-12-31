﻿using Aurora.UI.Common;
using Microsoft.Xna.Framework;


namespace Aurora.UI.Controls
{
    public class Label : ContentControl
    {
        public Label()
        {
            // #d6c79c
            this.HorizontalContentAlignment = XamlHorizontalAlignment.Left;
            this.VerticalContentAlignment = XamlVerticalAlignment.Top;
        }

        /// <summary>
        /// 计算自动大小
        /// </summary>
        /// <returns></returns>
        protected override void CalcAutoSize()
        {
            if (this.NeedCalcAutoHeight)
            {
                this.globalBounds.Height = 20;
            }
            if (this.NeedCalcAutoWidth && this.Font != null)
            {
                var content = this.content.ToString();
                var fontSize = (this.Height - this.Padding.Top - this.Padding.Bottom) / this.FontSize;
                var size = this.Renderer.MeasureString(this.Font, this.FontSize, content) * fontSize;
                var px = size + new Vector2(this.Padding.Left + this.Padding.Right + this.Height, 0);
                this.globalBounds.Width = (Int32)px.X;
            }
        }



    }
}

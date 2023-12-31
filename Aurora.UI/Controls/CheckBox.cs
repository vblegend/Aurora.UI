﻿using Aurora.UI.Common;
using Aurora.UI.Graphics;
using Microsoft.Xna.Framework;


namespace Aurora.UI.Controls
{
    public class CheckBox : Button
    {
        public CheckBox()
        {
            this.Size = new Point(Int32.MinValue, 20);
            this.HorizontalContentAlignment = XamlHorizontalAlignment.Left;
            this.VerticalContentAlignment = XamlVerticalAlignment.Center;
        }

        protected override void OnRender(GameTime gameTime)
        {
            var dest = new Rectangle(this.GlobalBounds.Left + this.Padding.Left, this.GlobalBounds.Top + this.Padding.Top, this.GlobalBounds.Height - this.Padding.Bottom, this.GlobalBounds.Height - this.Padding.Bottom);
            this.RenderButton(dest);
            if (this.Value && this.Icon != null)
            {
                var iconDest = new Rectangle(this.GlobalBounds.Location, new Point(this.GlobalBounds.Height));
                if (this.Enabled && this.SpriteIndex == ButtonIndexs.Pressed)
                {
                    iconDest.Location += new Point(1, 1);
                }
                this.Renderer.Draw(this.Icon, iconDest, Color.White);
            }
            var offset = new Vector2((this.Enabled && this.SpriteIndex == ButtonIndexs.Pressed) ? 1 : 0);
            offset.X += this.Padding.Left + this.Height + (Int32)(this.FontSize * 0.2);
            this.OnDrawContent(gameTime, offset);
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
                var size = this.Renderer.MeasureString(this.Font, this.FontSize, content);
                var px = size + new Vector2(this.Padding.Left + this.Padding.Right + this.Height + (Int32)(this.FontSize * 0.2), 0);
                this.globalBounds.Width = (Int32)px.X;
            }
        }

        protected override void OnMouseUp(IMouseMessage args)
        {
            if (args.Button == MouseButtons.Left)
            {
                if (this is CheckBox && this.GlobalBounds.Contains(args.Location) && this.Enabled)
                {
                    this.Value = !this.Value;
                    this.Click?.Invoke(this);
                }
            }
            this.SpriteIndex = this.IsHover ? ButtonIndexs.Hover : ButtonIndexs.Default;
        }


        protected override void OnKeyDown(IKeyboardMessage args)
        {
            if (!this.Enabled) return;
            if (args.Key == Microsoft.Xna.Framework.Input.Keys.Space)
            {
                this.SpriteIndex = ButtonIndexs.Pressed;
            }
        }


        protected override void OnKeyUp(IKeyboardMessage args)
        {
            if (!this.Enabled) return;
            if (args.Key == Microsoft.Xna.Framework.Input.Keys.Space)
            {
                this.Value = !this.Value;
                this.Click?.Invoke(this);
                this.SpriteIndex = ButtonIndexs.Default;
            }
        }



        public new event XamlClickEventHandler<CheckBox> Click;

        public ITexture Icon;

        public Boolean Value;
    }
}

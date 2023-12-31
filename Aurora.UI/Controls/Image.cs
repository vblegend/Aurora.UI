﻿using Aurora.UI.Common;
using Aurora.UI.Graphics;
using Microsoft.Xna.Framework;


namespace Aurora.UI.Controls
{
    public class Image : Control
    {
        public Image()
        {
            this.FillMode = FillMode.None;
        }


        protected override void OnRender(GameTime gameTime)
        {
            base.OnRender(gameTime);

            if (this.texture != null)
            {
                if (this.FillMode == FillMode.None)
                {
                    this.Renderer.Draw(this.texture, this.GlobalBounds.Location.ToVector2(), Color.White);
                }
                else if (this.FillMode == FillMode.Stretch)
                {
                    this.Renderer.Draw(this.texture, this.GlobalBounds, Color.White);
                }
                else if (this.FillMode == FillMode.Center)
                {
                    var local = this.GlobalBounds.Location;
                    this.Renderer.Draw(this.texture, new Vector2(local.X + (this.Width - this.texture.Width) / 2, local.Y + (this.Height - this.texture.Height) / 2), Color.White);
                }
                else if (this.FillMode == FillMode.Tile)
                {
                    this.Renderer.DrawTitle(this.texture, this.GlobalBounds, Color.White);
                }
            }
        }


        public ITexture Texture
        {
            get
            {
                return this.texture;
            }
            set
            {
                this.texture = value;
                if (this.Size.Equals(Point.Zero) && this.texture != null)
                {
                    this.Size = new Point(this.texture.Width, this.texture.Height);
                }
            }

        }


        protected override void OnMouseUp(IMouseMessage args)
        {
            if (args.Button == MouseButtons.Left)
            {
                if (this.GlobalBounds.Contains(args.Location) && this.Enabled)
                {
                    this.Click?.Invoke(this);
                }

            }
        }


        protected override void CalcAutoSize()
        {
            if (this.NeedCalcAutoHeight && this.texture != null)
            {
                this.globalBounds.Height = texture.Height;
            }
            if (this.NeedCalcAutoWidth && this.texture != null)
            {
                this.globalBounds.Width = texture.Width;
            }
        }


        // Declare the event.
        public event XamlClickEventHandler<Image> Click;

        private ITexture texture;

        public FillMode FillMode { get; set; }
    }
}

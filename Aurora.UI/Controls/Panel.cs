﻿using Aurora.UI.Common;
using Aurora.UI.Graphics;
using Microsoft.Xna.Framework;

namespace Aurora.UI.Controls
{

    public interface IPanelControl
    {
        T Add<T>(T control) where T : Control;
        void Remove(Control control);
        Control this[Int32 index] { get; }
        Int32 Count { get; }
        Int32 IndexOf(Control control);
    }


    public interface IRadioActived
    {
        void RadioActived(Radio radio);
    }









    public class Panel : Control, IPanelControl, ILayoutUpdatable, IRenderable, IQuery, IRadioActived
    {
        public Panel()
        {
            this.Children = new List<Control>();
        }
        public List<Control> Children { get; protected set; }
        public Control this[int index] => this.Children[index];
        public int Count => this.Children.Count;
        public T Add<T>(T control) where T : Control
        {
            this.Children.Add(control);
            control.Parent = this;
            control.Root = this.Root;
            if (control is IAttachable attachable) attachable.OnAttached();
            if (this is ILayoutUpdatable updatable)
            {
                updatable.LayoutUpdate(true, true);
            }
            return control;
        }

        public void Clear()
        {
            this.Children.Clear();
        }



        public int IndexOf(Control control)
        {
            return this.Children.IndexOf(control);
        }

        public void Remove(Control control)
        {
            this.Children.Remove(control);
            control.Parent = null;
            if (this is ILayoutUpdatable updatable)
            {
                updatable.LayoutUpdate(true);
            }
        }

        void IRenderable.ProcessUpdate(GameTime gameTime)
        {
            this.OnUpdate(gameTime);
            for (int i = 0; i < this.Children.Count; i++)
            {
                var child = this.Children[i];
                if (child.Visible && child is IRenderable renderable)
                {
                    renderable.ProcessUpdate(gameTime);
                }
            }
        }
        /// <summary>
        /// 控件渲染处理
        /// </summary>
        /// <param name="gameTime"></param>
        void IRenderable.ProcessRender(GameTime gameTime)
        {
            var effect = !this.Enabled ? Effects.Disabled : null;
            GraphicContext.ContextState? state = this.Renderer.SetState(effect);
            this.OnRender(gameTime);
            if (state.HasValue) this.Renderer.RestoreState(state.Value);
 
            for (int i = 0; i < this.Children.Count; i++)
            {
                var child = this.Children[i];
                if (child.Visible && child is IRenderable renderable)
                {
                    renderable.ProcessRender(gameTime);
                }
            }
            this.DrawDebugBounds();
        }

        void ILayoutUpdatable.LayoutUpdate(Boolean updateChildren, Boolean force)
        {
            this.CalcAutoSize();
            if (this.CalcGlobalBounds() || force)
            {
                for (int i = 0; i < Children.Count; i++)
                {
                    if (Children[i] is ILayoutUpdatable updatable)
                    {
                        if (updateChildren) updatable.LayoutUpdate(true);
                        this.extendBounds = Rectangle.Union(this.extendBounds, Children[i].GlobalBounds);
                    }
                }
            }
            this.OnLayoutUpdate();
        }

        protected override void CalcAutoSize()
        {



        }

        public void RadioActived(Radio radio)
        {
            for (int i = 0; i < Children.Count; i++)
            {
                if (Children[i] is Radio radioControl && radioControl != radio && radioControl.GroupName == radio.GroupName)
                {
                    radioControl.Value = false;
                }
            }
        }

        #region IQuery
        public override Control this[string name]
        {
            get
            {
                for (int i = 0; i < Children.Count; i++)
                {
                    if (Children[i].Name == name) return Children[i];
                }
                return null;
            }
        }
        #endregion

    }
}

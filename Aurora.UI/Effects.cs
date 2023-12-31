﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.UI
{
    public static class Effects
    {
        private static Assembly CurrentAssembly;
        static Effects()
        {
            CurrentAssembly = typeof(Effects).Assembly;
        }



        public static Effect Disabled { get; internal set; }













        internal static Effect LoadEffectFromShaders(GraphicsDevice graphicsDevice,String filename)
        {
            var Content = AuroraState.Services.GetService<ContentManager>();


            //var ss = CurrentAssembly.GetManifestResourceNames();
            var streamSmall = CurrentAssembly.GetManifestResourceStream($"Aurora.UI.Shaders.{filename}_gl.mgfx");
            if (streamSmall == null) return null;
            int length = (int)streamSmall.Length;
            byte[] binary = new byte[length];
            streamSmall.Read(binary, 0, length);
            var effect = new Effect(graphicsDevice, binary);
            streamSmall.Close();
            return effect;
        }
    }

}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Content;

namespace SuperMario
{
    public static class TextureManager
    {
        public static Texture2D cloudTex;
        public static Texture2D landTex;

        public static SpriteFont spriteFont;

        public static void Load(ContentManager content)
        {
            //cloudTex = content.Load<Texture2D>(@"Clouds)");
            landTex = content.Load<Texture2D>(@"Ground");

            spriteFont = content.Load<SpriteFont>(@"Font");

        }
    }
}

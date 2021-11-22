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
        public static Texture2D landTex;
        public static Texture2D wallTex;
        public static Texture2D marioTex;
        public static SpriteFont spriteFont;

        public static void Load(ContentManager content)
        {
            wallTex = content.Load<Texture2D>(@"empty");
            landTex = content.Load<Texture2D>(@"Ground");
            marioTex = content.Load<Texture2D>(@"mario");

            spriteFont = content.Load<SpriteFont>(@"Font");

        }
    }
}

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
    class Background : GameObject
    {
        Texture2D texture;

        public Background(Vector2 pos, Texture2D texture) : base(pos, texture)
        {
            this.texture = texture;
        }
        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                pos.X += -8;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                pos.X += 8;
            }
            else
            {
                pos.X += 0;
            }
                pos.X += 0;
            if (pos.X <= -1200)
            {
                pos = new Vector2();
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, pos, Color.White);

        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.IO;

namespace SuperMario
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        Background background;
        static Tile[,] tileArray;
        List<string> strings;

        Mario mario;

        enum Gamestate
        {
            Start,
            Play,
            GameOver,
            Won,
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 800;
            graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            TextureManager.Load(Content);
            
            background = new Background(Vector2.Zero, TextureManager.landTex);
            ReadFromFile("mario.txt");
            StreamReader file = new StreamReader("mario.txt");
            strings = new List<string>();

            while (!file.EndOfStream)
            {
                strings.Add(file.ReadLine());
            }
            file.Close();

            tileArray = new Tile[strings[0].Length, strings.Count];
            for (int l = 0; l < tileArray.GetLength(0); l++)
            {
                for (int c = 0; c < tileArray.GetLength(1); c++)
                {
                    if (strings[c][l] == '-')
                    {
                        tileArray[l, c] = new Tile(new Vector2(TextureManager.wallTex.Width * l, TextureManager.wallTex.Height * c), TextureManager.wallTex, false);
                    }
                    if (strings[c][l] == 'M')
                    {
                        tileArray[l, c] = new Tile(new Vector2(TextureManager.wallTex.Width * l, TextureManager.wallTex.Height * c), TextureManager.wallTex, false);
                        mario = new Mario(new Vector2(TextureManager.wallTex.Width * l + 20, TextureManager.wallTex.Height * c + 20), TextureManager.marioTex);
                    }
                }
            }

        }
        public void ReadFromFile(string filename)
        {

        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            mario.Update(gameTime);
            background.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.MistyRose);
            spriteBatch.Begin();
            background.Draw(spriteBatch);
            foreach (Tile tile in tileArray)
            {
                tile.Draw(spriteBatch);
            }
            mario.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        public static bool GetTileAtPos(Vector2 tilePosition)
        {
            return tileArray[(int)tilePosition.X / TextureManager.wallTex.Width, (int)tilePosition.Y / TextureManager.wallTex.Height].wall;
        }
    }
}

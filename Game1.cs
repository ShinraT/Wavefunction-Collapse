using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;

namespace Wavefunction_Collapse
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private CollapseManager cP;
        private Cell cell;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1200;
            graphics.PreferredBackBufferHeight = 1000;
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            AssetManager.LoadTextures(Content, GraphicsDevice);
            WFCRuleSet.GP(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            cP = new CollapseManager(GraphicsDevice.Viewport);
            //cell = new Cell(new Rectangle(0, 0, 120, 120), 1337);
          
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyMouseReader.Update();
            cP.Update(gameTime);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(SpriteSortMode.Deferred,BlendState.AlphaBlend,SamplerState.PointClamp,DepthStencilState.None,RasterizerState.CullNone);
            cP.Draw(spriteBatch);
            //cell.Draw(spriteBatch);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}

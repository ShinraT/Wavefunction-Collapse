using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wavefunction_Collapse
{
    public class Cell
    {
        private Rectangle bounds;
        private Vector2 position;
        private Texture2D tex;
        int id;
        public Cell(Rectangle destRect, int id)
        {
            this.id = id;
            //tex = AssetManager.dungonMapTex;
            tex = AssetManager.testTex;
            tex = TileExtractor.ExtractOneTile(tex);
            this.bounds = destRect;
            this.position = new Vector2(this.bounds.X, this.bounds.Y);
        }

        private void DrawID(SpriteBatch sB)
        {
            sB.DrawString(AssetManager.spriteFont, $"{id}", new Vector2(bounds.Left +2,bounds.Center.Y), Color.Green);

        }

       


        public void Draw(SpriteBatch sB)
        {
            sB.Draw(tex, bounds, Color.White);
            DrawID(sB);
        }

    }
}

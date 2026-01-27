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

        private Texture2D tex;
        int id;
        public int ID => id;
        private bool collapsed;
        public Texture2D Tex(Texture2D texture) => tex = texture;
        public Cell(Rectangle destRect, int id, Texture2D tex)
        {
            this.id = id;
            this.tex = tex;
            this.bounds = destRect;
        }

        private void DrawID(SpriteBatch sB)
        {
            //sB.DrawString(AssetManager.spriteFont, $"{id}", new Vector2(bounds.Left +2,bounds.Center.Y), Color.Red);
            //sB.Draw(AssetManager.gridTex, bounds, Color.White);

        }

       


        public void Draw(SpriteBatch sB)
        {
            sB.Draw(tex, bounds, Color.White);
            DrawID(sB);
        }

    }
}

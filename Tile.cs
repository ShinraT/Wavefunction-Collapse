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
    public class Tile
    {
        private Texture2D tex;
        private int ID;
        private Rectangle drawingRec;
        


        public Tile(Texture2D tex, int ID)
        {
            this.tex = tex;
            this.ID = ID;

        }

        
        private void Draw(SpriteBatch sB)
        {
            sB.Draw(tex, drawingRec, Color.White);
        }
    }
}

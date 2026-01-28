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
        public Texture2D Tex => tex;
        private int id;
        public int ID => id;
        private Rectangle drawingRec;
        private enum Direction { NORTH = 0, EAST = 1, SOUTH = 2, WEST = 3 }
        private Tile[][][] tileOptions;
        private List<Tile> options;
        public List<Tile> Options => options;
        private int weight;
        public int Weight { get { return weight; } set { weight = value; } }

        public Tile(Texture2D tex, int ID, int weight)
        {
            this.tex = tex;
            this.id = ID;
            options = new List<Tile>();
        }

   
        private void Draw(SpriteBatch sB)
        {
            sB.Draw(tex, drawingRec, Color.White);
        }
    }
}

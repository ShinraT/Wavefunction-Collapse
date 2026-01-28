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
        private int ID;
        private Rectangle drawingRec;
        private enum Direction { NORTH = 0, EAST = 1, SOUTH = 2, WEST = 3 }
        private Tile[][][] tileOptions;
        private List<Tile> options;
        public List<Tile> Options => options;
        private int weight;
        public int Weight => weight;

        public Tile(Texture2D tex, int ID)
        {
            this.tex = tex;
            this.ID = ID;
            options = new List<Tile>();
        }

        public void AddOption(Tile tile)
        {
            options.Add(tile);
        }

        public List<Tile> ReturnAllNeighbors()
        {

            return options;
        }

        public void FindOption(Tile tile)
        {
            Color[] srcArray = new Color[tex.Width * tex.Height];
            Color[] compArray = new Color[tile.Tex.Width * tile.Tex.Height];
            for(int y  = 0; y < tex.Height; y++)
            {
                for(int x = 2; x< tex.Width; x++)
                {


                }
            }


        }

        
        private void Draw(SpriteBatch sB)
        {
            sB.Draw(tex, drawingRec, Color.White);
        }
    }
}

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.IsolatedStorage;
using System.Diagnostics;
using System.ComponentModel;
using System.Security.Policy;
using SharpDX.Direct3D9;

namespace Wavefunction_Collapse
{
    public static class WFCRuleSet
    {
        private static Texture2D texture = AssetManager.testTex;
        private static int nPixel = 4; // Pixel Height and Size in one tile.
        private static int tilePixelsAmounts = nPixel * nPixel;
        private static int tileNumber = 64;
        private static int tileGrid = 8;
        private static int defaultWeight = 1;
        private static GraphicsDevice graphicsDevice;
        public static Tile[][][] options;
        //public static 
        
        public  enum Direction { NORTH = 0, EAST = 1, SOUTH = 2, WEST = 3 }
        public static Direction direction = Direction.NORTH;
        public static GraphicsDevice GP(GraphicsDevice graphDevice) => graphicsDevice = graphDevice;
        public static List<Tile> ExtractIMGList() // Tar ut hela arrayen av tilse, men sen också var i Texturen "ExtractOneTile" ska kolla.
        {

            List<Tile> tiles = new List<Tile>();
            //Tile[] tileArray;
            Color[] sourcePixels = new Color[texture.Width * texture.Height];
            texture.GetData(sourcePixels);
            int index = 0;
            int xMulti = 0;
            int yMulti = 0;
            int stride = 2; // Overlap variabeln som används för att wrapa runt när man extraherar tiles, för fler alternative 
                            // Ju lägre värde, desto mer overlap; == Fler tiles, 
            for (int y = 0; y < texture.Height; y+=stride)
            {
                for (int x = 0; x < texture.Width; x+=stride)
                {
                    xMulti = x* nPixel;
                    yMulti = y* nPixel;
                    tiles.Add(ExtractOneTile(sourcePixels,xMulti, yMulti, index));
                    index++;
                }
            }
            Debug.WriteLine($"Original Tile Count{tiles.Count}");
            return DeDuplicateTiles(tiles);
        }

        public static Tile ExtractOneTile(Color[]sourcePixels ,int multiX, int multiY, int ID) // Tar ut en Tile som är nPixel * nPixel stor. 
        {
          
            Color[] tilePixels = new Color[tilePixelsAmounts];
          
            for(int y = 0; y<nPixel; y++)
            {
                for(int x = 0; x < nPixel; x++)
                {
                    int tileIndex = x + y * nPixel;
                    int sx =(multiX + x) % texture.Width;
                    int sy = (multiY + y) % texture.Height;
                    int sourceIndex = sx + sy * texture.Width;

                    tilePixels[tileIndex] = sourcePixels[sourceIndex];
                }
            }
            Texture2D tex = new Texture2D(graphicsDevice, nPixel, nPixel);
            tex.SetData(tilePixels);
            Tile tile = new Tile(tex, ID, defaultWeight);
            return tile;
        }

        private static List<Tile> DeDuplicateTiles(List<Tile> tiles )
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            List<Tile> unique = new List<Tile>();

            foreach (Tile t in tiles)
            {
                Color[] colors = new Color[nPixel * nPixel];
                t.Tex.GetData(colors);

                StringBuilder sb = new StringBuilder(colors.Length * 11);
                for (int i = 0; i < colors.Length; i++)
                    sb.Append(colors[i].PackedValue).Append(',');

                string key = sb.ToString();

                if (dict.TryGetValue(key, out int idx))
                {
                    unique[idx].Weight += 1;
                }
                else
                {
                    Tile newTile = new Tile(t.Tex, unique.Count, 1);
                    newTile.Weight = 1;
                    dict[key] = unique.Count;
                    unique.Add(newTile);
                }
            }
            return unique;
        }

        public static bool CheckIfTileIsOption(Tile sourceTile, Tile comparisonTile)
        {
            int depth = 2;
            Texture2D tex = sourceTile.Tex;
            Texture2D compTex = comparisonTile.Tex;
            Color[] sourceColors = new Color[tex.Width * tex.Height];
            Color[] compColors = new Color[comparisonTile.Tex.Width * comparisonTile.Tex.Height];
            tex.GetData(sourceColors);
            compTex.GetData(compColors);
            for(int y = 0; y < nPixel; y++)
            {
                for(int x = 0;x < depth; x++)
                {
                    int srcIndex = ((nPixel - depth) + x) + (y *nPixel); // 2, 3mm  
                    int compIndex = x + y * nPixel;  // 0, 1, 4, 5, 
                    if (sourceColors[srcIndex] != compColors[compIndex])
                        return false;
                }
            }
            return true;
        }
    }
}

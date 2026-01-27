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

namespace Wavefunction_Collapse
{
    public static class TileExtractor
    {
        private static int nPixel = 4; // Pixel Height and Size in one tile.
        private static int tilePixelsAmounts = nPixel * nPixel;
        private static int tileNumber = 64;
        private static int tileGrid = 8;
        private static GraphicsDevice graphicsDevice;
        public static GraphicsDevice GP(GraphicsDevice graphDevice) => graphicsDevice = graphDevice;
        public static Tile[] ExtractIMGArray(Texture2D Texture)
        {
            Texture2D tex = Texture;
            Tile[] tileArray = new Tile[tileNumber];
            int index = 0;
            int xMulti = 0;
            int yMulti = 0;
            for (int y = 0; y < tileGrid; y++)
            {
                for (int x = 0; x < tileGrid; x++)
                {
                    xMulti = x* nPixel;
                    yMulti = y* nPixel;
                    tileArray[index] = ExtractOneTile(tex, xMulti, yMulti, index);
                    index++;
                }

            }

            foreach(Tile tile in tileArray) // Add all right neighbor options for all tiles.
            {
                for(int x = 0;x < tileArray.Length; x++)
                {
                    if (FindRightNeigbor(tile, tileArray[x]))
                        tile.AddOption(tileArray[x]);
                }
            }
            return tileArray;
        }

        public static Tile ExtractOneTile(Texture2D Texture, int multiX, int multiY, int ID)
        {

            Color[] tilePixels = new Color[tilePixelsAmounts];
            Color[] sourcePixels = new Color[Texture.Width * Texture.Height];
           
            Texture.GetData(sourcePixels);
            for(int y = 0; y<nPixel; y++)
            {
                for(int x = 0; x < nPixel; x++)
                {
                    int tileIndex = x + y * nPixel;
                    int sourceIndex = (multiX + x) + (multiY + y) * Texture.Width;

                    tilePixels[tileIndex] = sourcePixels[sourceIndex];
                    Debug.WriteLine(sourceIndex);
                }
            }
            Texture2D tex = new Texture2D(graphicsDevice, nPixel, nPixel);
            tex.SetData(tilePixels);
            Tile tile = new Tile(tex, ID);
            return tile;
        }

        //public static Tile[] FindOptions()
        //{

        //}

        public static bool FindRightNeigbor(Tile sourceTile, Tile comparisonTile)
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

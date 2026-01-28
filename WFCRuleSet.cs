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
    public static class WFCRuleSet
    {
        private static int nPixel = 4; // Pixel Height and Size in one tile.
        private static int tilePixelsAmounts = nPixel * nPixel;
        private static int tileNumber = 64;
        private static int tileGrid = 8;
        private static GraphicsDevice graphicsDevice;
        public static Tile[][][] options;
        //public static 
        
        public  enum Direction { NORTH = 0, EAST = 1, SOUTH = 2, WEST = 3 }
        public static Direction direction = Direction.NORTH;
        public static GraphicsDevice GP(GraphicsDevice graphDevice) => graphicsDevice = graphDevice;
        public static Tile[] ExtractIMGArray(Texture2D Texture) // Tar ut hela arrayen av tilse, men sen också var i Texturen "ExtractOneTile" ska kolla.
        {
            Texture2D tex = Texture;
            List<Tile> tiles = new List<Tile>();
            Tile[] tileArray;
            Color[] sourcePixels = new Color[Texture.Width * Texture.Height];
            tex.GetData(sourcePixels);
            int index = 0;
            int xMulti = 0;
            int yMulti = 0;
            int stride = 2; // Overlap variabeln som används för att wrapa runt när man extraherar tiles, för fler alternative 
                            // Ju lägre värde, desto mer overlap; == Fler tiles, 
            for (int y = 0; y < tex.Height; y+=stride)
            {
                for (int x = 0; x < tex.Width; x+=stride)
                {
                    xMulti = x* nPixel;
                    yMulti = y* nPixel;
                    tiles.Add(ExtractOneTile(tex, sourcePixels,xMulti, yMulti, index));
                    index++;
                }
            }
            tileArray = new Tile[tiles.Count];
            for(int i = 0; i < tiles.Count; i++)
            {
                tileArray[i] = tiles[i];
            }
            Debug.WriteLine(tileArray.Length);
            return tileArray;
        }

        public static Tile ExtractOneTile(Texture2D Texture, Color[]sourcePixels ,int multiX, int multiY, int ID) // Tar ut en Tile som är nPixel * nPixel stor. 
        {
          
            Color[] tilePixels = new Color[tilePixelsAmounts];
          
            for(int y = 0; y<nPixel; y++)
            {
                for(int x = 0; x < nPixel; x++)
                {
                    int tileIndex = x + y * nPixel;
                    int sx =(multiX + x) % Texture.Width;
                    int sy = (multiY + y) % Texture.Height;
                    int sourceIndex = sx + sy * Texture.Width;

                    tilePixels[tileIndex] = sourcePixels[sourceIndex];
                }
            }
            Texture2D tex = new Texture2D(graphicsDevice, nPixel, nPixel);
            tex.SetData(tilePixels);
            Tile tile = new Tile(tex, ID);
            return tile;
        }

        private void RemoveDupesAndAddWeight()
        {




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

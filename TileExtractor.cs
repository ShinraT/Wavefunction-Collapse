using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.IsolatedStorage;

namespace Wavefunction_Collapse
{
    public static class TileExtractor
    {
        private static int nPixel = 4; // Pixel Height and Size in one tile.
        private static Texture2D[] texArray;
        private static GraphicsDevice graphicsDevice;
        public static GraphicsDevice GP(GraphicsDevice graphDevice) => graphicsDevice = graphDevice;
        //public static Texture2D ExtractIMGArray(Texture2D Texture)
        //{
        //    Texture2D tex = Texture;
        //    texArray = new Texture2D[nPixel * nPixel * nPixel];
        //    for(int y = 0; y <Texture.Height; y++)
        //    {
        //        for(int x = 0; x <Texture.Width; x++)
        //        {

        //        }

                        
        //    }
        //}

        public static Texture2D ExtractOneTile(Texture2D Texture)
        {

            Color[] tilePixels = new Color[nPixel * nPixel];
            Color[] sourcePixels = new Color[Texture.Width * Texture.Height];
           
            Texture.GetData(sourcePixels);
            for(int y = 0; y<nPixel; y++)
            {
                for(int x = 0; x < nPixel; x++)
                {
                    int tileIndex = x + y * nPixel;
                    int sourceIndex = x + y * Texture.Width;


                    tilePixels[tileIndex] = sourcePixels[sourceIndex];

                }
            }
            Texture2D tex = new Texture2D(graphicsDevice, nPixel, nPixel);
            tex.SetData(tilePixels);
            return tex;
        }






    }
}

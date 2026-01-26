using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;



namespace Wavefunction_Collapse
{
    public static class AssetManager
    {
        public static Texture2D redTex;
        public static Texture2D blueTex;
        public static Texture2D whiteTex;
        public static Texture2D yellowTex;
        public static Texture2D whiteBox;
        public static Texture2D cellTex;
        public static Texture2D gridTex;
        public static Texture2D dungonMapTex;
        public static SpriteFont spriteFont;
        public static Texture2D testTex;


        public static void LoadTextures(ContentManager content, GraphicsDevice graphicsDevice)
        {
            cellTex = content.Load<Texture2D>("Path_Spritesheet");
            gridTex = content.Load<Texture2D>("MapEditorTexPNG");
            dungonMapTex = content.Load<Texture2D>("DungonMap_WFC");
            spriteFont = content.Load<SpriteFont>("SpriteFont");
            testTex = content.Load<Texture2D>("DungonMap_WFC_Test");






            whiteBox = new Texture2D(graphicsDevice, 5, 5);
            redTex = new Texture2D(graphicsDevice, 1, 1, false, SurfaceFormat.Color);
            blueTex = new Texture2D(graphicsDevice, 1, 1, false, SurfaceFormat.Color);
            whiteTex = new Texture2D(graphicsDevice, 1, 1, false, SurfaceFormat.Color);
            //redTex.SetData<Microsoft.Xna.Framework.Color>(new Color[] {Color.Red});
            redTex.SetData(new Color[] { Color.Red });
            blueTex.SetData(new Color[] { Color.Blue });
            whiteTex.SetData(new Color[] { Color.White });
            Color[] data = new Color[5 * 5];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = Color.White;
            }
            whiteBox.SetData(data);

        }
    }
}
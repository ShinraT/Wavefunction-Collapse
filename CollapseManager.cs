using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Wavefunction_Collapse
{
    public class CollapseManager
    {
        private Cell[,] cells;
        private Viewport vP;
     
       
        private Random rnd = new Random();
        private int cellSize = 80;
        private int gridXOffset = 150;
        private int gridYOffset = 100;
        private int gridSize = 8;
        private int cellsPerRowColumn = 8;
        private Tile[] tileArray;
        private List<Cell> cellTestList = new List<Cell>();
        public CollapseManager(Viewport vP)
        {
            this.vP = vP;
            CalcCelllSizeAndGridSize();
            CreateCells();
            tileArray = WFCRuleSet.ExtractIMGArray(AssetManager.testTex);
            LoadCellTextures();
            PrintCellCount();
            //LoadAllNeighBors();
        }

        private void CalcCelllSizeAndGridSize()
        {
            //cellSize = vP.Width / cellsPerRowColumn;
            //gridSize = vP.Width / cellSize;
        }

       

        private void CheckIfMouseHoverCell() // Gets the Col And Row in the 2D Array, if the tuple returns (-1, -1) return.
        {
            int x, y;
            (x, y) = MouseHoverCell();
            if (x == -1 || y == -1)
                return;

        }


        private (int x, int y) MouseHoverCell() // Gets the Column and Row in the 2D Array of cells. Otherwise return (-1, -1)
        {

            int mouseX = (int)KeyMouseReader.mouseState.X;
            int mouseY = (int)KeyMouseReader.mouseState.Y;

            int col = mouseX / cellSize;
            int row = mouseY / cellSize;

            if (row >= 0 && col >= 0)
                return (col, row);
            else return (-1, -1);


        }

        public void LoadCellsTextures(/*SpriteBatch sB*/)
        {
            Random rnd = new Random();
            int optionsCount = tileArray[2].Options.Count;
            List<Tile> tiles = new List<Tile>();
            tiles = tileArray[2].ReturnAllNeighbors();
            List<Texture2D> textures = new List<Texture2D>();
            foreach(Tile t in tiles)
            {
                textures.Add(t.Tex);
            }
            
            foreach (Cell c in cells)
            {
                c.Tex(textures[rnd.Next(0, textures.Count )]);
            }
            Debug.WriteLine( $"Options Count = {optionsCount}");
            
           

        }

        private void PrintCellCount()
        {
            Debug.WriteLine(cells.Length);

        }


        public void Update(GameTime gT)
        {
            if(KeyMouseReader.KeyPressed(Keys.Space))
            LoadCellsTextures();
           
           
        }

        private void LoadCellTextures()
        {
            int index = 0;
            for(int y = 0; y < cells.GetLength(0); y++)
            {
                for(int  x = 0; x < cells.GetLength(1); x++)
                {
                    
                    cells[x, y].Tex(tileArray[index].Tex);
                    index++;
                }
            }
        } 


        


        public void Draw(SpriteBatch sB)
        {
            DrawCells(sB);
            if(cellTestList != null)
            {
                foreach (Cell cell in cellTestList) ;
            }
           
              
            
          
            //cells[4,4].Draw(sB);

        }

        private void DrawCells(SpriteBatch Sb) // Draws all the cells
        {
            if (cells != null)
            {
                foreach (Cell c in cells) c.Draw(Sb);
            }
            
        }
        private void CreateCells()
        {
            cells = new Cell[gridSize, gridSize];
            int ID = 0;
            for (int y = 0; y < cells.GetLength(0); y++)
            {
                for (int x = 0; x < cells.GetLength(1); x++)
                {
                    //Texture2D tex = TileExtractor.ExtractOneTile(AssetManager.testTex);
                    Cell c = new Cell(new Rectangle(x * cellSize + gridXOffset, y * cellSize + gridYOffset, cellSize, cellSize), ID, AssetManager.gridTex/*tex*/);
                    cells[x, y] = c;
                    ID++;
                }
            }
        }

    }
}

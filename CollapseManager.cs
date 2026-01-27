using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Collections.Generic;
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
        private int cellSize = 30;
        private int gridXOffset = 150;
        private int gridYOffset = 5;
        private int gridSize = 32;
        private int cellsPerRowColumn = 32;
        private Texture2D[] texArray;
        public CollapseManager(Viewport vP)
        {
            this.vP = vP;
            CalcCelllSizeAndGridSize();
            CreateCells();
            texArray = TileExtractor.ExtractIMGArray(AssetManager.testTex);
            LoadCellTextures();
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


        public void Update(GameTime gT)
        {

            if(KeyMouseReader.LeftClick())
            CheckIfMouseHoverCell();
        }

        private void LoadCellTextures()
        {
            for(int y = 0; y < cells.GetLength(0); y++)
            {
                for(int  x = 0; x < cells.GetLength(0); x++)
                {
                    cells[y, x].Tex(texArray[x]);
                }
            }
        } 


        


        public void Draw(SpriteBatch sB)
        {
            DrawCells(sB);



        }

        private void DrawCells(SpriteBatch Sb) // Draws all the cells
        {
            foreach(Cell c in cells)c.Draw(Sb);
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

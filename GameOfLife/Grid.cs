using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    /// <summary>
    /// Represents Grid class
    /// </summary>
    public class Grid
    {
        /// <summary>
        /// Gets or sets the cells.
        /// </summary>
        /// <value>
        /// The cells.
        /// </value>
        public Cell[,] Cells { get; set; }

        /// <summary>
        /// Gets or sets the size of the n.
        /// </summary>
        /// <value>
        /// The size of the n.
        /// </value>
        public int nSize { get; set; }

        /// <summary>
        /// Gets or sets the size of the m.
        /// </summary>
        /// <value>
        /// The size of the m.
        /// </value>
        public int mSize { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Grid"/> class.
        /// </summary>
        public Grid()
        {
            this.nSize = 9;
            this.mSize = 9;
            this.Cells = new Cell[nSize, mSize];
        }

        /// <summary>
        /// Displays the grid.
        /// </summary>
        /// <param name="cells">The cells.</param>
        public void DisplayGrid(Cell[,] cells)
        {
            for (int i = 0; i < nSize; i++)
            {
                for (int j = 0; j < mSize; j++)
                {
                    Console.Write(cells[i, j].Value + " ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Gets the random values cells.
        /// </summary>
        /// <returns>
        /// Cell array
        /// </returns>
        public Cell[,] GetRandomValuesCells()
        {
            int randomNumber = 0;
            Random rand = new Random();

            for (int i = 0; i < nSize; i++)
            {
                for (int j = 0; j < mSize; j++)
                {
                    randomNumber = rand.Next(0, 3);
                    this.Cells[i, j] = new Cell();
                    if (randomNumber == 1)
                    {
                        this.Cells[i, j].CellStatus = CellStatus.Live;
                        this.Cells[i, j].Value = 1;
                    }
                }
            }
            return this.Cells;
        }

        /// <summary>
        /// Sets the state of the grid next level.
        /// </summary>
        /// <param name="cells">The cells.</param>
        /// <returns>
        /// Cell array
        /// </returns>
        public Cell[,] SetGridNextLevelState(Cell[,] cells)
        {
            for (int i = 0; i < nSize; i++)
            {
                for (int j = 0; j < mSize; j++)
                {
                    this.Cells[i, j] = GetCellBasedOnRules(this.Cells, i, j);
                }
            }
            return this.Cells;
        }

        /// <summary>
        /// Gets the cell based on rules.
        /// </summary>
        /// <param name="cells">The cells.</param>
        /// <param name="xPosition">The x position.</param>
        /// <param name="yPosition">The y position.</param>
        /// <returns>
        /// A single cell
        /// </returns>
        private Cell GetCellBasedOnRules(Cell[,] cells, int xPosition, int yPosition)
        {
            if (cells[xPosition, yPosition].CellStatus == CellStatus.Live)
            {
                if (GetLiveCellNeighboursCount(cells, xPosition, yPosition) < 2 || GetLiveCellNeighboursCount(cells, xPosition, yPosition) > 3)
                {
                    cells[xPosition, yPosition].CellStatus = CellStatus.Dead;
                    cells[xPosition, yPosition].Value = 0;
                }
            }
            else if (cells[xPosition, yPosition].CellStatus == CellStatus.Dead)
            {
                if (GetLiveCellNeighboursCount(cells, xPosition, yPosition) == 3)
                {
                    cells[xPosition, yPosition].CellStatus = CellStatus.Live;
                    cells[xPosition, yPosition].Value = 1;
                }
            }
            return cells[xPosition, yPosition];
        }

        /// <summary>
        /// Gets the live cell neighbours count.
        /// </summary>
        /// <param name="cells">The cells.</param>
        /// <param name="xPosition">The x position.</param>
        /// <param name="yPosition">The y position.</param>
        /// <returns>
        /// The count of living neighbours
        /// </returns>
        private int GetLiveCellNeighboursCount(Cell[,] cells, int xPosition, int yPosition)
        {
            int count = 0, xBorderCount = 3, yBorderCount = 3;
            for (int i = xPosition - 1; xBorderCount > 0; i++)
            {
                for (int j = yBorderCount - 1; yBorderCount > 0; j++)
                {
                    if (i < 0)
                    {
                        i = nSize - 1;
                    }
                    else if (i > nSize - 1)
                    {
                        i = 0;
                    }

                    if (j < 0)
                    {
                        j = mSize - 1;
                    }
                    else if (i > mSize - 1)
                    {
                        j = 0;
                    }

                    if (cells[i, j].CellStatus == CellStatus.Live)
                    {
                        ++count;
                    }
                    --yBorderCount;
                }
                yBorderCount = 3;
                --xBorderCount;
            }
            return count;
        }
    }
}

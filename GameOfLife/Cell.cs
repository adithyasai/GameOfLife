using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    /// <summary>
    /// Represents cell class
    /// </summary>
    public class Cell
    {
        /// <summary>
        /// Gets or sets the cell status.
        /// </summary>
        /// <value>
        /// The cell status.
        /// </value>
        public CellStatus CellStatus { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public int Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class.
        /// </summary>
        public Cell()
        {
            this.CellStatus = CellStatus.Dead;
            this.Value = 0;
        }
    }
}

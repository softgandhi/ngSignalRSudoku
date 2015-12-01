using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngSignalRSudoku.Models
{
    [Serializable]
    public class Sudoku
    {
        public GridRow[] Grid { get; set; }
        public object GroupName { get; internal set; }
        public int Level { get; set; }
    }

    public class GridRow
    {
        public List<GridCell> Cells { get; set; }

        public GridRow(int rowIndex, params int[] cellsData)
        {
            Cells = new List<GridCell>();

            for (int colIndex = 0; colIndex < 9; colIndex++)
            {
                Cells.Add(new GridCell(cellsData[colIndex], rowIndex, colIndex));
            }
        }
    }

    public class GridCell
    {
        public Guid Id { get; set; }
        public int Data { get; set; }
        public bool IsCorrect { get; set; }
        public bool Freezed { get; set; }

        public int RowIndex { get; set; }
        public int ColIndex { get; set; }

        public GridCell(int data, int rowIndex, int colIndex)
        {
            Id = Guid.NewGuid();
            IsCorrect = data != 0;
            Freezed = data != 0;
            Data = data;
            RowIndex = rowIndex;
            ColIndex = colIndex;
        }
    }
}

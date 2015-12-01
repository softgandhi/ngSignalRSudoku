using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngSignalRSudoku.Models
{
    public class SudokuEngine
    {
        public static Sudoku CreateSudoku(string groupName)
        {
            var grid = new GridRow[] {
                new GridRow(0, 3,4,0,1,0,0,7,0,0 ),
                new GridRow(1, 0,0,8,0,0,0,3,0,0 ),
                new GridRow(2, 0,1,0,9,3,0,8,0,0 ),
                new GridRow(3, 0,0,1,0,0,5,2,7,0 ),
                new GridRow(4, 0,0,0,8,0,3,0,0,0 ),
                new GridRow(5, 0,5,9,6,0,0,4,0,0 ),
                new GridRow(6, 0,0,3,0,1,9,0,8,0 ),
                new GridRow(7, 0,0,4,0,0,0,1,0,0 ),
                new GridRow(8, 0,0,7,0,0,8,0,5,3 ),
            };

            var sudoku = new Sudoku
            {
                Grid = grid,
                Level = 3,
                GroupName = groupName
            };

            return sudoku;
        }
    }
}

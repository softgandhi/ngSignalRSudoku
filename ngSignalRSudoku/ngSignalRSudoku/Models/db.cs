using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngSignalRSudoku.Models
{
    // Important:: Coding conventions has not been followed here to keep things simple. 
    // Later, this class will be replaced by database repository or persistence cache.//
    public class db
    {
        private static Dictionary<string, Sudoku> Sudokus = new Dictionary<string, Sudoku>();

        public static Sudoku GetSudoku(string groupName)
        {
            if(!Sudokus.ContainsKey(groupName))
            {
                Sudokus[groupName] = SudokuEngine.CreateSudoku(groupName);
            }
            //var sudoku = Sudokus[groupName];
            //if(sudoku == null)
            //{
            //    sudoku = SudokuEngine.CreateSudoku(groupName);
            //    Sudokus[groupName] = sudoku;
            //}
            return Sudokus[groupName];
        }

        internal static void UpdateSudoku(string groupName, Sudoku sudoku)
        {
            throw new NotImplementedException();
        }

        internal static void UpdateSudoku(string groupName, GridCell cell)
        {
            //var sudoku = db.GetSudoku(groupName);
            //var existingCell = sudoku.Grid[cell.RowIndex].Cells[cell.ColIndex];
            //existingCell.Data = cell.Data;

            Sudokus[groupName].Grid[cell.RowIndex].Cells[cell.ColIndex].Data = cell.Data;
        }
    }
}

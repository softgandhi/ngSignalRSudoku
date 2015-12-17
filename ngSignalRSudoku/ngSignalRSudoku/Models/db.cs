using System.Collections.Generic;

namespace ngSignalRSudoku.Models
{
    // Important:: Coding conventions has not been followed here to keep things simple. 
    // Later, this class will be replaced by database repository or persistence cache.//
    public class db
    {
        public static List<Group> Gropus = new List<Group>();
        private static Dictionary<string, Sudoku> Sudokus = new Dictionary<string, Sudoku>();
        
        public static Sudoku GetSudoku(string groupName)
        {
            if(!Sudokus.ContainsKey(groupName))
            {
                Sudokus[groupName] = SudokuEngine.CreateSudoku(groupName);
            }
            return Sudokus[groupName];
        }

        internal static void UpdateSudoku(string groupName, GridCell cell)
        {
            Sudokus[groupName].Grid[cell.RowIndex].Cells[cell.ColIndex].Data = cell.Data;
        }
    }
}

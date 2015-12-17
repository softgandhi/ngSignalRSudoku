using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using ngSignalRSudoku.Models;

namespace ngSignalRSudoku
{
    [HubName("sudokuHub")]
    public class SudokuHub : Hub
    {
        //public static List<Group> _Gropus = new List<Group>();

        public SudokuHub()
        {
            if (!db.Gropus.Any(x => x.Name == "Global"))
                db.Gropus.Add(new Group("Global", "System"));
        }

        public void CreateGroup(string name, string userName)
        {
            if (!db.Gropus.Any(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase)))
                db.Gropus.Add(new Group(name, userName));

            Clients.All.groupCreated(db.Gropus);
        }
        public void GetGroups()
        {
            Clients.All.getGroups(db.Gropus);
        }

        public void GetSudoku(string groupName)
        {
            var group = db.Gropus.FirstOrDefault(x => x.Name.Equals(groupName, StringComparison.CurrentCultureIgnoreCase));
            Clients.Caller.getSudoku(db.GetSudoku(groupName));
        }

        public void UpdateCell(string groupName, GridCell cell)
        {
            db.UpdateSudoku(groupName, cell);
            var sudoku = db.GetSudoku(groupName);  // updated sudoku.//
            var updatedCell = sudoku.Grid[cell.RowIndex].Cells[cell.ColIndex];

            Clients.All.cellUpdated(updatedCell, sudoku);
        }
    }
}
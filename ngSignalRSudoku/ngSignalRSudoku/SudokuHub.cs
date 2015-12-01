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
        public static List<Group> _Gropus = new List<Group>();

        public SudokuHub()
        {
            if (!_Gropus.Any(x => x.Name == "Global"))
                _Gropus.Add(new Group("Global", "System"));
        }

        public void GetGroups()
        {
            Clients.All.getGroups(_Gropus);
        }

        public void GetSudoku(string groupName)
        {
            var group = _Gropus.FirstOrDefault(x => x.Name.Equals(groupName));
            Clients.All.getSudoku(db.GetSudoku(groupName));
        }
        public void UpdateCell(string groupName, GridCell cell)
        {
            db.UpdateSudoku(groupName, cell);
            var sudoku = db.GetSudoku(groupName);  // updated sudoku.//

            Clients.All.cellUpdated(cell, sudoku);
        }
    }
}
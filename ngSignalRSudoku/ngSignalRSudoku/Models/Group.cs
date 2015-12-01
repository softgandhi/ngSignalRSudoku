using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngSignalRSudoku.Models
{
    public class Group
    {
        public string Name { get; set; }
        public string CreatedBy { get; set; }

        public Group()
        {

        }

        public Group(string name, string createdBy)
        {
            Name = name;
            createdBy = CreatedBy;
        }
    }
}

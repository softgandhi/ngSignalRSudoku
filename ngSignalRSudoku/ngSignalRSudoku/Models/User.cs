using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngSignalRSudoku.Models
{
    public class User
    {
        public string ConnectionId { get; set; }
        public string Name { get; set; }

        public string GroupName { get; set; }
    }
}

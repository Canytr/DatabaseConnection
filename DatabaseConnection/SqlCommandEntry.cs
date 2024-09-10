using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection
{
    // A new class to hold SQL commands and titles
    public class SqlCommandEntry
    {
        public string Title { get; set; }
        public string Command { get; set; }

        public override string ToString()
        {
            return Title; // The title will be displayed in the ListBox
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection
{
    // SQL komutlarını ve başlıkları tutmak için yeni bir sınıf
    public class SqlCommandEntry
    {
        public string Title { get; set; }
        public string Command { get; set; }

        public override string ToString()
        {
            return Title; // ListBox'ta başlık gösterilecek
        }
    }
}

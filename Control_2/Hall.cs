using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_2
{
    internal class Hall
    {
        public int hKey { get; set; }
        public string hName { get; set; }
        public string hall { get; set; }
        public string spec { get; set; }
        public int seatsNum { get; set; }
        public List<Reader> readerList { get; set; }
        public List<Book> bookList { get; set; }



    }
}

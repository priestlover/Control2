using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_2
{
    internal class Hall
    {
        private static int idCounter = 0;
        public int hKey { get; set; }
        public string hName { get; set; }
        public string hall { get; set; }
        public string spec { get; set; }
        public int seatsNum { get; set; }
        public List<int> readerList { get; set; }
        public List<int> bookList { get; set; }

        public Hall(string hName, string hall, string spec, int seatsNum, string[] books, string[] readers)
        {
            this.hKey = idCounter++;
            this.hName = hName;
            this.hall = hall;
            this.spec = spec;
            this.seatsNum = seatsNum;
            readerList = new List<int>();
            bookList = new List<int>();

                foreach (string s in books)
                {
                    bookList.Add(int.Parse(s));
                }
           
                foreach (string s in readers)
                {
                    readerList.Add(int.Parse(s));
                }
        }

        public override string ToString()
        {
            string a = string.Join(",", bookList);
            string b = string.Join(",", readerList);
            StringBuilder sb = new StringBuilder();
            sb.Append($"{hKey};");
            sb.Append($"{hName};");
            sb.Append($"{hall};");
            sb.Append($"{spec};");
            sb.Append($"{seatsNum};");
            sb.Append($"{a};");
            sb.Append($"{b};");
            return sb.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Control_2
{
    internal class Reader
    {
        public static int rkeyCoynter = 200 ;
        public int rKey { get; set; }
        public string fullName { get; set; }
        public int ticketNumber { get; set; }
        public DateTime birthday { get; set; }
        public string phoneNumber { get; set; }
        public string education { get; set; }
        public string hall { get; set; }
        public List<int> booksList { get; set; }

        public Reader(string fn, int tick, DateTime bday, string phone, string educ, string hall)
        {
            this.rKey = Reader.rkeyCoynter++;
            this.fullName = fn;
            this.ticketNumber = tick;
            this.birthday = bday;
            this.phoneNumber = phone;
            this.education = educ;
            this.hall = hall;
            this.booksList = new List<int>();
        }

        public bool ContainsBook(IEnumerable<int> books)
        {
            foreach (int book in books)
            {
                if (booksList.Contains(book))
                {
                    return true;
                }
            }
            return false;
        }



        public override string ToString()
        {
            string a = string.Join(",", booksList);
            StringBuilder sb = new StringBuilder();
            sb.Append($"{rKey};");
            sb.Append($"{fullName};");
            sb.Append($"{ticketNumber};");
            sb.Append(birthday.ToShortDateString() + ";");
            sb.Append($"{phoneNumber};");
            sb.Append($"{education};");
            sb.Append($"{hall};");
            sb.Append($"{a};");
            return sb.ToString();
        }


    }
}

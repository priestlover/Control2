using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_2
{
    static class FileReader
    {
        public static void Read()
        {
            string[] paths = { "D:\\books.txt", "D:\\readers.txt", "D:\\halls.txt" };
            using(StreamReader sr = new StreamReader(paths[0]))
            {
                string str;
                while((str = sr.ReadLine()) != null)
                {
                    string[] rs = new string[8];
                    rs = str.Split(';');
                    Data.books.Add(new Book(rs[1], rs[2], int.Parse(rs[3]), int.Parse(rs[4]), DateTime.Parse(rs[5]), DateTime.Parse(rs[6]), int.Parse(rs[7])));
                }
            }
            using(StreamReader sr = new StreamReader(paths[1]))
            {
                string str;
                while ((str = sr.ReadLine()) != null)
                {
                    string[] rs = new string[7];
                    rs = str.Split(';');
                    string[] temp = rs[7].Split(',');

                    var reader = new Reader(rs[1], int.Parse(rs[2]), DateTime.Parse(rs[3]), rs[4], rs[5], rs[6]);

                    foreach(var tem in temp)
                    {
                        if (tem == "" || tem ==" ") break;
                        reader.booksList.Add(int.Parse(tem));
                    }
                    Data.readers.Add(reader);
                }
            }
            using (StreamReader sr = new StreamReader(paths[2]))
            {
                string str;
                while((str = sr.ReadLine()) != null)
                {
                    string[] rs = new string[6];
                    rs = str.Split(';');
                    string[] temp1 = rs[5].Split(',');
                    string[] temp2 = rs[6].Split(',');

                    var hall = new Hall(rs[1], rs[2], rs[3], int.Parse(rs[4]), temp1,temp2);
                    Data.halls.Add(hall);
                }
            }
        }
    }
}

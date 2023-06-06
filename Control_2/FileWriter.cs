using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_2
{
    static class FileWriter
    {
       public static void Write()
        {
            string[] paths = { "D:\\books.txt", "D:\\readers.txt", "D:\\halls.txt"};
            using (var w = new StreamWriter(paths[0], false))
            {
                foreach(var book in Data.books)
                {
                    w.WriteLine(book.ToString());
                }
            }
            using(var w =  new StreamWriter(paths[1], false))
            {
                foreach (var reader in Data.readers)
                {
                    w.WriteLine(reader.ToString());
                }
            }
            using(var w = new StreamWriter(paths[2], false))
            {
                foreach(var hall in Data.halls)
                {
                    w.WriteLine(hall.ToString());
                }
            }
        }   
    }
}

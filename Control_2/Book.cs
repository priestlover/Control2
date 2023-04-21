﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_2
{
    public class Book
    {
        private static int idCounter = 0;
        public int id { get;}    
        public string title { get; set; }
        public string author { get; set; }
        public int year { get; set; }
        public int cipher { get; set; }
        public DateTime issueTime { get; set; }
        public DateTime receivingDate { get; set; }
        public int count { get; set; }
        

        public Book(string title, string author, int year, int cipher, DateTime issueTime, DateTime receivingDate, int count)
        {
            this.id = idCounter++;
            this.title = title;
            this.author = author;
            this.year = year;
            this.cipher = cipher;
            this.issueTime = issueTime;
            this.receivingDate = receivingDate;
        }





    }
}

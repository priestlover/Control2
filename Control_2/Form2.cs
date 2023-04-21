using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            toGrid(Form1.books.ToArray());
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            int temp1 = int.Parse(textBox3.Text);
            int temp2 = int.Parse(textBox4.Text);
            int temp3 = int.Parse(textBox7.Text);

            Book book = new Book(textBox1.Text, textBox2.Text, temp1, temp2, dateTimePicker1.Value, dateTimePicker2.Value, temp3);
            toGrid(book);
            Form1.books.Add(book);
        }
    
        private void toGrid(params Book[] books)
        {
                foreach (var book in books)
                   dataGridView1.Rows.Add(book.id, book.title, book.author, book.year, book.cipher, book.issueTime.ToShortDateString(), book.receivingDate.ToShortDateString(), book.count);  
        }


    }
}
//private static int idCounter = 0;
//public int id { get; }
//public string title { get; set; }
//public string author { get; set; }
//public int year { get; set; }
//public int cipher { get; set; }
//public DateTime issueTime { get; set; }
//public DateTime receivingDate { get; set; }
//public int count { get; set; }d
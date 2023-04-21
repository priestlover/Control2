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
        BackgroundWorker worker = new BackgroundWorker();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        { 
            worker.DoWork += (obj, ea) => fillGrid();
            worker.RunWorkerAsync();
        }

        private async void fillGrid()
        {
            toGrid(Data.books.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int temp1 = int.Parse(textBox3.Text);
            int temp2 = int.Parse(textBox4.Text);
            int temp3 = int.Parse(textBox7.Text);

            Book book = new Book(textBox1.Text, textBox2.Text, temp1, temp2, dateTimePicker1.Value, dateTimePicker2.Value, temp3);
            toGrid(book);
            Data.books.Add(book);
        }
    
        private void toGrid(params Book[] books)
        {
                foreach (var book in books)
                   dataGridView1.Rows.Add(book.id, book.title, book.author, book.year, book.cipher, book.issueTime.ToShortDateString(), book.receivingDate.ToShortDateString(), book.count);  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var index = dataGridView1.SelectedRows;

            for (int i = 0; i < index.Count; i++)
            {
                int a = (int)index[i].Cells[0].Value;
                Data.books.RemoveAll(x => x.id == a);
                dataGridView1.Rows.Remove(index[i]);
            }

        }
    }
}
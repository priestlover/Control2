using System;
using System.CodeDom;
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
            FileReader.Read();
            toFirstGrid(Data.books.ToArray());
            toSecondGrid(Data.readers.ToArray());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int temp1 = int.Parse(textBox3.Text);
            int temp2 = int.Parse(textBox4.Text);
            int temp3 = int.Parse(textBox7.Text);

            Book book = new Book(textBox1.Text, textBox2.Text, temp1, temp2, dateTimePicker1.Value, dateTimePicker2.Value, temp3);
            toFirstGrid(book);
            Data.books.Add(book);
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

        private void button3_Click(object sender, EventArgs e)
        {
            int temp1 = int.Parse(textBox6.Text);
            Reader reader = new Reader(textBox5.Text, temp1, dateTimePicker3.Value, textBox8.Text, textBox9.Text, textBox10.Text);
            toSecondGrid(reader);
            Data.readers.Add(reader);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            var index = dataGridView2.SelectedRows;
            for (int  i = 0;  i < index.Count;  i++)
            {
                int a = (int)index[i].Cells[0].Value;
                Data.readers.RemoveAll(x => x.rKey == a);
                dataGridView2.Rows.Remove(index[i]);
            }
        }
    
        private void toFirstGrid(params Book[] books)
        { 
                foreach (var book in books)
                    dataGridView1.Rows.Add(book.id, book.title, book.author, book.year, book.cipher, book.issueTime.ToShortDateString(), book.receivingDate.ToShortDateString(), book.count);       
        }

        private void toSecondGrid(params Reader[] readers)
        {
            foreach(var reader in readers)
            {
                dataGridView2.Rows.Add(reader.rKey,reader.fullName,reader.ticketNumber,reader.birthday.ToShortDateString(),reader.phoneNumber,reader.education,reader.hall);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            writeFileAsync();
        }
        #region asyncMethods
        static async Task writeFileAsync()
        {
            await Task.Run(() => FileWriter.Write());
        }
        #endregion



        private void button6_Click(object sender, EventArgs e)
        {
            var readerId = int.Parse(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
            var bookId = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

            if (int.Parse(dataGridView1.SelectedRows[0].Cells[7].Value.ToString()) > 0)
            {
                dataGridView1.SelectedRows[0].Cells[7].Value = 0;
                foreach (var reader in Data.readers)
                {
                    if (reader.rKey == readerId)
                    {
                        reader.booksList.Add(bookId);
                    }
                }

                foreach (var book in Data.books)
                {
                    if (book.id == bookId)
                    {
                        dataGridView1.SelectedRows[0].Cells[7].Value = book.count - 1;
                        book.count -= 1;
                    }
                }
            }
            else
                MessageBox.Show(
                    "Экземпляров книги не осталось",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox11.Text = string.Empty;
            var readerId = int.Parse(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
            var books = Data.readers.Where(x => x.rKey == readerId).Select(x => x.booksList).ToList();
            var book = books[0];
            for(int i = 0; i < book.Count; i++)
            {
                textBox11.Text += book[i] + "; ";
            }


            int b = 1;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox11.Text = string.Empty;
            var result = Data.halls.Select(x => new { hs = x.seatsNum, hn = x.hName, hb = x.hall});

            foreach(var seat in result)
            {
                textBox11.Text += seat.hn + " " + seat.hb + " " + seat.hs + "; ";
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox11.Text = string.Empty;
            var result = Data.books.Select(x => x).OrderByDescending(x => x.rating).Take(3).ToList();
            foreach(var book in result)
            {
                textBox11.Text += book.title + " :" + book.rating + " ;"; 
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox11.Text = string.Empty;
            var result = Data.books.Where(x => x.count > 0).Select(x=>x.id);
            foreach(var book in result)
            {
                textBox11.Text += book + "; ";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox11.Text = "";
            var books = Data.books.Where(x => x.count == 1).Select(x => x.id);

            var result = Data.readers.Where(x => x.ContainsBook(books)).Select(x => x.rKey).ToList();

            foreach(var item in result)
            {
                textBox11.Text += item.ToString() + "; ";
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var temp = textBox11.Text;
            textBox11.Text = "";
            var hallBooks = Data.halls.Where(x => x.spec == temp).Select(x=>x.bookList).ToList();
            foreach(var item in hallBooks[0])
            {
                textBox11.Text+= item.ToString() + "; ";
            }  

        }
    }
}
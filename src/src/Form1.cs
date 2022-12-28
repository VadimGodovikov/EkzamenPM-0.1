using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace src
{
    public partial class Form1 : Form
    {
        bool otstup = false;
        bool variant;
        double x, y;
        public Form1()
        {
            InitializeComponent();
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.AllowWebBrowserDrop = false;
            openFileDialog1.Filter = "HTML File (.html)|*.html|AllFiles(*.*)|*.*";
            openFileDialog1.ShowDialog();
            if (!otstup)
            {
                this.Height += 100;
                otstup = true;
            }
            // Определяем название файла сплитуя по слешам
            string[] split = openFileDialog1.FileName.Split('\\');
            string file = split[split.Length - 1];
            if (file == "1.html")
            {
                webBrowser1.Navigate(openFileDialog1.FileName);
                variant = true;
            }
            else if (file == "2.html")
            {
                webBrowser1.Navigate(openFileDialog1.FileName);
                variant = false;
            }
            else
            {
                MessageBox.Show($"Для данного файла'{file}' не имеется решения. Попробуйте выбрать файлы 1.html или 2.html");
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программу разработал студент\nГруппы ПКспк-220:\nГодовиков Вадим Артёмович\nВариант - 6", "О программе");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (variant)
            {
                func1();
            }
            else
            {
                func2();
            }
        }

        void func1()
        {
            if(Double.TryParse(textBox1.Text, out x)&&Double.TryParse(textBox2.Text, out y))
            {
                if (y < 0 && (x*x-y*y<1) && y > -1 && x >-1 && x < 1)
                {
                    MessageBox.Show("Находится внутри функции");
                    toolStripStatusLabel1.Text = "Находится внутри функции";
                }
                else if(y == 4*x && y == x*x-5 && y == -4*x || (x == 0 && y == -1) || (x == 0 && y == 0))
                {
                    MessageBox.Show("Находится на функции");
                    toolStripStatusLabel1.Text = "Находится на функции";
                }
                else
                {
                    MessageBox.Show("Находится вне функции");
                    toolStripStatusLabel1.Text = "Находится вне функции";
                }
            }
            else
            {
                MessageBox.Show("Ожидается ввод корректных данных (вещественных чисел)", "Ошибка");
                return;
            }
        }

        void func2()
        {
            if (Double.TryParse(textBox1.Text, out x) && Double.TryParse(textBox2.Text, out y))
            {
                if (y > x && (y > 0 && y < 1))
                {
                    MessageBox.Show("Находится внутри функции");
                    toolStripStatusLabel1.Text = "Находится внутри функции";
                }
                else if (y < 0 || y > 1 || y < x)
                {
                    MessageBox.Show("Находится вне функции");
                    toolStripStatusLabel1.Text = "Находится вне функции";
                }
                else
                {
                    MessageBox.Show("Находится на функции");
                    toolStripStatusLabel1.Text = "Находится на функции";
                }
            }
            else
            {
                MessageBox.Show("Ожидается ввод корректных данных (вещественных чисел)", "Ошибка");
                return;
            }
        }

    }
}

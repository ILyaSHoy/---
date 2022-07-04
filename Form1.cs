using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Практика
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();   
        }      
        private void режимИгрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В игре есть 2 режима игры:\n\nС комрьютером, где противником является компьютер.\nИгра продолжается пока игрок не отгадает случайно сгенерированое компьютером число.\n\nС человеком, где играют два человека.\nИгра продолжается пока кто-то неодгадает число противника", "Режимы игры");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 F1 = new Form1();
            if (computer.Checked) // Игра с компьютером
            {                
                Form2 F2 = new Form2();
                F2.Show();
            }
            if(peopl.Checked)// Игра с человеком
            {
                Form3 F3 = new Form3();
                F3.Show();
            }
        }
    }
}
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent(); 
            NewGame();
        }
        private void правилаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Компьютер генерирует случайное четырехзначное число.\nНеобходимо разгадать число.\n\n«бык» — цифра есть в записи задуманногочисла и стоит в той же позиции, что и в задуманном числе;\n\n«корова» — цифра есть в записи задуманного числа, но не стоит в той же позиции, что и в задуманном числе).",
            "Правила игры");
        }
        private void сложностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В игре есть три основных уровня сложности:\n\nЛёгкий - 50 попыток\nСредний -25 попыток\nСложный - 10 попыток", "Уровни сложности");
        }
        private void label1_DoubleClick(object sender, EventArgs e)//Секретик
        {
            MessageBox.Show("Разблокирован очень сложный уровень сложности, при нём дано всего 5 попыток","Секрет");
            very_hard_level.Select();
            hard_level.Visible = false;
            very_hard_level.Visible = true;
            button1.Visible = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            very_hard_level.Visible = false;
            hard_level.Visible = true;
            hard_level.Select();
        }
        //Задание секретного числа
        private Random rand = new Random();
        private int[] x = new int[4];
        private string secret_num;
        
        //Счётчик быков и коров
        private int bull;
        private int cow;
        
        //Попытки
        int max_attemp;
        int attemp = 0;
        private void NewGame()
        {
            NovoeChislo();
            richTextBox1.Clear();
            textBox1.ReadOnly = false;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Для начала игры ведите предположительное число в поле", "Начало игры");
            lose_button.Visible = false;
            new_game_button.Visible = false;
            very_hard_level.Visible = false;
            label6.Visible = false;
            button1.Visible = false;
        }
        private void NovoeChislo()//Генерация случаного числа
        {
            bool contains;
            for (int i = 0; i < 4; i++)
            {
                do
                {
                    contains = false;
                    x[i] = rand.Next(10);
                    for (int k = 0; k < i; k++)
                        if (x[k] == x[i])
                            contains = true;
                } while (contains);
            }
            secret_num = x[0].ToString() + x[1] + x[2] + x[3];
        }
        private void next_button_Click(object sender, EventArgs e)
        {
            next_button.Text = "Далее";
            lose_button.Visible = true;
            new_game_button.Visible = true;

            //Установка уровней сложности
            if (easy_level.Checked)
                max_attemp = 50;
            if (medium_level.Checked)
                max_attemp = 25;
            if (hard_level.Checked)
                max_attemp = 10;
            if (very_hard_level.Checked)
                max_attemp = 5;
            if (textBox1.Text.Length != 4) //Проверка разрядности числа
            {
                MessageBox.Show("Введенное число должно быть четырехзначным");
            }
            else //Игра
            {
                attemp++;
                SravenieChisel();
                RezultShow();
                label6.Visible = true;
                label6.Text = "Попытка №" + attemp;//Счётчик попыток
                textBox1.Clear();
            }

            if(attemp >= max_attemp)//Поражение
            {
                MessageBox.Show("Секретное число " + secret_num, "Поражение");
                NewGame();
            }
        }
        private void RezultShow()
        {
            richTextBox1.Text += "Поытка №" + attemp + "\n" + textBox1.Text + " - " + bull + " быка " + cow + " коровы " + "\n\n";
        }
        private void SravenieChisel()//Определение быков и коров
        {
            bull = 0;
            cow = 0;
            char[] ch = textBox1.Text.ToCharArray();
            for (int i = 0; i < 4; i++)
            {
                if (secret_num.Contains(ch[i]))
                {
                    if (secret_num[i] == ch[i])
                        bull++;
                    else
                        cow++;
                }
            }
            if(bull==4)//Объявление о победе
            {
                MessageBox.Show("Вы выиграли", "Победа");
                richTextBox1.Text = "Вы выиграли!!!";
            }
        }
        private void lose_button_Click(object sender, EventArgs e)
        {
            next_button.Text = "Начать";
            lose_button.Visible = false;
            new_game_button.Visible = false;
            MessageBox.Show(secret_num, "Секретное число:");
            next_button.Text = "Начать";
            textBox1.ReadOnly = true;
            attemp = 0;
            NewGame();
        }
        private void new_game_button_Click(object sender, EventArgs e)
        {
            lose_button.Visible = false;
            new_game_button.Visible = false;
            next_button.Text = "Начать";
            attemp = 0;
            NewGame();
        }
        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
    }
}
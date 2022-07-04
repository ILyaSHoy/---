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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        //Загадываемые числа
        private string secret_num1;
        private string secret_num2;
        private int[] x = new int[4];
        private int[] y = new int[4];
        private int a;
        private int b;

        //Счётчик быков и коров
        private int bull;
        private int cow;
        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Загадайте число";
            textBox2.Text = "Загадайте число";
            secret_num2_Button.Visible = false;
            textBox2.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            Plaer2_label.Visible = false;
        }

        private void secret_num1_Button_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 4) //Проверка разрядности числа
            {
                MessageBox.Show("Введенное число должно быть четырехзначным");
            }
            else
            {
                textBox2.Visible = true;
                secret_num1_Button.Visible = false;
                secret_num2_Button.Visible = true;

                a = int.Parse(textBox1.Text);

                //Разбиение числа на цифры
                x[0] = a / 1000;
                x[1] = a / 100 % 10;
                x[2] = a / 10 % 10;
                x[3] = a % 10;

                secret_num1 = x[0].ToString() + x[1] + x[2] + x[3];

                Plaer1_label.Visible = false;
                Plaer2_label.Visible = true;
            }
            textBox1.Visible = false;
            textBox1.Clear();
        }
        private void secret_num2_Button_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length != 4) //Проверка разрядности числа
            {
                MessageBox.Show("Введенное число должно быть четырехзначным");
            }
            else
            {
                secret_num2_Button.Visible = false;
                button1.Visible = true;

                b = int.Parse(textBox2.Text);

                //Разбиение числа на цифры
                y[0] = b / 1000;
                y[1] = b / 100 % 10;
                y[2] = b / 10 % 10;
                y[3] = b % 10;

                secret_num2 = y[0].ToString() + y[1] + y[2] + y[3];

                Plaer2_label.Visible = false;
                Plaer1_label.Visible = true;
            }
            textBox1.Visible = true;
            textBox2.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 4) //Проверка разрядности числа
            {
                MessageBox.Show("Введенное число должно быть четырехзначным");
            }
            else
            {
                //Сравнение чисел
                button1.Visible = false;
                button2.Visible = true;

                bull = 0;
                cow = 0;
                char[] ch1 = textBox1.Text.ToCharArray();

                for (int i = 0; i < 4; i++)
                {
                    if (secret_num2.Contains(ch1[i]))
                    {
                        if (secret_num2[i] == ch1[i])
                            bull++;
                        else
                            cow++;
                    }
                }
                Plaer1_label.Visible = false;
                Plaer2_label.Visible = true;

                richTextBox1.Text += textBox1.Text + " - " + bull + " быка " + cow + " коровы " + "\n";

                if (bull == 4)//Объявление о победе
                {
                    MessageBox.Show("Вы выиграли", "Победа");
                    richTextBox1.Text += "Вы выиграли!!!";

                    button1.Visible = false;
                    button2.Visible = false;
                    button3.Visible = true;
                    textBox2.Visible = false;
                }
            }   
            textBox1.Clear();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length != 4) //Проверка разрядности числа
            {
                MessageBox.Show("Введенное число должно быть четырехзначным");
            }
            else
            {
                //Сравнение чисел
                button1.Visible = true;
                button2.Visible = false;

                bull = 0;
                cow = 0;
                char[] ch2 = textBox2.Text.ToCharArray();
                for (int i = 0; i < 4; i++)
                {
                    if (secret_num1.Contains(ch2[i]))
                    {
                        if (secret_num1[i] == ch2[i])
                            bull++;
                        else
                            cow++;
                    }
                }
                richTextBox2.Text += textBox2.Text + " - " + bull + " быка " + cow + " коровы " + "\n";

                if (bull == 4)//Объявление о победе
                {
                    MessageBox.Show("Вы выиграли", "Победа");
                    richTextBox2.Text += "Вы выиграли!!!";

                    button1.Visible = false;
                    button2.Visible = false;
                    button4.Visible = true;
                    textBox1.Visible = false;
                    
                    Plaer2_label.Visible = false;
                    Plaer1_label.Visible = true;
                }
            }
            textBox2.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            secret_num1_Button.Visible = true;
            button3.Visible = false;
            richTextBox1.Clear();
            richTextBox2.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            secret_num1_Button.Visible = true;
            button4.Visible = false;
            richTextBox1.Clear();
            richTextBox2.Clear();
        }

        private void правилаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Каждый из противников задумывает четырехзначное число, все цифры которого различны.\n\nНеобходимо разгадать задуманное число.\nВыигрывает тот, кто отгадает первый.\n\nПротивники по очереди называют друг другу числа и сообщают о количестве «быков» и «коров» в названном числе\n\n«бык» — цифра есть в записи задуманногочисла и стоит в той же позиции, что и в задуманном числе;\n\n«корова» — цифра есть в записи задуманного числа, но не стоит в той же позиции, что и в задуманном числе).",
            "Правила игры");
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }
    }
}
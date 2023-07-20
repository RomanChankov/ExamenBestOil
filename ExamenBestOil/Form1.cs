using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenBestOil
{
    public partial class Form1 : Form
    {
        Work petrol;
        Work[] meal = new Work[]
        {
            new Work{ Name ="Чай",Price=70},
            new Work{ Name ="Кофе",Price=90},
            new Work{ Name ="Лимонад",Price=100},
            new Work{ Name ="Булочка",Price=60},
            new Work{ Name ="Бургер",Price=150},
        };
        double meal_sum = 0;
        double revenue ;
        string daily_revenue;
        int[] y = { 0, 0, 0, 0, 0 };


        public Form1()
        {
            InitializeComponent();

            List<Work> works = new List<Work>
            {
                new Work { Name="Бензин АИ-80", Price = 50.00},
                new Work { Name="Бензин АИ-92", Price = 53.50},
                new Work { Name="Бензин АИ-95", Price = 56.00},
                new Work { Name="Бензин АИ-98", Price = 60.00},
                new Work { Name="ДТ", Price = 54.00},

            };
            //comboBox1.DisplayMember = "Name";
            //Так выбираем вид топлива для отображения по умолчанию в comboboxe
            comboBox1.DataSource = works;
            comboBox1.DisplayMember = "Name";
            comboBox1.SelectedIndex = 0;

            checkBox1.Text = meal[0].Name;
            checkBox2.Text = meal[1].Name;
            checkBox3.Text = meal[2].Name;
            checkBox4.Text = meal[3].Name;
            checkBox5.Text = meal[4].Name;

        }

        //Метод позволяющий вводить только цифры.
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            e.Handled = !Char.IsDigit(c) && !Char.IsControl(c);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                petrol = (Work)comboBox1.SelectedItem;
                textBox1.Text = petrol.Price.ToString();
                if (radioButton1.Checked == true)
                {
                    textBox2_TextChanged(this, e);
                }
                else
                {
                    textBox3_TextChanged(this, e);
                }
                return;
            }
            else
            {
                textBox1.Text = "0";
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                label7.Text = (Convert.ToDouble(textBox1.Text) * Convert.ToDouble(textBox2.Text)).ToString();
            }
            else
            {
                label7.Text = "0,00";
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && Convert.ToDouble(textBox1.Text) != 0)
            {
                label7.Text = Math.Round((decimal)(Convert.ToDouble(textBox3.Text) / Convert.ToDouble(textBox1.Text)), 3).ToString();
            }
            else { label7.Text = "0,00"; }
        }



        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = true;
            textBox3.Text = "";
            groupBox5.Text = "К оплате: ";
            label7.Text = "0,00";
            label6.Text = "руб.";
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true;
            textBox2.Text = "";
            textBox3.ReadOnly = false;
            groupBox5.Text = "К выдаче: ";
            label7.Text = "0";
            label6.Text = "л.";
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox5.ReadOnly = false;
                textBox5.Text = "1";
                textBox5.Focus();
            }
            else
            {
                textBox5.ReadOnly = true;
                textBox5.Text = "";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                textBox7.ReadOnly = false;
                textBox7.Text = "1";
                // textBox7.Focus();
            }
            else
            {
                textBox7.ReadOnly = true;
                textBox7.Text = "";
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                textBox9.ReadOnly = false;
                textBox9.Text = "1";
                // textBox9.Focus();
            }
            else
            {
                textBox9.ReadOnly = true;
                textBox9.Text = "";
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                textBox11.ReadOnly = false;
                textBox11.Text = "1";
                // textBox11.Focus();
            }
            else
            {
                textBox11.ReadOnly = true;
                textBox11.Text = "";
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                textBox13.ReadOnly = false;
                textBox13.Text = "1";
                // textBox11.Focus();
            }
            else
            {
                textBox13.ReadOnly = true;
                textBox13.Text = "";
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            y[0] = Convert.ToInt32(textBox5.Text != "" ? textBox5.Text : "0");
            y[1] = Convert.ToInt32(textBox7.Text != "" ? textBox7.Text : "0");
            y[2] = Convert.ToInt32(textBox9.Text != "" ? textBox9.Text : "0");
            y[3] = Convert.ToInt32(textBox11.Text != "" ? textBox11.Text : "0");
            y[4] = Convert.ToInt32(textBox13.Text != "" ? textBox13.Text : "0");
            meal_sum = 0;
            for (int i = 0; i < 5; i++)
            {
                meal_sum += y[i] * meal[i].Price;
            }
            label10.Text = meal_sum.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double sum_petrol_meal;
            if (radioButton1.Checked == true)
            {
                sum_petrol_meal = Convert.ToDouble(label7.Text) + Convert.ToDouble(label10.Text);
            }
            else
            {
                sum_petrol_meal = Convert.ToDouble(textBox3.Text) + Convert.ToDouble(label10.Text);
            }
            label13.Text = sum_petrol_meal.ToString();

            revenue += sum_petrol_meal;
            daily_revenue = string.Format(" Дневная выручка {0:f} ", revenue) + " руб.";
           if(timer1.Enabled==false)
            {
                timer1.Start();
            }
            else
            {
                timer1.Stop();
            }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(daily_revenue, "Завершение работы", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            timer1.Stop();
            DialogResult result = MessageBox.Show($"Сумма к оплате: {label13.Text}. \nЗакрыть форму?", "Ожидание следующего покупателя", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                timer1.Start();
            }
        }
    }
}

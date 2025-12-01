using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class Ort
        {
            public int yazili1, yazili2;
            public int hesapla(int y1, int y2)
            {
                int son = (y1 + y2) / 2;
                return son;

            }
            public int not1, not2;
            public void hesap(int n1, int n2)
            {
                int sonuc = (n1 + n2) / 2;
                if (sonuc < 39)
                {
                    MessageBox.Show("zayıf");
                }
                else if (sonuc >= 40 && sonuc < 50)
                {
                    MessageBox.Show("orta");
                }
                else if (sonuc >= 50 && sonuc < 60)
                {
                    MessageBox.Show("iyi");
                }
                else if (sonuc >= 60 && sonuc < 75)
                {
                    MessageBox.Show("çok iyi");
                }
                else
                {
                    MessageBox.Show("mükemmel");
                }
            }
        }
        Ort o = new Ort();
        private void button1_Click(object sender, EventArgs e)
        {
         

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           o.yazili1 = Convert.ToInt32(textBox1.Text);
            o.yazili2 = Convert.ToInt32(textBox2.Text);
           int son= o.hesapla(o.yazili1, o.yazili2);
            if (son < 39)
            {
                listBox1.Items.Add("zayıf" + son);
            }
            else if (son >= 40 && son < 50)
            {
                listBox1.Items.Add("orta" + son);
            }
            else if (son >= 50 && son < 60)
            {
                listBox1.Items.Add("iyi" + son);
            }
            else if (son >= 60 && son < 75)
            {
                listBox1.Items.Add("çok iyi" + son);
            }
            else
            {
                listBox1.Items.Add("mükemmel" + son);
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            o.not1 = Convert.ToInt32(textBox1.Text);
            o.not2 = Convert.ToInt32(textBox2.Text);
            o.hesap(o.not1, o.not2);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            kullanıcı_giriş k = new kullanıcı_giriş();
            k.Show();
            this.Hide();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}


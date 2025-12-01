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
    public partial class kullanıcı_giriş : Form
    {
        public kullanıcı_giriş()
        {
            InitializeComponent();
        }
        class Hesap
        {
            public string Isim { get; set; }
            public string Sifre { get; set; }
            public string Tel { get; set; }

            public Hesap(string isim, string sifre, string tel)
            {
                Isim = isim;
                Sifre = sifre;
                Tel = tel;
            }

            public bool SifreKontrol(string sifre)
            {
                return Sifre == sifre;
            }
        }

        List<Hesap> hesaplar = new List<Hesap>();
        Hesap aktifHesap = null;

        private void kullanıcı_giriş_Load(object sender, EventArgs e)
        {
            // Kayıt ekranı gibi başlasın
            label3.Visible = false;
            label4.Visible = false;
            label6.Visible = false;

            label7.Visible = true;    
            textBox4.Visible = true;   

            button2.Visible = false;   // Giriş butonu gizli başlasın
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string isim = textBox1.Text.Trim();
            string sifre = textBox2.Text.Trim();
            string tel = textBox4.Text.Trim();

            if (isim == "" || sifre == "" || tel == "")
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            if (sifre.Length < 6)
            {
                MessageBox.Show("Şifreniz en az 6 karakter olmalıdır!", "Uyarı");
                return;
            }

            aktifHesap = new Hesap(isim, sifre, tel);
            hesaplar.Add(aktifHesap);

            MessageBox.Show("Şifreniz başarıyla oluşturuldu!", "Bilgi");

            label4.Text = aktifHesap.Isim;
            label3.Text = "******";
            label6.Text = aktifHesap.Tel;

            label4.Visible = true;
            label3.Visible = true;
            label6.Visible = true;

            TemizleGirisEkrani();
            button1.Visible = false;
            button2.Visible = true;

            textBox4.Visible = false;
            label7.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string isim = textBox1.Text.Trim();
            string sifre = textBox2.Text.Trim();

            foreach (var hesap in hesaplar)
            {
                if (hesap.Isim == isim && hesap.SifreKontrol(sifre))
                {
                    MessageBox.Show("Giriş başarılı!", "Bilgi");
                    Form1 fr1 = new Form1();
                    fr1.Show();
                    this.Hide();
                    return;
                }
            }

            MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Şifremi Unuttum")
            {
                // Giriş alanlarını gizle
                textBox1.Visible = false;
                textBox2.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                button2.Visible = false;

                // Tel alanını aç
                label7.Visible = true;
                textBox4.Visible = true;
                button4.Text = "Yenile";
            }
            else
            {
                string girilenTel = textBox4.Text.Trim();
                foreach (var hesap in hesaplar)
                {
                    if (hesap.Tel == girilenTel)
                    {
                        aktifHesap = hesap;
                        MessageBox.Show("Şifrenizi yeniden oluşturabilirsiniz.");

                        // Yeniden kayıt ekranı aç
                        textBox1.Visible = true;
                        textBox2.Visible = true;
                        label1.Visible = true;
                        label2.Visible = true;
                        button1.Visible = true;

                        button4.Visible = false; // Artık yeniden kayıt yapabilir
                        return;
                    }
                }

                MessageBox.Show("Telefon numarası eşleşmedi.", "Hata");
            }
        }

        private void TemizleGirisEkrani()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
        }
    }
   
    }




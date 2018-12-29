using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace resimBoyutlandir
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBox1.Items.Add("36");
            listBox1.Items.Add("48");
            listBox1.Items.Add("72");
            listBox1.Items.Add("96");
            listBox1.Items.Add("144");
            listBox1.Items.Add("196");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Tümü|*.*";
            if (file.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = file.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
                boyutlandir(pictureBox2, textBox1.Text, textBox2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Tümü|*.*";
            if (file.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image.Save(file.FileName + ".png");
                MessageBox.Show("Kayıt İşlemi tamam");
            }
        }
        PictureBox[] pic;
        private void button4_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pic = new PictureBox[listBox1.Items.Count];
                int top = 55;
                int left = 525;
                for (int i = 0; i < listBox1.Items.Count; i++)
                {//524     55
                    pic[i] = new PictureBox();
                    pic[i].Width = 50;
                    pic[i].Height = 50;

                    pic[i].SizeMode = PictureBoxSizeMode.StretchImage;

                    pic[i].Top = top;
                    pic[i].Left = left;
                    left += 55;
                    if ((i + 1) % 5 == 0)
                    {
                        top += 55;
                        left = 525;
                    }
                    string ad = listBox1.Items[i].ToString();
                    boyutlandir(pic[i], ad, ad);
                    this.Controls.Add(pic[i]);
                }
                MessageBox.Show("Boyutlandırma tamalandı..");
            }
            else
            {
                MessageBox.Show("Resim Eklediniz Mi ?");
            }
        }


        private void boyutlandir(PictureBox pic, string en, string boy)
        {
            int genislik = int.Parse(en);
            int yukseklık = int.Parse(boy);
            Bitmap resim = new Bitmap(pictureBox1.Image);
            resim = new Bitmap(pictureBox1.Image, new Size(genislik, yukseklık));
            pic.Image = resim;

        }

        private void kaydet(PictureBox pic, string konum, string en, string boy)
        {
            pic.Image.Save(konum + en + "x" + boy + ".png");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Tümü|*.*";
            if (file.ShowDialog() == DialogResult.OK && listBox1.Items.Count >= 1)
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    string ad = listBox1.Items[i].ToString();
                    kaydet(pic[i], file.FileName, ad, ad);
                }
                MessageBox.Show("Kaydetme işlemi başarılı galiba");
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    pic[i].Dispose();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
                listBox1.Items.Add(textBox3.Text);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            for (int i = 0; i < textBox3.Text.Length; i++)
            {
                int kontrol = 0;
                for (int j = 0; j <= 9; j++)
                {
                    if (textBox3.Text.Substring(i, 1) == j.ToString())
                    {
                        kontrol = 0;
                        j = 10;
                    }
                    else
                        kontrol = 1;
                }
                if (kontrol == 1)
                {
                    i = textBox3.Text.Length;
                    textBox3.Text = "";
                }
            }
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            for (int i = 0; i < textBox3.Text.Length; i++)
            {
                int kontrol = 0;
                for (int j = 0; j <= 9; j++)
                {
                    if (textBox3.Text.Substring(i, 1) == j.ToString())
                    {
                        kontrol = 0;
                        j = 10;
                    }
                    else
                        kontrol = 1;
                }
                if (kontrol == 1)
                {
                    i = textBox3.Text.Length;
                    textBox3.Text = "";
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }
    }
}

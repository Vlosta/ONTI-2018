using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ONTI2018
{
    public partial class Form2 : Form
    {
        int ctVect = 0;
        Form2 frm2;
        public static int logat = 0;
        int[] areOameni;
        int[] vectImagini= new int[10];
        Bitmap[] img = new Bitmap[10];
        int ctApas = 0;
        int gresit = 0;
        public Form2()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm2 = this;
            frm2.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            areOameni =new int[] { 0, 1, 0, 0, 0, 1, 1, 0, 1, 1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 1, 1 };
            label5.Text = "";
            textBox3.Hide();
            textBox4.Hide();
            label3.Hide();
            label4.Hide();
            button4.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select IdUtilizator from Utilizatori where Email=@p1 and Parola=@p2", Form1.con);
            cmd.Parameters.Add("@p1", textBox1.Text);
            cmd.Parameters.Add("@p2", textBox2.Text);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                Form1.logat = 1;
                MessageBox.Show("Logat cu succes!");
                Form1.button3.Show();

            }
            else
            {
                MessageBox.Show("Eroare de autentificare!");
            }
            rdr.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select IdUtilizator from Utilizatori where Email=@p1", Form1.con);
            cmd.Parameters.Add("@p1", textBox1.Text);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                textBox3.Show();
                textBox4.Show();
                label3.Show();
                label4.Show();
                button4.Show();
                Random rand = new Random();
                for (int i = 1; i <= 6; i++)
                {
                    vectImagini[i] = rand.Next(1, 20);
                    img[i] = new Bitmap(Form1.path + "Captcha\\" + vectImagini[i] + ".jpg");
                    img[i] = new Bitmap(img[i], pictureBox1.Width, pictureBox1.Height);
                    if (areOameni[vectImagini[i]] == 1)
                        ctVect++;

                }
                int ct = 1;
                foreach (Control c in this.Controls)
                {
                    PictureBox pb = c as PictureBox;
                    if (pb != null)
                    {
                        pb.Image = img[ct];
                       // listBox1.Items.Add(vectImagini[ct]);
                        ct++;
                    }
                }
                MessageBox.Show("Apasati pe toate imaginile cu oameni!");
            }
            else
            {
                MessageBox.Show("Utilizatorul nu exista!");
            }
            rdr.Close();
            anulare();
            
        }
            
        void anulare()
        {
            textBox3.Hide();
            textBox4.Hide();
            label3.Hide();
            label4.Hide();
            button4.Hide();
        }
        void afisare()
        {
            textBox3.Show();
            textBox4.Show();
            label3.Show();
            label4.Show();
            button4.Show();
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (areOameni[vectImagini[1]] == 1)
            {
                ctApas++;
                if (ctApas == ctVect) {
                    MessageBox.Show("Captcha reusit! Completati cu parola noua!");
                    afisare();
                }
            }
            else
            {
                gresit = 1;
                anulare();
                MessageBox.Show("Captcha gresit!");
            }


        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (areOameni[vectImagini[2]] == 1)
            {
                ctApas++;
                if (ctApas == ctVect) {
                    MessageBox.Show("Captcha reusit! Completati cu parola noua!");
                    afisare();
                }
            }
            else
            {
                gresit = 1;
                anulare();
                MessageBox.Show("Captcha gresit!");
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (areOameni[vectImagini[3]] == 1)
            {
                ctApas++;
                if (ctApas == ctVect)
                {
                    MessageBox.Show("Captcha reusit! Completati cu parola noua!");
                    afisare();
                }
            }
            else
            {
                gresit = 1;
                anulare();
                MessageBox.Show("Captcha gresit!");
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (areOameni[vectImagini[4]] == 1)
            {
                ctApas++;
                if (ctApas == ctVect)
                {
                    MessageBox.Show("Captcha reusit! Completati cu parola noua!");
                    afisare();
                }
            }
            else
            {
                gresit = 1;
                anulare();
                MessageBox.Show("Captcha gresit!");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (areOameni[vectImagini[5]] == 1)
            {
                ctApas++;
                if (ctApas == ctVect)
                {
                    MessageBox.Show("Captcha reusit! Completati cu parola noua!");
                    afisare();
                }
            }
            else
            {
                gresit = 1;
                anulare();
                MessageBox.Show("Captcha gresit!");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (areOameni[vectImagini[6]] == 1)
            {
                ctApas++;
                if (ctApas == ctVect) {  
                    MessageBox.Show("Captcha reusit! Completati cu parola noua!");
                    afisare();
                   }
            }
            else
            {
                gresit = 1;
                anulare();
                MessageBox.Show("Captcha gresit!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int ok = 0;
            if (textBox3.Text == textBox4.Text)
                ok = 1;
            if (ok == 1)
            {
                SqlCommand cmdUpdate = new SqlCommand("Update Utilizatori set Parola=@p1 where Email=@p2", Form1.con);
                cmdUpdate.Parameters.Add("@p1", textBox3.Text);
                cmdUpdate.Parameters.Add("@p2", textBox1.Text);
                cmdUpdate.ExecuteNonQuery();
                anulare();
            }
        }
    }
}

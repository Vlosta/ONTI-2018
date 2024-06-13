using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.IO;
using System.Drawing.Drawing2D;

namespace ONTI2018
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        public static Bitmap imgTraseu;
        TextBox[] txtbox = new TextBox[25];
        Bitmap img;
        string path = "";
        int scor = 0;
        Point[] puncte = new Point[76];
        

        void afis(int start, int stop)
        {
            for (int k = start; k <= stop; k++)
            {

                txtbox[k].Show();
            }
        }
        void dis(int start,int stop)
        {
            for (int i = start; i <= stop; i++)
                txtbox[i].Hide();
                 
               
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            img = new Bitmap(pictureBox1.Width,pictureBox1.Height);
            Graphics g = Graphics.FromImage(img);
            g.Clear(Color.Azure);
            path = System.IO.Directory.GetCurrentDirectory();
            path += "\\Resurse_C#\\";

            StreamReader sr = new StreamReader(path + "\\Harti\\RomaniaMare.txt");
            string line = "";
            int ct = 0;
            while((line=sr.ReadLine())!=null)
            {
                puncte[ct].X = Convert.ToInt32(line.Split('*')[0]);
                puncte[ct].Y = Convert.ToInt32(line.Split('*')[1]);
                ct++;

            }
            g.DrawPolygon(Pens.Black, puncte);
            PathGradientBrush br = new PathGradientBrush(puncte);
            Color[] colors = { Color.Red, Color.Yellow,Color.Blue};
            ColorBlend clrBlend = new ColorBlend();
            clrBlend.Colors = colors;
            float[] relativePositions = { 0.0f, 0.2f, 1.0f };
            clrBlend.Positions = relativePositions;
            br.InterpolationColors = clrBlend;
            
             g.FillPolygon(br, puncte);
            
            pictureBox1.Image = img;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(img);
            int ctNr=0;
            StreamReader sr = new StreamReader(path + "\\Harti\\RomaniaMare.txt");
            for (int i = 0; i <= 10; i++)
            {
                 
                // textBox1.Text+=(System.IO.Directory.GetFiles(path + "Harti")[i])+'\n';
                if (System.IO.Directory.GetFiles(path + "Harti")[i] != path + "Harti\\RomaniaMare.txt")
                {
                     sr = new StreamReader(System.IO.Directory.GetFiles(path + "Harti")[i]);
                    string line1 = "";
                    int xVechi = 0, yVechi = 0;
                    int ctPct = 0;

                    while ((line1 = sr.ReadLine()) != null)
                    {
                        if (ctPct != 0)
                        {
                            int x = Convert.ToInt32(line1.Split('*')[0]);
                            int y = Convert.ToInt32(line1.Split('*')[1]);
                            if (xVechi != 0 & yVechi != 0)
                                g.DrawLine(Pens.Black, xVechi, yVechi, x, y);
                            xVechi = x; yVechi = y;
                        }
                        if (ctPct == 0)
                        {
                            int x = 0; int y = 0;
                            x = Convert.ToInt32(line1.Split('*')[0]);
                            y = Convert.ToInt32(line1.Split('*')[1]);
                            Font fnt = new Font("Arial", 12);
                            g.FillEllipse(Brushes.Black, x, y, 5, 5);
                            g.DrawString(line1.Split('*')[2], fnt, Brushes.Black, x + 10, y);
                            txtbox[ctNr] = new TextBox();
                            txtbox[ctNr].Location = new Point(x, y - 50);
                            txtbox[ctNr].Size = new Size(75, 20);
                            txtbox[ctNr].Enabled = true;
                            txtbox[ctNr + 10] = new TextBox();
                            txtbox[ctNr + 10].Location = new Point(x, y - 25);
                            txtbox[ctNr + 10].Size = new Size(75, 20);
                            txtbox[ctNr + 10].Enabled = true;
                            /* pictureBox1.Controls.Add(txtbox[ctNr]);
                            pictureBox1.Controls.Add(txtbox[ctNr + 10]);
                            */


                        }
                        ctPct++;
                         

                    }
                    ctNr++;
                }
            }
            for (int i = 0; i <= ctNr + 10; i++)
                pictureBox1.Controls.Add(txtbox[i]);

            pictureBox1.Image = img;
            int ct = 0;
            foreach (TextBox tx in pictureBox1.Controls)
            { tx.Text = "";
                ct++;
            }
            txtbox[10].Text = "Banat";
            txtbox[11].Text = "Basarabia";
            txtbox[12].Text = "Bucovina";
            txtbox[13].Text = "Crisana";
            txtbox[14].Text = "Dobrogea";
            txtbox[15].Text = "Maramures";
            txtbox[16].Text = "Moldova";
            txtbox[17].Text = "Muntenia";
            txtbox[18].Text = "Oltenia";
            txtbox[19].Text = "Transilvania";
            dis(10, 19);
            imgTraseu = img;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ct = 0;
            for (int i = 0; i <= 9; i++)
                if (txtbox[i].Text == txtbox[i + 10].Text)
                    ct++;
                else if(txtbox[i].Text!="")
                {
                    txtbox[i + 10].Show();
                    txtbox[i].ReadOnly = true;
                    Font fnt = new Font("Arial", 12,FontStyle.Strikeout);

                    txtbox[i].Font = fnt;
                }
            scor = ct;
            textBox1.Text = scor.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.Show();
            
        }
    }
}

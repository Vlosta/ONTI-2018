using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ONTI2018
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        int ctRand = 0, ctColoana = 0;
        string path = "";
        private void button1_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.RowCount++;
            label1.Text = tableLayoutPanel1.RowCount.ToString();
            tableLayoutPanel1.Invalidate();
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
           /* Graphics g = tableLayoutPanel1.CreateGraphics();
            g.Clear(Color.White);
            for(int i=1; i<=tableLayoutPanel1.RowCount; i++)
            {
                int increment = tableLayoutPanel1.Height / tableLayoutPanel1.RowCount+1;
                g.DrawLine(Pens.Gray, 0, i * increment, tableLayoutPanel1.Width, i * increment);
            }
            for (int i = 1; i <= tableLayoutPanel1.ColumnCount; i++)
            {
                int increment = tableLayoutPanel1.Width / tableLayoutPanel1.ColumnCount + 1;
                g.DrawLine(Pens.Gray, i*increment,0,i*increment,tableLayoutPanel1.Height);
            }*/
         }

        private void button3_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.ColumnCount++;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50));
             label2.Text = tableLayoutPanel1.ColumnCount.ToString();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            path = System.IO.Directory.GetCurrentDirectory();
            path += "\\Resurse_C#\\";
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            RichTextBox rb = new RichTextBox();
            rb.Width = tableLayoutPanel1.Width / tableLayoutPanel1.ColumnCount;
            rb.Height = tableLayoutPanel1.Height / tableLayoutPanel1.RowCount;
            tableLayoutPanel1.Controls.Add(rb, ctColoana, ctRand);
            rb.Text = "Aici se scrie!";

            if (ctColoana == tableLayoutPanel1.ColumnCount)
            { ctColoana = 0; ctRand++; }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Bitmap btmp = new Bitmap(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            tableLayoutPanel1.DrawToBitmap(btmp, new Rectangle(0, 0, btmp.Width, btmp.Height));
            btmp.Save(path + "ContinutLectii\\" + textBox1.Text + ".bmp");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            PictureBox pb = new PictureBox();
            pb.Width = tableLayoutPanel1.Width / tableLayoutPanel1.ColumnCount;
            pb.Height = tableLayoutPanel1.Height / tableLayoutPanel1.RowCount;

            tableLayoutPanel1.Controls.Add(pb,ctColoana,ctRand);
            
            openFileDialog1.ShowDialog();
            
            Bitmap img = new Bitmap(openFileDialog1.FileName);
            //  Graphics g = Graphics.FromImage(img);
            //  g.Clear(Color.Red);
            img = new Bitmap(img, pb.Size);
            pb.Image = img;
            if(ctColoana==tableLayoutPanel1.ColumnCount)
            { ctColoana = 0; ctRand++; }    

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Globalization;

namespace ONTI2018
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            con.Open();
        }
        public static int logat = 0;
        public static Form2 frm2;
        public static string path="";
      //  public static SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\CentenarDB.mdf;Integrated Security=True;Connect Timeout=30");
        public static SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=G:\\C# Rezolvari\\ONTI 2018\\ONTI2018\\ONTI2018\\CentenarDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void Form1_Load(object sender, EventArgs e)
        {
            button3.Hide();
            path = System.IO.Directory.GetCurrentDirectory();
            path += "\\Resurse_C#\\";
             StreamReader sr = new StreamReader(path + "lectii.txt");
            string line = "";
            while((line=sr.ReadLine())!=null)
            {
                SqlCommand cmd = new SqlCommand("Insert into Lectii(IdUtilizator,TitluLectie,Regiune,DataCreare,NumeImagine) values(@p1,@p2,@p3,@p4,@p5)", con);
                cmd.Parameters.Add("@p1", line.Split('*')[0]);
                cmd.Parameters.Add("@p2", line.Split('*')[1]);
                cmd.Parameters.Add("@p3", line.Split('*')[2]);
                DateTime dt = DateTime.ParseExact(line.Split('*')[3], "M/dd/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
               cmd.Parameters.Add("@p4", dt);
                cmd.Parameters.Add("@p5", line.Split('*')[4]);
                //cmd.ExecuteNonQuery();

            }
            line = "";
            sr = new StreamReader(path + "utilizatori.txt");
            while((line=sr.ReadLine())!=null)
            {
                string nume = line.Split('*')[0];
                string parola = line.Split('*')[1];
                string email = line.Split('*')[2];
                SqlCommand cmd = new SqlCommand("Insert into Utilizatori(Nume,Parola,Email) values(@p1,@p2,@p3)", con);
                cmd.Parameters.Add("@p1", nume);
                cmd.Parameters.Add("@p2", parola);
                cmd.Parameters.Add("@p3", email);
              //  cmd.ExecuteNonQuery();
            }

            SqlCommand cmdRead = new SqlCommand("Select NumeImagine from Lectii", con);
            SqlDataReader rdr = cmdRead.ExecuteReader();
            while(rdr.Read())
            { 
                comboBox1.Items.Add(rdr[0]);
            }

            rdr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select IdUtilizator,TitluLectie,Regiune,DataCreare from Lectii where NumeImagine=@p1", con);
             cmd.Parameters.Add("@p1",comboBox1.SelectedItem.ToString());
             SqlDataReader rdr = cmd.ExecuteReader();
             rdr.Read();
            richTextBox1.Text = "";
             richTextBox1.Text += rdr[2].ToString()+'\n';
            richTextBox1.Text += rdr[3].ToString()+'\n';
            int idUser = Convert.ToInt32(rdr[0]);
             rdr.Close();
            SqlCommand cmd1 = new SqlCommand("Select Nume,Email from Utilizatori where IdUtilizator=@p1", con);
            cmd1.Parameters.Add("@p1", idUser);
            SqlDataReader rdr1 = cmd1.ExecuteReader();
            rdr1.Read();
            richTextBox1.Text += rdr1[0].ToString() + '\n';
            richTextBox1.Text += rdr1[1].ToString() + '\n';
            rdr1.Close();
            Bitmap btmp = new Bitmap(path + "ContinutLectii\\" + comboBox1.SelectedItem.ToString() + ".bmp");
            btmp = new Bitmap(btmp, pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = btmp;
            //richTextBox1.Text = comboBox1.SelectedItem.ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm2 = new Form2();
            frm2.Show();
        }

        private void Activated(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace ComputerGenius
{
    public partial class Form4 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["ComputerGenius"].ConnectionString;
        public Form4()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Hide();
            f3.Show();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            textBox1.Text = LoginPage.Id.ToString();
            textBox2.Text = LoginPage.name;
            textBox3.Text = LoginPage.pass;
            textBox4.Text = LoginPage.email;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update member set id=@id, name=@pass,pass=@pass ,email=@email where id=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@pass", textBox3.Text);
            cmd.Parameters.AddWithValue("@email", textBox4.Text);


            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Update successful !");
                textBox1.Text = LoginPage.Id.ToString();
                textBox2.Text = LoginPage.name;
                textBox3.Text = LoginPage.pass;
                textBox4.Text = LoginPage.email;


                Form3 f3 = new Form3();
                this.Hide();
                f3.Show();
            }


            else
            {
                MessageBox.Show("Update failed!", "Enter valid information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

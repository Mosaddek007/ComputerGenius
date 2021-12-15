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
    public partial class Form2 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["ComputerGenius"].ConnectionString;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" )
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "insert into member (id,name,pass,email) values(@id,@name,@pass,@email)";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("id", textBox1.Text);
                cmd.Parameters.AddWithValue("name", textBox2.Text);
                cmd.Parameters.AddWithValue("pass", textBox3.Text);
                cmd.Parameters.AddWithValue("email", textBox4.Text);

                int b = cmd.ExecuteNonQuery();
                if (b > 0)
                {
                    LoginPage f1 = new LoginPage();
                    this.Hide();
                    f1.Show();
                }
                else
                {
                    MessageBox.Show("Your Information Is Incorrect !");
                }
            }
            else
            {
                MessageBox.Show("Fill Up All The Information Please");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoginPage f1 = new LoginPage();
            this.Hide();
            f1.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

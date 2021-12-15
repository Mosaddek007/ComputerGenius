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
    public partial class LoginPage : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["ComputerGenius"].ConnectionString;
        public LoginPage()
        {
            InitializeComponent();
        }
        public static int Id;
        public static string name;
        public static string pass;
        public static string email;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select *from member where id = @id and pass = @pass";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("id", textBox1.Text);
                cmd.Parameters.AddWithValue("pass", textBox2.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Id = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                    name = dt.Rows[0]["name"].ToString();
                    pass = dt.Rows[0]["pass"].ToString();
                    email = dt.Rows[0]["email"].ToString();
                    

                    Form3 f3 = new Form3();
                    this.Hide();
                    f3.Show();
                }
                else
                {
                    MessageBox.Show("Your PassWord is Wrong, Try Again");
                }
            }
            else
            {
                MessageBox.Show("Please Enter Your ID & PassWord");
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }
    }
}

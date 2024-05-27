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

namespace D11016229
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        int times;
        private void OK_Click(object sender, EventArgs e)
        {
            string name = "";
            string op = "";
            SqlConnection cnn = new SqlConnection("Data source=192.192.140.111;initial catalog=D11016229;user ID=sa;Password=2022Takming");
            SqlCommand cmd = new SqlCommand("Select 員工姓名,權限 from 員工資料表 where 員工代號='" + UsernameTextBox.Text +"' and 密碼='" + PasswordTextBox.Text +"'",cnn);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                name = (string)dr.GetValue(0);
                op = (string)dr.GetValue(1);
            }
            if (name != "")
            {
                Main main = new Main();
                main.Show();
                this.Hide();
            }
            else
            {
                times++;
                if(times == 3)
                {
                    MessageBox.Show("你登入失敗三次了!請確認您的帳號密碼。");
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("登入失敗!");
                }
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

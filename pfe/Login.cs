using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pfe
{
    public partial class Login : Form
    {
       
        private connection ado = new connection();
        public Login()
        {
            InitializeComponent();
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            ado.dt.Rows.Clear();
            ado.cmd.CommandText = "select count(*) from users where username = '"+textBox1.Text+"' and password = '"+textBox2.Text+"'";
            ado.cmd.Connection = ado.cn;
            ado.sda.SelectCommand = ado.cmd;
            ado.sda.Fill(ado.dt);
            //MessageBox.Show(ado.dt.Rows[0][0].ToString());
            if (ado.dt.Rows[0][0].ToString() == "1")
            {

                MenuPrincipal menuPrincipal = new MenuPrincipal();
                menuPrincipal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("username or password incorrect");
                textBox1.Clear();
                textBox2.Clear();
                ado.dt.Rows.Clear();
                return;
            }

        }

        private void Login_Load(object sender, EventArgs e)
        {
            ado.Connect();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

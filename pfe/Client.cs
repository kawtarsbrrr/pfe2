using System;
using System.Windows.Forms;

namespace pfe
{
    public partial class Client : Form
    {
        private connection ado = new connection();
        public Client()
        {
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            ado.Connect();
            dataGridClt.Rows.Clear();
            ado.cmd.CommandText = "select * from client";
            ado.cmd.Connection = ado.cn;
            ado.dr = ado.cmd.ExecuteReader();
            while (ado.dr.Read())
            {
                dataGridClt.Rows.Add(ado.dr.GetValue(0).ToString(), ado.dr.GetValue(2).ToString(),
                    ado.dr.GetValue(3).ToString(), ado.dr.GetValue(4).ToString(), ado.dr.GetValue(5).ToString());
            }//gets input from the searchbox and matches it to the database then prints the matched data in the datagrid
            ado.dr.Close();//closes the reader
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridClt.Rows.Clear();
            ado.cmd.CommandText = "select * from client where code_clt = " + int.Parse(searchBoxClt.Text);
            ado.cmd.Connection = ado.cn;
            ado.dr = ado.cmd.ExecuteReader();
            while (ado.dr.Read())
            {
                dataGridClt.Rows.Add(ado.dr.GetValue(0).ToString(), ado.dr.GetValue(2).ToString(),
                    ado.dr.GetValue(3).ToString(), ado.dr.GetValue(4).ToString(), ado.dr.GetValue(5).ToString());
            }//gets input from the searchbox and matches it to the database then prints the matched data in the datagrid
            ado.dr.Close();//closes the reader
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridClt.Rows.Clear();
            ado.cmd.CommandText = "select * from client";
            ado.cmd.Connection = ado.cn;
            ado.dr = ado.cmd.ExecuteReader();
            while (ado.dr.Read())
            {
                dataGridClt.Rows.Add(ado.dr.GetValue(0).ToString(), ado.dr.GetValue(2).ToString(),
                    ado.dr.GetValue(3).ToString(), ado.dr.GetValue(4).ToString(), ado.dr.GetValue(5).ToString());
            }//gets input from the searchbox and matches it to the database then prints the matched data in the datagrid
            ado.dr.Close();//closes the reader
        }

        private void button9_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        int currentClt = 0;
        private void dataGridClt_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ado.cmd.CommandText = "select * from client where code_clt =" + dataGridClt.Rows[e.RowIndex].Cells[0].Value;
            ado.cmd.Connection = ado.cn;
            ado.dr = ado.cmd.ExecuteReader();
            while (ado.dr.Read())
            {
                currentClt = int.Parse(ado.dr["code_clt"].ToString());
                cin_clt.Text = ado.dr["cin_clt"].ToString();
                nom_clt.Text = ado.dr["raisonsocial"].ToString();
                tele_clt.Text = ado.dr["tele_clt"].ToString();
                email_clt.Text = ado.dr["email_clt"].ToString();
                
            }
            ado.dr.Close();
            tabControl1.SelectedTab = tabPage2;
            button1.Enabled = false;
            button3.Enabled = true;
            button4.Enabled = true;
        }
    }
}
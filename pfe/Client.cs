using System;
using System.Linq;
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
            cin_clt.Text = "";
            nom_clt.Text = "";
            tele_clt.Text = "";
            email_clt.Text = "";
            button1.Enabled = true;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
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

        private int currentClt = 0;

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (cin_clt.Text == "" || nom_clt.Text == "" || tele_clt.Text == "" || email_clt.Text == "")
            {
                MessageBox.Show("remplir tout les champs svp");
                return;
            }//making sure no input box is empty, gotta be full :)
            ado.cmd.CommandText = "insert into client(cin_clt, nom_clt,tele_clt,email_clt) " +
                "values (" + cin_clt.Text + "','" + nom_clt.Text + "','" +
                tele_clt.Text + "','" + email_clt.Text + "')";
            ado.cmd.Connection = ado.cn;
            ado.cmd.ExecuteNonQuery(); //adding new data to database

            MessageBox.Show("done");

            cin_clt.Text = "";
            nom_clt.Text = "";
            tele_clt.Text = "";
            email_clt.Text = "";
            //clearing textboxes for new entry
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cin_clt.Text == "" || nom_clt.Text == "" || tele_clt.Text == "" || email_clt.Text == "")
            {
                MessageBox.Show("remplir tout les champs svp");
                return;
            }//making sure no input box is empty, gotta be full :)
            ado.cmd.CommandText = "update client set cin_clt = '" + cin_clt.Text + "', raisonsocial = '" + nom_clt.Text + "', tele_clt = '" + tele_clt.Text + "', email_clt = '" + email_clt.Text + "' where code_clt = " + currentClt;
            //"insert into client(cin_clt, nom_clt,tele_clt,email_clt) " +
            //    "values (" + cin_clt.Text + "','" + nom_clt.Text + "','" +
            //    tele_clt.Text + "','" + email_clt.Text + "')";
            ado.cmd.Connection = ado.cn;
            ado.cmd.ExecuteNonQuery(); //adding new data to database

            MessageBox.Show("done");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ado.cmd.CommandText = "delete from client where code_clt =" + currentClt;
            ado.cmd.Connection = ado.cn;
            ado.cmd.ExecuteNonQuery();
            MessageBox.Show("suppression faite");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<sousformFactureClient>().Count() == 1)
            {
                Application.OpenForms.OfType<sousformFactureClient>().First().Close();
            }
            sousformFactureClient sousform1 = new sousformFactureClient();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<sousformBL>().Count() == 1)
            {
                Application.OpenForms.OfType<sousformBL>().First().Close();
            }
            sousformBL sousform2 = new sousformBL();
            sousform2.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<sousformeCommandeClt>().Count() == 1)
            {
                Application.OpenForms.OfType<sousformeCommandeClt>().First().Close();
            }
            sousformeCommandeClt sousform3 = new sousformeCommandeClt();
            sousform3.Show();
        }
    }
}
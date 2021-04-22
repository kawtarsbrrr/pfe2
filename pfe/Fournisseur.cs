using System;
using System.Windows.Forms;

namespace pfe
{
    public partial class Fournisseur : Form
    {
        private connection ado = new connection();

        public Fournisseur()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridFrs.Rows.Clear();
            ado.cmd.CommandText = "select * from fournisseur where idf_frs = " + int.Parse(searchBoxFrs.Text);
            ado.cmd.Connection = ado.cn;
            ado.dr = ado.cmd.ExecuteReader();
            while (ado.dr.Read())
            {
                dataGridFrs.Rows.Add(ado.dr.GetValue(0).ToString(), ado.dr.GetValue(1).ToString(), ado.dr.GetValue(2).ToString(),
                    ado.dr.GetValue(3).ToString(), ado.dr.GetValue(4).ToString(), ado.dr.GetValue(5).ToString(),
                    ado.dr.GetValue(6).ToString(), ado.dr.GetValue(7).ToString(), ado.dr.GetValue(8).ToString());
            }//gets input from the searchbox and matches it to the database then prints the matched data in the datagrid
            ado.dr.Close();//closes the reader
        }

        private void Fournisseur_Load(object sender, EventArgs e)
        {
            ado.Connect();
            dataGridFrs.Rows.Clear();
            ado.cmd.CommandText = "select * from fournisseur";
            ado.cmd.Connection = ado.cn;
            ado.dr = ado.cmd.ExecuteReader();
            while (ado.dr.Read())
            {
                dataGridFrs.Rows.Add(ado.dr.GetValue(0).ToString(), ado.dr.GetValue(1).ToString(), ado.dr.GetValue(2).ToString(),
                    ado.dr.GetValue(3).ToString(), ado.dr.GetValue(4).ToString(), ado.dr.GetValue(5).ToString(),
                    ado.dr.GetValue(6).ToString(), ado.dr.GetValue(7).ToString(), ado.dr.GetValue(8).ToString());
            }//gets input from the searchbox and matches it to the database then prints the matched data in the datagrid
            ado.dr.Close();//closes the reader
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //test
            dataGridFrs.Rows.Clear();
            ado.cmd.CommandText = "select * from fournisseur";
            ado.cmd.Connection = ado.cn;
            ado.dr = ado.cmd.ExecuteReader();
            while (ado.dr.Read())
            {
                dataGridFrs.Rows.Add(ado.dr.GetValue(0).ToString(), ado.dr.GetValue(1).ToString(), ado.dr.GetValue(2).ToString(),
                    ado.dr.GetValue(3).ToString(), ado.dr.GetValue(4).ToString(), ado.dr.GetValue(5).ToString(),
                    ado.dr.GetValue(6).ToString(), ado.dr.GetValue(7).ToString(), ado.dr.GetValue(8).ToString());
            }//gets input from the searchbox and matches it to the database then prints the matched data in the datagrid
            ado.dr.Close();//closes the reader
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ICE.Text = "";
            raison_social.Text = "";
            tele_frs.Text = "";
            email_frs.Text = "";
            registre_com.Text = "";
            id_fiscale.Text = "";
            adresse.Text = "";
            ville.Text = ""; //clearing textboxes for new entry
            tabControl1.SelectedTab = tabPage2;
            button1.Enabled = true;
            button3.Enabled = false;
            button7.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ICE.Text == "" || raison_social.Text == "" || tele_frs.Text == "" || email_frs.Text == "" || registre_com.Text == "" || id_fiscale.Text == "" || adresse.Text == "" || ville.Text == "")
            {
                MessageBox.Show("remplir tout les champs svp");
                return;
            }//making sure no input box is empty, gotta be full :)
            ado.cmd.CommandText = "insert into fournisseur(ICE, raison_social,tele_frs,email_frs,registre_com,Id_Fiscale,adresse,ville) " +
                "values (" + ICE.Text + "','" + raison_social.Text + "','" + tele_frs.Text + "','" +
                email_frs.Text + "','" + registre_com.Text + "','" + id_fiscale.Text + "','" + adresse.Text + "','" +
                ville.Text + "')";
            ado.cmd.Connection = ado.cn;
            ado.cmd.ExecuteNonQuery(); //adding new data to database

            MessageBox.Show("done");

            ICE.Text = "";
            raison_social.Text = "";
            tele_frs.Text = "";
            email_frs.Text = "";
            registre_com.Text = "";
            id_fiscale.Text = "";
            adresse.Text = "";
            ville.Text = ""; //clearing textboxes for new entry
        }

        private void dataGridFrs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private int currentFrs = 0;

        private void dataGridFrs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ado.cmd.CommandText = "select * from fournisseur where idf_frs =" + dataGridFrs.Rows[e.RowIndex].Cells[0].Value;
            ado.cmd.Connection = ado.cn;
            ado.dr = ado.cmd.ExecuteReader();
            while (ado.dr.Read())
            {
                currentFrs = int.Parse(ado.dr["idf_frs"].ToString());
                ICE.Text = ado.dr["ICE"].ToString();
                raison_social.Text = ado.dr["raison_social"].ToString();
                tele_frs.Text = ado.dr["tele_frs"].ToString();
                email_frs.Text = ado.dr["email_frs"].ToString();
                registre_com.Text = ado.dr["registre_com"].ToString();
                id_fiscale.Text = ado.dr["id_fiscale"].ToString();
                adresse.Text = ado.dr["adresse"].ToString();
                ville.Text = ado.dr["ville"].ToString();
            }
            ado.dr.Close();
            tabControl1.SelectedTab = tabPage2;
            button1.Enabled = false;
            button3.Enabled = true;
            button7.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            dataGridFrs.Rows.Clear();
            ado.cmd.CommandText = "select * from fournisseur";
            ado.cmd.Connection = ado.cn;
            ado.dr = ado.cmd.ExecuteReader();
            while (ado.dr.Read())
            {
                dataGridFrs.Rows.Add(ado.dr.GetValue(0).ToString(), ado.dr.GetValue(1).ToString(), ado.dr.GetValue(2).ToString(),
                    ado.dr.GetValue(3).ToString(), ado.dr.GetValue(4).ToString(), ado.dr.GetValue(5).ToString(),
                    ado.dr.GetValue(6).ToString(), ado.dr.GetValue(7).ToString(), ado.dr.GetValue(8).ToString());
            }//gets input from the searchbox and matches it to the database then prints the matched data in the datagrid
            ado.dr.Close();//closes the reader
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ICE.Text == "" || raison_social.Text == "" || tele_frs.Text == "" || email_frs.Text == "" || registre_com.Text == "" || id_fiscale.Text == "" || adresse.Text == "" || ville.Text == "")
            {
                MessageBox.Show("remplir tout les champs svp");
                return;
            }//making sure no input box is empty, gotta be full :)
            ado.cmd.CommandText = "update fournisseur set ICE =" + ICE.Text + " , raison_social ='" + raison_social.Text + "' ,tele_frs" +
                " = '" + tele_frs.Text + "',email_frs= '" + email_frs.Text +
                "' ,registre_com= '" + registre_com.Text + "',Id_Fiscale='" + id_fiscale.Text + "' ,adresse='" + adresse.Text + "' " +
                ",ville= '" + ville.Text + "' where idf_frs =  " + currentFrs;

            ado.cmd.Connection = ado.cn;
            ado.cmd.ExecuteNonQuery();
            MessageBox.Show("modification applique");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ado.cmd.CommandText = "delete from fournisseur where idf_frs =" + currentFrs;
            ado.cmd.Connection = ado.cn;
            ado.cmd.ExecuteNonQuery();
            MessageBox.Show("suppression faite");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
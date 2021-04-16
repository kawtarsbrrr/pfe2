using System;
using System.Windows.Forms;

namespace pfe
{
    public partial class Commandes : Form
    {
        private connection ado = new connection();

        public Commandes()
        {
            InitializeComponent();
        }

        private void BonLivraison_Load(object sender, EventArgs e)
        {
            ado.Connect();
            ado.cmd.CommandText = "select raisonsocial from client";
            ado.cmd.Connection = ado.cn;
            ado.dr = ado.cmd.ExecuteReader();
            while (ado.dr.Read())
            {
                comboBox1.Items.Add(ado.dr["raisonsocial"]);
            }
            ado.dr.Close();

            ado.cmd.CommandText = "select ref_art from article";
            ado.cmd.Connection = ado.cn;
            ado.dr = ado.cmd.ExecuteReader();
            while (ado.dr.Read())
            {
                comboBox2.Items.Add(ado.dr["ref_art"]);
            }
            ado.dr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int qtestock = 0;
            ado.cmd.CommandText = "select qte_stock from Article where ref_art = " + int.Parse(comboBox2.Text);
            ado.cmd.Connection = ado.cn;
            ado.dr = ado.cmd.ExecuteReader();
            while (ado.dr.Read())
            {
                qtestock = int.Parse(ado.dr["qte_stock"].ToString());
            }
            ado.dr.Close();
            if (qtestock >= int.Parse(textBox7.Text))
            {
                dataGridView1.Rows.Add(comboBox2.Text, textBox5.Text, textBox7.Text, textBox8.Text);
            }
            else
            {
                MessageBox.Show("quantite stock inferieur a quantite vendu!!");
                textBox7.Clear();
                return;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ado.cmd.CommandText = "select code_clt from Client where raisonsocial = '" + comboBox1.Text + "'";
            ado.cmd.Connection = ado.cn;
            ado.dr = ado.cmd.ExecuteReader();
            while (ado.dr.Read())
            {
                textBox2.Text = ado.dr["code_clt"].ToString();
            }
            ado.dr.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ado.cmd.CommandText = "select design_art, qte_stock from Article where ref_art = " + int.Parse(comboBox2.Text);
            ado.cmd.Connection = ado.cn;
            ado.dr = ado.cmd.ExecuteReader();
            while (ado.dr.Read())
            {
                textBox5.Text = ado.dr["design_art"].ToString();
                textBox6.Text = ado.dr["qte_stock"].ToString();
            }
            ado.dr.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox5.Clear(); textBox6.Clear(); textBox7.Clear(); textBox8.Clear(); comboBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            ado.cmd.CommandText = "select qte_stock from Article";
            ado.cmd.Connection = ado.cn;
            ado.dr = ado.cmd.ExecuteReader();
            while (ado.dr.Read())
            {
                textBox6.Text = ado.dr["qte_stock"].ToString();
            }
            ado.dr.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            textBox5.Clear(); textBox6.Clear(); textBox7.Clear(); textBox8.Clear(); comboBox2.Text = "";
            comboBox1.Text = "";
            textBox2.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ado.cmd.CommandText = "insert into commande(code_clt, date_cmnd) values(" + int.Parse(textBox2.Text) + ", '" + dateTimePicker1.Text + "')";
            ado.cmd.Connection = ado.cn;
            ado.cmd.ExecuteNonQuery();

            int lastCMND = 0;
            ado.cmd.CommandText = "select max(idf_cmnd) from commande";
            ado.cmd.Connection = ado.cn;
            ado.dr = ado.cmd.ExecuteReader();
            while (ado.dr.Read())
            {
                lastCMND = int.Parse(ado.dr.GetValue(0).ToString());
            }
            ado.dr.Close();

            // MessageBox.Show(dateTimePicker1.Text);
            ado.cmd.CommandText = "insert into bon_livraison(idf_cmnd, date_liv) values (" + lastCMND + ", '" + dateTimePicker1.Text + "')";
            ado.cmd.Connection = ado.cn;
            ado.cmd.ExecuteNonQuery();

            int lastID = 0;
            ado.cmd.CommandText = "select max(idf_bl) from bon_livraison";
            ado.cmd.Connection = ado.cn;
            ado.dr = ado.cmd.ExecuteReader();
            while (ado.dr.Read())
            {
                lastID = int.Parse(ado.dr.GetValue(0).ToString());
            }
            ado.dr.Close();

            //MessageBox.Show(lastID.ToString());
            int rowCount = dataGridView1.Rows.Count;
            //MessageBox.Show(rowCount.ToString());
            for (int i = 0; i < rowCount - 1; i++)
            {
                ado.cmd.CommandText = "insert into ligne_bl(ref_art, idf_bl, qte_liv, prix_liv) values (" + int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString())
                                        + "," + lastID + ", " + int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()) + "," + int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()) + ")";
                ado.cmd.Connection = ado.cn;
                ado.cmd.ExecuteNonQuery();

                ado.cmd.CommandText = "insert into ligne_cmnd_clt(ref_art, idf_bl, qte_commande) values (" + int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString())
                                        + "," + lastCMND + ", " + int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()) + ")";
                ado.cmd.Connection = ado.cn;
                ado.cmd.ExecuteNonQuery();

                int beforeStock = 0;
                ado.cmd.CommandText = "select qte_stock from article where ref_art =" + dataGridView1.Rows[i].Cells[0].Value;
                ado.cmd.Connection = ado.cn;
                ado.dr = ado.cmd.ExecuteReader();
                while (ado.dr.Read())
                {
                    beforeStock = int.Parse(ado.dr.GetValue(0).ToString());
                }
                ado.dr.Close();

                int currentStock = beforeStock - int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                ado.cmd.CommandText = "update Article set qte_stock = " + currentStock + "where ref_art = " + dataGridView1.Rows[i].Cells[0].Value;
                ado.cmd.Connection = ado.cn;
                ado.cmd.ExecuteNonQuery();
            }
        }
    }
}
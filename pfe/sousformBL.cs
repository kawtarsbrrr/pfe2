using System;
using System.Windows.Forms;

namespace pfe
{
    public partial class sousformBL : Form
    {
        public sousformBL()
        {
            InitializeComponent();
        }

        private connection ado = new connection();

        private void sousformBL_Load(object sender, EventArgs e)
        {
            ado.Connect();

            ado.cmd.CommandText = "select idf_bl,date_liv, total_pht_bl, taux_tva_bl, montant_tva_bl, total_ttc_bl,commande.idf_cmnd, client.raisonsocial from bon_livraison inner join commande on commande.idf_cmnd = bon_livraison.idf_cmnd inner join client on client.code_clt = commande.code_clt where client.code_clt = "+ClientStuff.client;
            ado.cmd.Connection = ado.cn;
            ado.dr = ado.cmd.ExecuteReader();
            dataGridView1.ColumnCount = 8;
            dataGridView1.Columns[0].Name = "Numero BL";
            dataGridView1.Columns[1].Name = "Date BL";
            dataGridView1.Columns[2].Name = "Total HT";
            dataGridView1.Columns[3].Name = "Taux TVA";
            dataGridView1.Columns[4].Name = "Montant TVA";
            dataGridView1.Columns[5].Name = "Total TTC";
            dataGridView1.Columns[6].Name = "Numero de commande";
            dataGridView1.Columns[7].Name = "Raison Social";

            while (ado.dr.Read())
            {
                dataGridView1.Rows.Add(ado.dr["idf_bl"], ado.dr["date_liv"], ado.dr["total_pht_bl"], ado.dr["taux_tva_bl"], ado.dr["montant_tva_bl"], ado.dr["total_ttc_bl"], ado.dr["idf_cmnd"], ado.dr["raisonsocial"]);
            }
            ado.dr.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ado.cmd.CommandText = "select idf_bl,ligne_bl.ref_art, article.design_art, qte_liv,prix_liv from ligne_bl inner join article on article.ref_art = ligne_bl.ref_art where idf_bl = " +dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            ado.cmd.Connection = ado.cn;
            ado.dr = ado.cmd.ExecuteReader();
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "Numero BL";
            dataGridView1.Columns[1].Name = "Reference article";
            dataGridView1.Columns[2].Name = "Designation Article";
            dataGridView1.Columns[3].Name = "Qte Livré";
            dataGridView1.Columns[4].Name = "Prix HT";

            while (ado.dr.Read())
            {
                dataGridView1.Rows.Add(ado.dr["idf_bl"], ado.dr["ref_art"], ado.dr["design_art"], ado.dr["qte_liv"], ado.dr["prix_liv"]);
            }
            ado.dr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            ado.cmd.CommandText = "select idf_bl,date_liv, total_pht_bl, taux_tva_bl, montant_tva_bl, total_ttc_bl,commande.idf_cmnd, client.raisonsocial from bon_livraison inner join commande on commande.idf_cmnd = bon_livraison.idf_cmnd inner join client on client.code_clt = commande.code_clt where client.code_clt = " + ClientStuff.client;
            ado.cmd.Connection = ado.cn;
            ado.dr = ado.cmd.ExecuteReader();
            dataGridView1.ColumnCount = 8;
            dataGridView1.Columns[0].Name = "Numero BL";
            dataGridView1.Columns[1].Name = "Date BL";
            dataGridView1.Columns[2].Name = "Total HT";
            dataGridView1.Columns[3].Name = "Taux TVA";
            dataGridView1.Columns[4].Name = "Montant TVA";
            dataGridView1.Columns[5].Name = "Total TTC";
            dataGridView1.Columns[6].Name = "Numero de commande";
            dataGridView1.Columns[7].Name = "Raison Social";

            while (ado.dr.Read())
            {
                dataGridView1.Rows.Add(ado.dr["idf_bl"], ado.dr["date_liv"], ado.dr["total_pht_bl"], ado.dr["taux_tva_bl"], ado.dr["montant_tva_bl"], ado.dr["total_ttc_bl"], ado.dr["idf_cmnd"], ado.dr["raisonsocial"]);
            }
            ado.dr.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
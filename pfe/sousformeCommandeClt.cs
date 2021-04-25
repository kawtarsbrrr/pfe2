using System;
using System.Windows.Forms;

namespace pfe
{
    public partial class sousformeCommandeClt : Form
    {
        public sousformeCommandeClt()
        {
            InitializeComponent();
        }

        private connection ado = new connection();

        

        private void sousformeCommandeClt_Load(object sender, EventArgs e)
        {
            ado.Connect();

            ado.cmd.CommandText = "select * from commande where code_clt = " +ClientStuff.client;
            ado.cmd.Connection = ado.cn;
            ado.dr = ado.cmd.ExecuteReader();
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "ID Commande";
            dataGridView1.Columns[1].Name = "Date Commande";
            dataGridView1.Columns[2].Name = "Client";

            while (ado.dr.Read())
            {
                dataGridView1.Rows.Add(ado.dr["idf_cmnd"], ado.dr["date_cmnd"], ado.dr["code_clt"]);
            }
            ado.dr.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ado.cmd.CommandText = "select ligne_cmnd_clt.idf_cmnd, ligne_cmnd_clt.qte_commande, ligne_cmnd_clt.ref_art , article.design_art from ligne_cmnd_clt inner join article on ligne_cmnd_clt.ref_art = article.ref_art where idf_cmnd = " + dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            ado.cmd.Connection = ado.cn;
            ado.dr = ado.cmd.ExecuteReader();
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "ID Commande";
            dataGridView1.Columns[1].Name = "qte commande";
            dataGridView1.Columns[2].Name = "Designation Article";
            dataGridView1.Columns[3].Name = "reference article";

            while (ado.dr.Read())
            {
                dataGridView1.Rows.Add(ado.dr["idf_cmnd"], ado.dr["qte_commande"], ado.dr["design_art"], ado.dr["ref_art"]);
            }
            ado.dr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            ado.cmd.CommandText = "select * from commande where code_clt = " + ClientStuff.client;
            ado.cmd.Connection = ado.cn;
            ado.dr = ado.cmd.ExecuteReader();
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "ID Commande";
            dataGridView1.Columns[1].Name = "Date Commande";
            dataGridView1.Columns[2].Name = "Client";

            while (ado.dr.Read())
            {
                dataGridView1.Rows.Add(ado.dr["idf_cmnd"], ado.dr["date_cmnd"], ado.dr["code_clt"]);
            }
            ado.dr.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {


            ado.cmd.CommandText = "select commande.idf_cmnd, date_cmnd, commande.code_clt, article.ref_art, raisonsocial,qte_commande,design_art,article.prix_ht_stock*qte_commande as [total] from commande inner join ligne_cmnd_clt on commande.idf_cmnd = ligne_cmnd_clt.idf_cmnd inner join client on commande.code_clt = client.code_clt inner join article on article.ref_art = ligne_cmnd_clt.ref_art where commande.idf_cmnd = " + idf_cmnd;
            ado.cmd.Connection = ado.cn;
            ado.sda.SelectCommand = ado.cmd;
            ado.sda.Fill(ado.dt);
            Commande report = new Commande();
            Reports.Viewer viewer = new Reports.Viewer();
            report.SetDataSource(ado.dt);
            viewer.crystalReportViewer1.ReportSource = report;
            viewer.ShowDialog();

        }
        int idf_cmnd = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idf_cmnd = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
        }
    }
}
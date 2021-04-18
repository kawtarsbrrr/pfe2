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

            ado.cmd.CommandText = "select * from commande";
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
    }
}
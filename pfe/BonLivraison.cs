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
    public partial class BonLivraison : Form
    {
        private connection ado = new connection();
        public BonLivraison()
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
    }
}

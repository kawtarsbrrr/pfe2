using System;
using System.Linq;
using System.Windows.Forms;

namespace pfe
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<Commandes>().Count() == 1)
            {
                Application.OpenForms.OfType<Commandes>().First().Close();
            }
            Commandes bonLivraison = new Commandes();
            bonLivraison.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<Fournisseur>().Count() == 1)
            {
                Application.OpenForms.OfType<Fournisseur>().First().Close();
            }
            Fournisseur fournisseur = new Fournisseur();
            fournisseur.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<Client>().Count() == 1)
            {
                Application.OpenForms.OfType<Client>().First().Close();
            }
            Client client = new Client();
            client.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<sousformFactureClient>().Count() == 1)
            {
                Application.OpenForms.OfType<sousformFactureClient>().First().Close();
            }
            sousformFactureClient article = new sousformFactureClient();
            article.Show();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
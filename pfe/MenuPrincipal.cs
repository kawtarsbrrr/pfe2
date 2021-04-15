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
            if (Application.OpenForms.OfType<BonLivraison>().Count() == 1)
            {
                Application.OpenForms.OfType<BonLivraison>().First().Close();
            }
            BonLivraison bonLivraison = new BonLivraison();
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
            if (Application.OpenForms.OfType<Article>().Count() == 1)
            {
                Application.OpenForms.OfType<Article>().First().Close();
            }
            Article article = new Article();
            article.Show();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
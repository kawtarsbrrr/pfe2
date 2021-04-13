using System.Data;
using System.Data.SqlClient;

namespace pfe
{
    internal class connection
    {
        public SqlConnection cn = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public SqlDataReader dr;
        public DataTable dt = new DataTable();

        public void Connect()
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.ConnectionString = "Data Source=DESKTOP-GM7PTVC\\SQLEXPRESS01;Initial Catalog=gestion_stock;Integrated Security=True";
                cn.Open();
            }
        }

        public void Disconnect()
        {
            cn.Close();
        }
    }
}
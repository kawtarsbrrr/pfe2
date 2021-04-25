using System.Data;
using System.Data.SqlClient;

namespace pfe
{
    internal class connection
    {
        public SqlConnection cn = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public SqlDataReader dr;
        public SqlDataAdapter sda = new SqlDataAdapter();
        public DataTable dt = new DataTable();

        

        public void Connect()
        {
            if (cn.State == ConnectionState.Closed)
            {
                //yahya's
                cn.ConnectionString = "Data Source=DESKTOP-GM7PTVC\\SQLEXPRESS01;Initial Catalog=gestion_stock;Integrated Security=True";
                //kwtr's gey
                //cn.ConnectionString= "Data Source=DESKTOP-SFCSVTU\\SQLEXPRESS;Initial Catalog=magasin;Integrated Security=True";
                cn.Open();
            }
        }

        public void Disconnect()
        {
            cn.Close();
        }




        public DataTable SelectData(string proc, SqlParameter[] param)
        {
            Connect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = proc;
            if(param != null)
            {
                for (int i=0; i < param.Length; i++)
                {
                    cmd.Parameters.Add(param[i]);
                }
            }
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public DataTable GetData(int idf_cmnd)
        {
            connection con = new connection();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@idf_cmnd", SqlDbType.Int);
            param[0].Value = idf_cmnd;

            dt = SelectData("commandePrint", param);
            con.cn.Close();
            return dt;
        }
    }
}
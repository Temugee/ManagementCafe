using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementCafe
{
    class function
    {
        protected SqlConnection getConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = SL-TEMUGE\\SQLEXPRESS; database = Restro; integrated security = True";
            return con;
        }
        public DataSet getData(String query)
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public void setData(string query)
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();

            // Specify UTF-8 encoding explicitly
            cmd.CommandText = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(query));

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Амжилттай хадгаллаа.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

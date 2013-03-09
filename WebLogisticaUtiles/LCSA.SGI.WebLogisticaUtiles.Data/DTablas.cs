using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LCSA.SGI.WebLogisticaUtiles.Data
{
    public class DTablas
    {
        SqlConnection cn = new SqlConnection("Data Source = .; Initial Catalog = WEBLOGISTICA; Integrated Security = SSPI;");

        public DataTable Query(string Sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(Sql, cn);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public int DInUpDelTablas(string SQL)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = SQL;
                cmd.Connection = cn;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                i = 1;
                cmd.Dispose();
                cn.Dispose();
                cn.Close();
            }
            catch { throw; }
            return i;
        }
    }
}

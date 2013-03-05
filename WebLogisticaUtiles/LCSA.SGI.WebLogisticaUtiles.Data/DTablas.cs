using System;
using System.Data;
using cwbx;
using IBM.Data.DB2.iSeries;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LCSA.SGI.WebLogisticaUtiles.Data
{
    public class DTablas
    {
        ConexionAS400 objCn = new ConexionAS400();

        public DataTable Query(string Sql)
        {
            iDB2DataAdapter da = new iDB2DataAdapter(Sql, objCn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public int DInUpDelTablas(string SQL)
        {
            int i = 0;
            try
            {
                iDB2Command cmd = new iDB2Command();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = SQL;
                cmd.Connection = objCn.Conectar;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                i = 1;
                cmd.Dispose();
                objCn.Conectar.Dispose();
                objCn.Conectar.Close();
            }
            catch { throw; }
            return i;
        }
    }
}

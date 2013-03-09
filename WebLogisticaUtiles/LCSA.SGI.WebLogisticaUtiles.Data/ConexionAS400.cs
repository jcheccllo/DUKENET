using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LCSA.SGI.WebLogisticaUtiles.Data
{
    public class ConexionAS400
    {
        //private iDB2Connection cn = new iDB2Connection(ConfigurationManager.ConnectionStrings["Cn"].ConnectionString);
        private SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Cn"].ConnectionString);
        public SqlConnection Conectar
        {
            get
            {
                return cn;
            }
        }
    }
}

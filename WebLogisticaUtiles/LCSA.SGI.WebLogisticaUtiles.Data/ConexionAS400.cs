using System;
using System.Data;
using cwbx;
using IBM.Data.DB2.iSeries;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LCSA.SGI.WebLogisticaUtiles.Data
{
    public class ConexionAS400
    {
        private iDB2Connection cn = new iDB2Connection(ConfigurationManager.ConnectionStrings["Cn"].ConnectionString);
        public iDB2Connection Conectar
        {
            get
            {
                return cn;
            }
        }
    }
}

using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LCSA.SGI.WebLogisticaUtiles.Data;
using LCSA.SGI.WebLogisticaUtiles.Entity;

namespace LCSA.SGI.WebLogisticaUtiles.Bussness
{
    public class BTablas
    {
        DTablas objData = new DTablas();

        public DataTable Query(string Sql)
        {
            return objData.Query(Sql);
        }

        public int InUpDelTablas(string SQL)
        {
            return objData.DInUpDelTablas(SQL);
        }
    }
}

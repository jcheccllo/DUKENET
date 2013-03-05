using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LCSA.SGI.WebLogisticaUtiles.Entity;
using LCSA.SGI.WebLogisticaUtiles.Data;

namespace LCSA.SGI.WebLogisticaUtiles.Bussness
{
    public class BTransaccion
    {
        DTransaccion objTran = new DTransaccion();

        public int BInsertCabReq(EReqCabecera eReqCab, string tabla)
        {
            return objTran.DInsertCabReq(eReqCab, tabla);
        }

        public int BInsertDetReq(EReqDetalle eReqDet, string tabla)
        {
            return objTran.DInsertDetReq(eReqDet, tabla);
        }
    }
}

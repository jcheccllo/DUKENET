using System;
using System.Data;
using cwbx;
using IBM.Data.DB2.iSeries;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LCSA.SGI.WebLogisticaUtiles.Entity;

namespace LCSA.SGI.WebLogisticaUtiles.Data
{
    public class DTransaccion
    {
        ConexionAS400 objCn = new ConexionAS400();

        public int DInsertCabReq(EReqCabecera eReqCab, string tabla)
        {
            int i = 0;
            try
            {
                iDB2Command cmd = new iDB2Command();
                cmd.CommandType = CommandType.Text;
                string sql = "INSERT INTO " + tabla + " ( " +
" A11STT, A11NSA, A11TSA, A11FSA, A11TUR, " +
" A11ARE, A11AUT, A11SOL, A11OTR, A11COR, " +
" A11TIP, A11IMS, A11IMD, A11UGE, A11UA1, " +
" A11UA2, A11UA3, A11FGE, A11FA1, A11FA2, " +
" A11FA3, A11UHM, A11EST, A11NVS, A11FVS, " +
" A11HVS, A11UDE, A11CGE, A11CA1, A11CA2, A11CA3) " +
" VALUES " +
" ('" + eReqCab.Situacion + "', '" + eReqCab.NroRequerimiento + "', " + eReqCab.TipoSalida + ", " + eReqCab.FechaSalida + ", " + eReqCab.Turno + ", " +
" " + eReqCab.Area + ", " + eReqCab.Autorizado + ", " + eReqCab.Solicitante + ", " + eReqCab.OrdenTrabajo + ", " + eReqCab.Recibido + ", " +
" '" + eReqCab.TipoAlmacen + "', " + eReqCab.ImpSoles + ", " + eReqCab.ImpDolares + ", '" + eReqCab.UserGenera + "', '" + eReqCab.UserAprueba1 + "', " +
" '" + eReqCab.UserAprueba2 + "', '" + eReqCab.UserAprueba3 + "', '" + eReqCab.FechaGenera + "', '" + eReqCab.FechaAprueba1 + "', '" + eReqCab.FechaAprueba2 + "', " +
" '" + eReqCab.FechaAprueba3 + "', " + eReqCab.HoraMinuto + ", '" + eReqCab.Estado + "', " + eReqCab.NroValeSalida + ", " + eReqCab.FechaValeSalida + ", " +
" " + eReqCab.HoraValeSalida + ", '" + eReqCab.UsuarioDespacha + "'," + eReqCab.CodUserGenera + "," + eReqCab.CodUserAprueba1 + "," + eReqCab.CodUserAprueba2 + "," + eReqCab.CodUserAprueba3 + ") ";
                cmd.CommandText = sql;
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
        public int DInsertDetReq(EReqDetalle eReqDet, string tabla)
        {
            int i = 0;
            try
            {
                iDB2Command cmd = new iDB2Command();
                cmd.CommandType = CommandType.Text;
                string sql = "INSERT INTO " + tabla + " " +
" (A12STT, A12NSA, A12NIT, A12COD, A12CCA, " +
" A12PRO, A12CTA, A12CAS, A12CAD, A12IMP, " +
" A12IMD, A12EST, A12NVS, A12FVS, A12HVS, A12UDE) " +
" VALUES " +
" ('" + eReqDet.Situacion + "', '" + eReqDet.NroReqSalida + "', " + eReqDet.NroItem + ", '" + eReqDet.CodMatPrima + "', " + eReqDet.CtaCargo + ", " +
" " + eReqDet.Procedencia + ", " + eReqDet.CtaAlmacen + ", " + eReqDet.CantidadSoli + ", " + eReqDet.CantidadAte + ", " + eReqDet.ImpSoles + ", " +
" " + eReqDet.ImpDolares + ", '" + eReqDet.Estado + "', " + eReqDet.NroValeSalida + ", " + eReqDet.FechaSalida + ", " + eReqDet.HoraSalida + ", '" + eReqDet.UserDespacha + "')";
                cmd.CommandText = sql;
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

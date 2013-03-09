using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LCSA.SGI.WebLogisticaUtiles.Bussness;
using System.Data;


namespace LCSA.SGI.WebLogisticaUtiles.Presentacion.Utiles.Transaccion
{
    public partial class WebConsultaConsumos : System.Web.UI.Page
    {

        BTablas objTablas = new BTablas();
        string SQL = "";
        DataTable dtReq = new DataTable();
        DataTable tbldetalle = new DataTable();

        void LlenarGrilla()
        {
            SQL = "SELECT " +
 " A11NSA,A11FSA, " +
 " CASE WHEN (A11TUR = '1') THEN '1er Turno' " +
 " WHEN (A11TUR = '2') THEN '2do Turno' " +
 " ELSE '3er Turno' END A11TUR, " +
 " CASE WHEN A11OTR IN (0,99) THEN U.T01AL1 ELSE CC.T01AL1 END AS T01AL1,CC.ODTDES, " +
 " IFNULL(CASE WHEN (A11STT || ' - ' ||A11EST) IN('S - D','J - D','G - D') THEN 'X Generar' " +
 " WHEN (A11STT || ' - ' ||A11EST) IN('S - SP') THEN 'Generado Parcial' " +
 " WHEN (A11STT || ' - ' ||A11EST) IN('S - 1') THEN 'x Firma' " +
 " WHEN (A11STT || ' - ' ||A11EST) IN('S - 2') THEN 'x Firma Jef.' " +
 " WHEN (A11STT || ' - ' ||A11EST) IN('S - 3') THEN 'x Firma Ger.' " +
 " WHEN (A11STT || ' - ' ||A11EST) IN('S - S') THEN 'Generado' ELSE 'Eliminado' " +
 " END,'') ESTADO " +
 " FROM ALI011UTIL AS A11 LEFT OUTER JOIN " +
 " (SELECT ODTSTT, CAST(ODTCOD AS CHAR(3)) AS ODTCOD,CAST(ODTDPT AS CHAR(5)) AS ODTDPT,ODTDES, ifnull(T01AL1,'') AS T01AL1 " +
 " FROM AIODET LEFT JOIN UGT01 ON (DIGITS(ODTDPT) = T01ESP AND T01IDT='CCT')) AS CC ON A11.A11OTR=CC.ODTCOD " +
 " LEFT OUTER JOIN (SELECT T01ESP,T01AL1 FROM UGT01 WHERE T01IDT='CCT') AS U ON DIGITS(A11.A11ARE)=U.T01ESP " +
 " WHERE A11SOL=" + Convert.ToDecimal((string)(Session["CodPlanilla"])) + " " +
 " ORDER BY A11FSA DESC";
            objTablas = new BTablas();
            dtReq = objTablas.Query(SQL);
            dgvRequrimientos.DataSource = dtReq;
            dgvRequrimientos.DataBind();
        }

        void FormatoGrilla()
        {
            tbldetalle = new DataTable("tabll1");
            tbldetalle.Columns.Add(new DataColumn("codProd", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("desProd", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("PrecioS", typeof(decimal)));
            tbldetalle.Columns.Add(new DataColumn("PrecioD", typeof(decimal)));
            tbldetalle.Columns.Add(new DataColumn("Cantidad", typeof(decimal)));
            tbldetalle.Columns.Add(new DataColumn("UndMeda", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("TotalS", typeof(decimal)));
            tbldetalle.Columns.Add(new DataColumn("TotalD", typeof(decimal)));
            tbldetalle.Columns.Add(new DataColumn("stockD", typeof(decimal)));
            tbldetalle.Columns.Add(new DataColumn("stockC", typeof(decimal)));
            tbldetalle.Columns.Add(new DataColumn("vCuentaCargo", typeof(decimal)));
            tbldetalle.Columns.Add(new DataColumn("vCtaAlmacen", typeof(decimal)));
            tbldetalle.Columns.Add(new DataColumn("vProcedencia", typeof(decimal)));
            tbldetalle.PrimaryKey = new DataColumn[] { tbldetalle.Columns[0] };
            Session["CARRITO"] = tbldetalle;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FormatoGrilla();
                Session["OTR"] = "";
                Session["ART"] = "";
                LlenarGrilla();
            }
        }

        protected void dgvRequrimientos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvRequrimientos.PageIndex = e.NewPageIndex;
            LlenarGrilla();
        }


    }
}
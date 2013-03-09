using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using LCSA.SGI.WebLogisticaUtiles.Bussness;
using System.Globalization;

namespace LCSA.SGI.WebLogisticaUtiles.Presentacion.Utiles.Transaccion
{
    public partial class WebConsultaSolicitudUtiles : System.Web.UI.Page
    {
        public string A11NSA = string.Empty;
        string SQL = "";
        BTablas objTab = new BTablas();
        DataTable dtRequerimiento = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                A11NSA = Request.QueryString["A11NSA"];
                SQL = "SELECT  " +
 "ltrim(rtrim(A12COD)) as A12COD,ltrim(rtrim(MPMDES)) as MPMDES,A12CAS,ltrim(rtrim(M.T01AL1)) as T01AL1,A12CAD,A12IMP,A12IMD,A12PRO,A12CTA,A12CCA,MPMSCO,MPMSDI,MPMUBI,MPMCPR,MPMCDO, " +
 "CASE WHEN A11OTR IN (0,99) THEN U.T01AL1 ELSE CC.T01AL1 END AS AREA,CC.ODTDES,A11EST,A11STT, (SELECT top 1 TRANOM FROM V_TRABAJ WHERE TRACVE=A11SOL ) AS NOMBRE  " +
 "FROM ALI012UTIL LEFT OUTER JOIN " +
 "ALMMMAP ON (A12COD=MPMCOD AND A12CTA=MPMCTA AND A12PRO=MPMPRO AND A12CCA=MPMCCA) LEFT OUTER JOIN " +
 "(SELECT T01ESP,T01AL1,T01AL2,T01NU2 FROM UGT01 WHERE T01IDT='UND' AND T01NU2=1) AS M ON SUBSTRING(CONVERT(VARCHAR(3),MPMUNI),2,2)=M.T01ESP " +
 "LEFT OUTER JOIN ALI011UTIL AS A11 ON A12NSA=A11NSA  LEFT OUTER JOIN " +
 "(SELECT ODTSTT, CAST(ODTCOD AS CHAR(3)) AS ODTCOD,CAST(ODTDPT AS CHAR(5)) AS ODTDPT,ODTDES, ISNULL(T01AL1,'') AS T01AL1 " +
 "FROM AIODET LEFT JOIN UGT01 ON (CONVERT(VARCHAR(5),ODTDPT) = T01ESP AND T01IDT='CCT')) AS CC ON A11.A11OTR=CC.ODTCOD " +
 "LEFT OUTER JOIN (SELECT T01ESP,T01AL1 FROM UGT01 WHERE T01IDT='CCT') AS U ON CONVERT(VARCHAR(5),A11.A11ARE)=U.T01ESP " +
 "WHERE MPMSTT IN ('M','O')  AND A12NSA= '" + A11NSA.Trim() + "'";
                objTab = new BTablas();
                dtRequerimiento = objTab.Query(SQL);
                txtArea.Text = dtRequerimiento.Rows[0]["AREA"].ToString();
                txtOtr.Text = dtRequerimiento.Rows[0]["ODTDES"].ToString();
                txtUsu1.Text = dtRequerimiento.Rows[0]["NOMBRE"].ToString();
                Label1.Text = "Requerimiento  : " + A11NSA;



                if (((string)(Session["Condiciones"]) != "'N'") && dtRequerimiento.Rows[0]["A11EST"].ToString().Trim() == "1" && dtRequerimiento.Rows[0]["A11STT"].ToString().Trim() == "S")
                {
                    btnAprobar.Visible = true;
                    btnDesaprueba.Visible = true;
                }
                else
                {
                    btnAprobar.Visible = false;
                    btnDesaprueba.Visible = false;
                }

                
                dgvRequrimientos.DataSource = dtRequerimiento;
                dgvRequrimientos.DataBind();
            }
        }


        protected void btnAprobar_PreRender(object sender, EventArgs e)
        {
            btnAprobar.OnClientClick = "return confirm('¿Desea Aprobar Requerimiento?')";
        }


        void Mensaje(string sAviso)
        {
            if (sAviso.Trim().Length > 0)
            {
                string s = "<script language='JavaScript'>alert('" + sAviso + "');window.opener.location=window.opener.location; window.close();</script>";
                ClientScript.RegisterStartupScript(typeof(Page), "", s);
            }
        }


        DateTime FechaSis = DateTime.Now;
        string fecha = "";
        string Hora = "";
        string DIASEMANA = "";

        protected void btnAprobar_Click(object sender, ImageClickEventArgs e)
        {
            A11NSA = Request.QueryString["A11NSA"];
            FechaSis = DateTime.Now;
            CultureInfo ci = new CultureInfo("Es-Es");
            DIASEMANA = (ci.DateTimeFormat.GetDayName(FechaSis.DayOfWeek)).Substring(0, 1);
            fecha = FechaSis.ToShortDateString().Substring(6, 4) + FechaSis.ToShortDateString().Substring(3, 2) + FechaSis.ToShortDateString().Substring(0, 2);
            if (Convert.ToDecimal(FechaSis.Minute.ToString()) <= 9) { Hora = FechaSis.Hour.ToString() + "0" + FechaSis.Minute.ToString(); }
            else { Hora = FechaSis.Hour.ToString() + FechaSis.Minute.ToString(); }
            int h = objTab.InUpDelTablas("UPDATE ALI011UTIL SET A11CA1 = '" + Convert.ToDecimal((string)(Session["CodPlanilla"])) + "', A11UA1 = '" + (string)(Session["Usuario"]).ToString().Trim() + "',A11FA1 = '" + fecha + "',A11UH1=" + Convert.ToDecimal(Hora) + ",A11AUT = '" + Convert.ToDecimal((string)(Session["CodPlanilla"])) + "',A11EST='D' WHERE A11NSA= '" + A11NSA.Trim() + "'");
            Mensaje("Requerimiento " + A11NSA.Trim().ToString() + " ha sido Aprobado");

            Response.Redirect("~/Utiles/Transaccion/WebAprobacionReqUtiles.aspx");
        }

        protected void btnDesaprueba_PreRender(object sender, EventArgs e)
        {
            btnDesaprueba.OnClientClick = "return confirm('¿Desea Desaprobar Requerimiento?')";
        }


        protected void btnDesaprueba_Click(object sender, ImageClickEventArgs e)
        {
            A11NSA = Request.QueryString["A11NSA"];
            FechaSis = DateTime.Now;
            CultureInfo ci = new CultureInfo("Es-Es");
            DIASEMANA = (ci.DateTimeFormat.GetDayName(FechaSis.DayOfWeek)).Substring(0, 1);
            fecha = FechaSis.ToShortDateString().Substring(6, 4) + FechaSis.ToShortDateString().Substring(3, 2) + FechaSis.ToShortDateString().Substring(0, 2);
            if (Convert.ToDecimal(FechaSis.Minute.ToString()) <= 9) { Hora = FechaSis.Hour.ToString() + "0" + FechaSis.Minute.ToString(); }
            else { Hora = FechaSis.Hour.ToString() + FechaSis.Minute.ToString(); }
            int h = objTab.InUpDelTablas("UPDATE ALI011UTIL SET A11CA1 = '" + Convert.ToDecimal((string)(Session["CodPlanilla"])) + "', A11UA1 = '" + (string)(Session["Usuario"]).ToString().Trim() + "',A11FA1 = '" + fecha + "',A11UH1=" + Convert.ToDecimal(Hora) + ",A11AUT = '" + Convert.ToDecimal((string)(Session["CodPlanilla"])) + "',A11STT='E' WHERE A11NSA= '" + A11NSA.Trim() + "'");
            Mensaje("Requerimiento " + A11NSA.Trim().ToString() + " ha sido Desaprobado");

            Response.Redirect("~/Utiles/Transaccion/WebAprobacionReqUtiles.aspx");
        }

        

        
    }
}

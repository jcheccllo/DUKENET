using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using LCSA.SGI.WebLogisticaUtiles.Bussness;

namespace LCSA.SGI.WebLogisticaUtiles.Presentacion.Utiles.Transaccion
{
    public partial class WebBusquedaGral : System.Web.UI.Page
    {
        BTablas objTab = new BTablas();
        DataTable dtOtr = new DataTable();
        string SQL = "";
        DataView dv = new DataView();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                objTab = new BTablas();
                SQL = "SELECT CAST(ODTCOD AS CHAR(3)) AS ODTCOD,CAST(ODTDPT AS CHAR(5)) AS ODTDPT,ODTDES, ifnull(T01AL1,'') AS T01AL1 " +
                      " FROM LALMINGB.AIODET LEFT JOIN LUGTF.UGT01 ON (DIGITS(ODTDPT) = T01ESP AND T01IDT='CCT') WHERE odtdpt=0 ORDER BY ODTCOD";
                dtOtr = objTab.Query(SQL);
                dgvConsulta.DataSource = dtOtr;
                dgvConsulta.DataBind();
                Session["DTOTR"] = dtOtr;
            }
        }

        protected void dgvConsulta_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvConsulta.PageIndex = e.NewPageIndex;
            dtOtr = (DataTable)Session["DTOTR"];
            dgvConsulta.DataSource = dtOtr;
            dgvConsulta.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string expresion = "<script language='JavaScript'> window.opener.location='WebNewSolicitudUtiles.aspx';window.close();</script>";            
            string expresion = "<script language='JavaScript'>window.opener.location=window.opener.location; window.close()</script>";
            ClientScript.RegisterStartupScript(typeof(Page), "", expresion);
            //ClientScript.Attributes.Add("OnClick", "window.opener.location.reload(); window.close()");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            dtOtr = (DataTable)Session["DTOTR"];
            int cb = DropDownList1.SelectedIndex;
            switch (cb)
            {
                case 0:
                    dv = new DataView(dtOtr, "ODTCOD LIKE '%" + txtBusqueda.Text.ToString().Trim() + "%'", "ODTCOD DESC", DataViewRowState.OriginalRows);
                    break;
                case 1:
                    dv = new DataView(dtOtr, "ODTDES LIKE '%" + txtBusqueda.Text.ToString().Trim() + "%'", "ODTDES DESC", DataViewRowState.OriginalRows);
                    break;
            }
            dgvConsulta.DataSource = dv;
            dgvConsulta.DataBind();  
        }

        protected void dgvConsulta_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Aprobar":
                    Session["OTR"] = e.CommandArgument.ToString();
                    string expresion = "<script language='JavaScript'>window.opener.location=window.opener.location; window.close()</script>";
                    ClientScript.RegisterStartupScript(typeof(Page), "", expresion);
                    break;
            }  
        }

        protected void dgvConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

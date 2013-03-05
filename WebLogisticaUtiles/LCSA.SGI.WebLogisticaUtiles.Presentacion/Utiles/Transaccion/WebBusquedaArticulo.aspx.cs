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
    public partial class WebBusquedaArticulo : System.Web.UI.Page
    {
        BTablas objTab = new BTablas();
        DataTable dtArt = new DataTable();

        DataTable dtComboTipoArt = new DataTable();

        string SQL = "";
        DataView dv = new DataView();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                objTab = new BTablas();
                dtComboTipoArt = objTab.Query("SELECT MPTARG,MPTDES FROM LALMACEB.ALMTALM WHERE MPTTAB = 'CAI' AND MPTARG IN (10,11,12,13)");
                cboTipoArt.DataSource = dtComboTipoArt;
                cboTipoArt.DataTextField = "MPTDES";
                cboTipoArt.DataValueField = "MPTARG";
                cboTipoArt.DataBind();

                objTab = new BTablas();
                SQL = "SELECT MPMCOD,MPMDES, " +
                      "TRIM(T01AL1) AS T01AL1,MPMSCO,MPMSDI,MPMCPR, " +
                      "MPMCDO,MPMUBI,MPMCCA,MPMPRO,MPMCTA " +
                      "FROM LALMINGB.ALMMMAP LEFT OUTER JOIN " +
                      "(SELECT T01ESP,T01AL1,T01AL2,T01NU2 FROM LUGTF.UGT01 WHERE T01IDT='UND' AND T01NU2=1) AS M ON SUBSTR(DIGITS(MPMUNI),2,2)=M.T01ESP " +
                      "WHERE MPMCTA IN (10,11,12,13) AND MPMSTT IN ('M','O')";
                dtArt = objTab.Query(SQL);
                dgvConsulta.DataSource = dtArt;
                dgvConsulta.DataBind();
                Session["DTART"] = dtArt;
                dv = new DataView(dtArt);
                Session["DVIEW"] = dv;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            dtArt = (DataTable)Session["DTART"];
            int cb = DropDownList1.SelectedIndex;
            switch (cb)
            {
                case 0:
                    dv = new DataView(dtArt, "MPMCOD LIKE '%" + txtBusqueda.Text.ToString().Trim() + "%'", "MPMCOD DESC", DataViewRowState.OriginalRows);
                    break;
                case 1:
                    dv = new DataView(dtArt, "MPMDES LIKE '%" + txtBusqueda.Text.ToString().Trim() + "%'", "MPMDES DESC", DataViewRowState.OriginalRows);
                    break;
            }
            Session["DVIEW"] = dv;
            dgvConsulta.DataSource = dv;
            dgvConsulta.DataBind();
        }

        protected void dgvConsulta_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvConsulta.PageIndex = e.NewPageIndex;
            dv = (DataView)Session["DVIEW"];
            dgvConsulta.DataSource = dv;
            dgvConsulta.DataBind();
        }

        protected void dgvConsulta_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Aprobar":
                    Session["ART"] = e.CommandArgument.ToString();
                    string expresion = "<script language='JavaScript'>window.opener.location=window.opener.location; window.close()</script>";
                    ClientScript.RegisterStartupScript(typeof(Page), "", expresion);
                    break;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string expresion = "<script language='JavaScript'>window.opener.location=window.opener.location; window.close()</script>";
            ClientScript.RegisterStartupScript(typeof(Page), "", expresion);
        }

        protected void cboTipoArt_SelectedIndexChanged(object sender, EventArgs e)
        {
            objTab = new BTablas();
            SQL = "SELECT MPMCOD,MPMDES, " +
                  "TRIM(T01AL1) AS T01AL1,MPMSCO,MPMSDI,MPMCPR, " +
                  "MPMCDO,MPMUBI,MPMCCA,MPMPRO,MPMCTA " +
                  "FROM LALMINGB.ALMMMAP LEFT OUTER JOIN " +
                  "(SELECT T01ESP,T01AL1,T01AL2,T01NU2 FROM LUGTF.UGT01 WHERE T01IDT='UND' AND T01NU2=1) AS M ON SUBSTR(DIGITS(MPMUNI),2,2)=M.T01ESP " +
                  "WHERE MPMCTA='" + cboTipoArt.SelectedValue.Trim().ToString() + "' AND MPMSTT IN ('M','O')";
            dtArt = objTab.Query(SQL);
            dgvConsulta.DataSource = dtArt;
            dgvConsulta.DataBind();
            Session["DTART"] = dtArt;
            dv = new DataView(dtArt);
            Session["DVIEW"] = dv;
        }
    }
}

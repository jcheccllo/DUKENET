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
namespace LCSA.SGI.WebLogisticaUtiles.Presentacion.Utiles.Sistema
{
    public partial class WebCambioContrasenaUtil : System.Web.UI.Page
    {
        TextBox mpTextBox = new TextBox();
        BTablas objTablas = new BTablas();
        string SQL = "";
        DataTable dtPruebaUsuarios = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblVerificacion.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            lblVerificacion.Visible = false;
            SQL = "SELECT * FROM ALIUSERS WHERE CODUSE='" + (string)(Session["Usuario"]).ToString().Trim() + "' AND CODPWD='" + txtPWDAnterior.Text.ToUpper().Trim() + "'";
            objTablas = new BTablas();
            dtPruebaUsuarios = objTablas.Query(SQL);
            if (dtPruebaUsuarios.Rows.Count > 0)
            {
                lblVerificacion.Visible = true;
                SQL = "UPDATE ALIUSERS SET CODPWD = '" + txtPWDNuevo.Text.ToUpper().Trim() + "' WHERE CODUSE='" + (string)(Session["Usuario"]).ToString().Trim() + "' AND CODPWD='" + txtPWDAnterior.Text.ToUpper().Trim() + "'";
                objTablas = new BTablas();
                int i = objTablas.InUpDelTablas(SQL);
                if (i == 1)
                {
                    txtPWDAnterior.Text = "";
                    txtPWDConfirmacion.Text = "";
                    txtPWDNuevo.Text = "";
                    Response.Redirect("~/WebMenuPrincipal.aspx");
                }
                else
                {
                    lblVerificacion.Text = "No se pudo actualizar contraseña";
                }
            }
            else
            {
                lblVerificacion.Visible = true;
                lblVerificacion.Text = "Contraseña Anterior Incorrecta";
            }
        }
    }
}

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

namespace LCSA.SGI.WebLogisticaUtiles.Presentacion
{
    public partial class WebLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    Validate();
            lblMensaje.Visible = false;
            //}
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            BTablas objTablas = new BTablas();
            DataTable dtPruebaUsuarios = new DataTable();
            DataTable dtPermisosUsuarios = new DataTable();
            string SQL = "";

            if (Login1.UserName != "")
            {
                lblMensaje.Visible = false;
                //SQL = "SELECT CODUSE,TRANOM AS NOMEMP,CODEMP,DATCVE AS R99PUE,DATDES AS R99NPU,T01NU3 AS GERENCIA FROM LALMINGB.ALIUSERS LEFT OUTER JOIN " +
                //      " adamperuv2.v_trabaj ON CODEMP=CAST(TRACVE AS DECIMAL(4,0)) LEFT OUTER JOIN " +
                //      " LUGTF.UGT01 ON (T01IDT='CCT' AND DATCVE = T01ESP)    WHERE CODUSE='" + Login1.UserName.ToUpper().Trim() + "' AND CODPWD='" + Login1.Password.ToUpper().Trim() + "'";

                SQL = "SELECT CODUSE,TRANOM AS NOMEMP,CODEMP, " +
                        " CASE WHEN IFNULL(IDOARE,'N')='N' THEN DATCVE ELSE IDOARE END AS R99PUE, " +
                        " CASE WHEN IFNULL(IDOARE,'N')='N' THEN DATDES ELSE (SELECT T01AL1 FROM LUGTF.UGT01 WHERE T01IDT='CCT' AND T01ESP=IDOARE) END AS R99NPU, " +
                        " T01NU3 AS GERENCIA " +
                        " FROM LALMINGB.ALIUSERS LEFT OUTER JOIN " +
                        " adamperuv2.v_trabaj ON CODEMP=CAST(TRACVE AS DECIMAL(4,0)) LEFT OUTER JOIN " +
                        " LUGTF.UGT01 ON (T01IDT='CCT' AND DATCVE = T01ESP)  LEFT OUTER JOIN " +
                        " LALMINGB.WEBING80 ON (codemp=IDOCOD)  " +
                        " WHERE CODUSE='" + Login1.UserName.ToUpper().Trim() + "' AND CODPWD='" + Login1.Password.ToUpper().Trim() + "'";


                objTablas = new BTablas();
                dtPruebaUsuarios = objTablas.Query(SQL);
                if (dtPruebaUsuarios.Rows.Count > 0)
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "Ingreso Correcto " + dtPruebaUsuarios.Rows[0]["NOMEMP"].ToString();
                    Session["Usuario"] = dtPruebaUsuarios.Rows[0]["CODUSE"].ToString();
                    Session["NombreUsu"] = dtPruebaUsuarios.Rows[0]["NOMEMP"].ToString();
                    Session["CodPlanilla"] = dtPruebaUsuarios.Rows[0]["CODEMP"].ToString();
                    Session["CodPuesto"] = dtPruebaUsuarios.Rows[0]["R99PUE"].ToString();
                    Session["Puesto"] = dtPruebaUsuarios.Rows[0]["R99NPU"].ToString();
                    Session["Gerencia"] = dtPruebaUsuarios.Rows[0]["GERENCIA"].ToString();
                    Session["indiceOpcion"] = "WUTIL";
                    SQL = "SELECT A15GER FROM LALMINGB.ALI015UTIL WHERE A15USU='" + Login1.UserName.ToUpper().Trim() + "'";
                    objTablas = new BTablas();
                    dtPermisosUsuarios = objTablas.Query(SQL);

                    string condiciones = "'N'";
                    if (dtPermisosUsuarios.Rows.Count > 0)
                    {
                        for (int i = 0; i <= dtPermisosUsuarios.Rows.Count - 1; i++)
                        {
                            if (i == 0)
                            {
                                condiciones = "'" + dtPermisosUsuarios.Rows[i]["A15GER"].ToString().Trim() + "'";
                            }
                            else
                            {
                                condiciones =condiciones + "," + "'" + dtPermisosUsuarios.Rows[i]["A15GER"].ToString().Trim() + "'";
                            }
                        }
                    }
                    Session["Condiciones"] = condiciones;

                    Response.Redirect("~/WebMenuPrincipal.aspx");
                }
                else
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "Usuario no tiene Acceso";
                }
            }
            else
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "Ingrese Usuario y Contraseña";
            }
        }
    }
}

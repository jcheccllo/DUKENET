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

namespace LCSA.SGI.WebLogisticaUtiles.Presentacion.MasterPage
{
    public partial class AppMenu : System.Web.UI.MasterPage
    {
        BTablas objTablas = new BTablas();
        DataTable dtOpcionesPrincipales = new DataTable();
        String SQL = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblTitle.Text = "Modulo de Utiles";
                switch (HttpContext.Current.Request.Url.LocalPath.ToString())
                {
                    case "/Utiles/Utiles/Sistemas/WebCambioContrasenaUtil.aspx":
                        lblTitle.Text = "Cambio de Contraseña";
                        break;
                    case "/Utiles/Utiles/Sistemas/WebConfiguracionUtil.aspx":
                        lblTitle.Text = "Configuracion de Perfiles";
                        break;
                    case "/Utiles/Utiles/Transaccion/WebSolicitudUtiles.aspx":
                        lblTitle.Text = "Solicitud de Utiles";
                        break;
                    case "/Utiles/Utiles/Transaccion/WebAprobacionReqUtiles.aspx":
                        lblTitle.Text = "Aprobacion de Req.Utiles";
                        break;
                    case "/Utiles/Utiles/Transaccion/WebConsultaSolicitudUtiles.aspx":
                        lblTitle.Text = "Consulta de Requisiciones";
                        break;
                    case "/Utiles/Utiles/Transaccion/WebConsultaConsumos.aspx":
                        lblTitle.Text = "Consulta de Requisiciones";
                        break;
                    default:
                        lblTitle.Text = "Modulo de Utiles";
                        break;
                }
                if ((string)(Session["NombreUsu"]) == null || (string)(Session["NombreUsu"]) == "") { Response.Redirect("/WebLogin.aspx"); }
                else { lblUsuario.Text = (string)(Session["NombreUsu"]); }

                //ColocaR USUARIO NO OLVIDAR
                objTablas = new BTablas();
                SQL = "SELECT * FROM WEBING71 WHERE IDAPLI='WEBLO'";
                dtOpcionesPrincipales = objTablas.Query(SQL);
                if (dtOpcionesPrincipales.Rows.Count > 0)
                {
                    MenuItem menuW = new MenuItem();
                    for (int i = 0; i <= dtOpcionesPrincipales.Rows.Count - 1; i++)
                    {
                        menuW = new MenuItem();
                        menuW.Value = dtOpcionesPrincipales.Rows[i]["IDOPCI"].ToString().Trim();
                        menuW.Text = dtOpcionesPrincipales.Rows[i]["IDDESW"].ToString().Trim();
                        MenuPrincipal.Items.Add(menuW);
                    }
                }
                DataTable dtDataTable = null;
                switch ((string)(Session["indiceOpcion"]).ToString().Trim())
                {
                    case "WUTIL":
                        dtDataTable = null;
                        dtDataTable = objTablas.Query("SELECT * FROM WEBING72 WHERE IDOPCI='WUTIL' AND IDOUSU='" + (string)(Session["Usuario"]).ToString().Trim() + "' ORDER BY IDOPCH");
                        MyMenu.Items.Clear();
                        if (dtDataTable != null && dtDataTable.Rows.Count > 0)
                        {
                            foreach (DataRow drDataRow in dtDataTable.Rows)
                            {
                                if (Convert.ToInt32(drDataRow["IDOPCH"]) == Convert.ToInt32(drDataRow["IDOPAR"]))
                                {
                                    MenuItem miMenuItem = new MenuItem(Convert.ToString(drDataRow["IDODES"]), Convert.ToString(drDataRow["IDOPCH"]), String.Empty, Convert.ToString(drDataRow["IDOURL"]));
                                    this.MyMenu.Items.Add(miMenuItem);
                                    AddChildItem(ref miMenuItem, dtDataTable);
                                }
                            }
                        }
                        break;
                    case "WARCH":
                        dtDataTable = null;
                        dtDataTable = objTablas.Query("SELECT * FROM WEBING72 WHERE IDOPCI='WARCH' AND IDOUSU='" + (string)(Session["Usuario"]).ToString().Trim() + "' ORDER BY IDOPCH");
                        MyMenu.Items.Clear();
                        if (dtDataTable != null && dtDataTable.Rows.Count > 0)
                        {
                            foreach (DataRow drDataRow in dtDataTable.Rows)
                            {
                                if (Convert.ToInt32(drDataRow["IDOPCH"]) == Convert.ToInt32(drDataRow["IDOPAR"]))
                                {
                                    MenuItem miMenuItem = new MenuItem(Convert.ToString(drDataRow["IDODES"]), Convert.ToString(drDataRow["IDOPCH"]), String.Empty, Convert.ToString(drDataRow["IDOURL"]));
                                    this.MyMenu.Items.Add(miMenuItem);
                                    AddChildItem(ref miMenuItem, dtDataTable);
                                }
                            }
                        }
                        break;
                }
            }
        }

        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Session.Abandon();
        }

        protected void MenuPrincipal_MenuItemClick(object sender, MenuEventArgs e)
        {

            Session["indiceOpcion"] = e.Item.Value.ToString();
            DataTable dtDataTable = null;
            switch (e.Item.Value.ToString())
            {
                case "WUTIL":
                    dtDataTable = null;
                    dtDataTable = objTablas.Query("SELECT * FROM WEBING72 WHERE IDOPCI='WUTIL' AND IDOUSU='" + (string)(Session["Usuario"]).ToString().Trim() + "' ORDER BY IDOPCH");
                    MyMenu.Items.Clear();

                    if (dtDataTable != null && dtDataTable.Rows.Count > 0)
                    {
                        foreach (DataRow drDataRow in dtDataTable.Rows)
                        {
                            if (Convert.ToInt32(drDataRow["IDOPCH"]) == Convert.ToInt32(drDataRow["IDOPAR"]))
                            {
                                MenuItem miMenuItem = new MenuItem(Convert.ToString(drDataRow["IDODES"]), Convert.ToString(drDataRow["IDOPCH"]), String.Empty, Convert.ToString(drDataRow["IDOURL"]));
                                this.MyMenu.Items.Add(miMenuItem);
                                AddChildItem(ref miMenuItem, dtDataTable);
                            }
                        }
                    }
                    break;
                case "WARCH":
                    dtDataTable = null;
                    dtDataTable = objTablas.Query("SELECT * FROM WEBING72 WHERE IDOPCI='WARCH' AND IDOUSU='" + (string)(Session["Usuario"]).ToString().Trim() + "' ORDER BY IDOPCH");
                    MyMenu.Items.Clear();

                    if (dtDataTable != null && dtDataTable.Rows.Count > 0)
                    {
                        foreach (DataRow drDataRow in dtDataTable.Rows)
                        {
                            if (Convert.ToInt32(drDataRow["IDOPCH"]) == Convert.ToInt32(drDataRow["IDOPAR"]))
                            {
                                MenuItem miMenuItem = new MenuItem(Convert.ToString(drDataRow["IDODES"]), Convert.ToString(drDataRow["IDOPCH"]), String.Empty, Convert.ToString(drDataRow["IDOURL"]));
                                this.MyMenu.Items.Add(miMenuItem);
                                AddChildItem(ref miMenuItem, dtDataTable);
                            }
                        }
                    }
                    break;
            }
            Response.Redirect("~/WebMenuPrincipal.aspx");
        }

        protected void AddChildItem(ref MenuItem miMenuItem, DataTable dtDataTable)
        {
            foreach (DataRow drDataRow in dtDataTable.Rows)
            {
                if (Convert.ToInt32(drDataRow["IDOPAR"]) == Convert.ToInt32(miMenuItem.Value) && Convert.ToInt32(drDataRow["IDOPCH"]) != Convert.ToInt32(drDataRow["IDOPAR"]))
                {
                    MenuItem miMenuItemChild = new MenuItem(Convert.ToString(drDataRow["IDODES"]), Convert.ToString(drDataRow["IDOPCH"]), String.Empty, Convert.ToString(drDataRow["IDOURL"]));
                    miMenuItem.ChildItems.Add(miMenuItemChild);
                    AddChildItem(ref miMenuItemChild, dtDataTable);
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebLogin.aspx");
        }
    }
}

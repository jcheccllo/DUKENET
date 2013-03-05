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

namespace LCSA.SGI.WebLogisticaUtiles.Presentacion
{
    public partial class WebMenuPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)(Session["NombreUsu"]) == null || (string)(Session["NombreUsu"]) == "")
            {
                Response.Redirect("/WebLogin.aspx");
            }

            if (!Page.IsPostBack)
            {
                switch ((string)(Session["indiceOpcion"]).ToString().Trim())
                {
                    case "WUTIL":
                        MenuImagenP.ImageUrl = "~/Images/Materiales_oficina.png";
                        break;
                    case "WARCH":
                        MenuImagenP.ImageUrl = "~/Images/LOGO.jpg";
                        break;
                }
            }
        }
    }
}

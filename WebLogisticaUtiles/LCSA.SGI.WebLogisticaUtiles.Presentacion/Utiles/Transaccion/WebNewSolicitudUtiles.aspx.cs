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
using LCSA.SGI.WebLogisticaUtiles.Entity;

namespace LCSA.SGI.WebLogisticaUtiles.Presentacion.Utiles.Transaccion
{
    public partial class WebNewSolicitudUtiles : System.Web.UI.Page
    {
        BTablas objTablas = new BTablas();
        /******Transaccion******************************/
        BTransaccion objTran = new BTransaccion();
        EReqCabecera eCabReq = new EReqCabecera();
        EReqDetalle EDetReq = new EReqDetalle();
        /***********************************************/
        DataTable tbldetalle = new DataTable();
        DataRow dr;
        decimal turno = 0;
        string fecha = "";
        string Hora = "";
        string nroReq = "";
        string Nro = "";
        DateTime FechaSis = DateTime.Now;
        string vCodigoProd = "";
        string vDescripcion = "";
        decimal vStockC = 0;
        decimal vStockD = 0;
        string vUndMed = "";
        decimal vPrecioSoles = 0;
        decimal vPrecioDolares = 0;
        string vUbicacion = "";
        decimal vProcedencia = 0;
        decimal vCtaAlmacen = 0;
        decimal vCuentaCargo = 0;
        static decimal Cantidad = 0;
        static decimal TotalS = 0;
        static decimal TotalD = 0;

        void limpiar()
        {
            Session["ART"] = "";
            txtArticulo.Text = "";
            txtDesArt.Text = "";
            txtCan.Text = "";
            vCodigoProd = "";
            vDescripcion = "";
            vStockC = 0;
            vStockD = 0;
            vUndMed = "";
            vPrecioSoles = 0;
            vPrecioDolares = 0;
            vUbicacion = "";
            vProcedencia = 0;
            vCtaAlmacen = 0;
            vCuentaCargo = 0;

        }
        void CalcularDatarow()
        {
            if (txtCan.Text != "") { Cantidad = Convert.ToDecimal(txtCan.Text); }
            TotalS = Math.Round((Cantidad * vPrecioSoles), 3);
            TotalD = Math.Round((Cantidad * vPrecioDolares), 3);
        }

        string TotalTS = "0";
        string TotalTD = "0";
        private void CalcularTotal()
        {
            try
            {
                tbldetalle = (DataTable)Session["CARRITO"];
                TotalTS = tbldetalle.Compute("sum(TotalS)", "") == null ? "0" : tbldetalle.Compute("sum(TotalS)", "").ToString();
                TotalTD = tbldetalle.Compute("sum(TotalD)", "") == null ? "0" : tbldetalle.Compute("sum(TotalD)", "").ToString();
                txtTotalS.Text = TotalTS;
                txtTotalD.Text = TotalTD;
            }
            catch { throw; }
        }

        void GrabarCabecera()
        {
            eCabReq = new EReqCabecera();
            eCabReq.Situacion = "S";
            eCabReq.NroRequerimiento = nroReq;
            eCabReq.TipoSalida = 1;
            eCabReq.FechaSalida = Convert.ToDecimal(fecha);
            eCabReq.Turno = turno;
            eCabReq.Area = Convert.ToDecimal(txtDpt.Text);
            eCabReq.Autorizado = Convert.ToDecimal((string)Session["CodPlanilla"]);//Convert.ToDecimal(codEmpleado);
            eCabReq.Solicitante = Convert.ToDecimal((string)Session["CodPlanilla"]);
            eCabReq.OrdenTrabajo = Convert.ToDecimal(txtOTR.Text);
            /********Verificarlo************/
            eCabReq.Recibido = 0;
            /**ACTUALIZACION GRABA LA GERENCIA POR CADA USUARIO***/
            eCabReq.TipoAlmacen = (string)Session["Gerencia"];
            /******************************/
            eCabReq.ImpSoles = Convert.ToDecimal(txtTotalS.Text);
            eCabReq.ImpDolares = Convert.ToDecimal(txtTotalD.Text);
            eCabReq.UserGenera = (string)Session["Usuario"];
            /*******************Actualizacion************************/
            eCabReq.CodUserGenera = Convert.ToDecimal((string)Session["CodPlanilla"]);
            eCabReq.CodUserAprueba1 = 0;
            eCabReq.CodUserAprueba2 = 0;
            eCabReq.CodUserAprueba3 = 0;

            eCabReq.UserAprueba1 = "";
            eCabReq.UserAprueba2 = "";
            eCabReq.UserAprueba3 = "";
            /********************************************************/
            eCabReq.FechaGenera = fecha;
            /*******************Actualizacion************************/
            eCabReq.FechaAprueba1 = "";
            eCabReq.FechaAprueba2 = "";
            eCabReq.FechaAprueba3 = "";
            /********************************************************/
            eCabReq.HoraMinuto = Convert.ToDecimal(Hora);
            /*******************Actualizacion************************/
            eCabReq.Estado = "1";
            eCabReq.NroValeSalida = 0;
            eCabReq.FechaValeSalida = 0;
            eCabReq.HoraValeSalida = 0;
            eCabReq.UsuarioDespacha = "";
            /********************************************************/
            objTran = new BTransaccion();
            int i = objTran.BInsertCabReq(eCabReq, "LALMINGB.ALI011UTIL");
        }

        void GrabaDetalle()
        {
            tbldetalle = (DataTable)Session["CARRITO"];
            for (int i = 0; i <= tbldetalle.Rows.Count - 1; i++)
            {
                //dgvDetReq.Rows[i].Cells[1].ToString().Trim();
                EDetReq = new EReqDetalle();
                EDetReq.Situacion = "S";
                EDetReq.NroReqSalida = nroReq;
                EDetReq.NroItem = Convert.ToDecimal(i + 1);
                EDetReq.CodMatPrima = tbldetalle.Rows[i]["codProd"].ToString();
                EDetReq.CtaCargo = Convert.ToDecimal(tbldetalle.Rows[i]["vCuentaCargo"].ToString());
                EDetReq.Procedencia = Convert.ToDecimal(tbldetalle.Rows[i]["vProcedencia"].ToString());
                EDetReq.CtaAlmacen = Convert.ToDecimal(tbldetalle.Rows[i]["vCtaAlmacen"].ToString());
                EDetReq.CantidadSoli = Convert.ToDecimal(tbldetalle.Rows[i]["Cantidad"].ToString());
                /*******************Actualizacion************************/
                EDetReq.CantidadAte = 0;
                /********************************************************/
                EDetReq.ImpSoles = Convert.ToDecimal(tbldetalle.Rows[i]["TotalS"].ToString());
                EDetReq.ImpDolares = Convert.ToDecimal(tbldetalle.Rows[i]["TotalD"].ToString());
                /*******************Actualizacion************************/
                EDetReq.Estado = "1";
                EDetReq.NroValeSalida = 0;
                EDetReq.FechaSalida = 0;
                EDetReq.HoraSalida = 0;
                EDetReq.UserDespacha = "";
                /********************************************************/
                objTran = new BTransaccion();
                int j = objTran.BInsertDetReq(EDetReq, "LALMINGB.ALI012UTIL");
            }
        }
        
        void Mensaje(string sAviso)
        {
            if (sAviso.Trim().Length > 0)
            {
                string s = "<script language='JavaScript'>alert('" + sAviso + "');window.opener.location=window.opener.location; window.close();</script>";
                ClientScript.RegisterStartupScript(typeof(Page), "", s);
            }
        }

        string OTR1 = "";
        string ART1 = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    tbldetalle = (DataTable)Session["CARRITO"];
                    dgvDetReq.DataSource = tbldetalle;
                    dgvDetReq.DataBind();
                    OTR1 = (string)Session["OTR"];
                    if (OTR1.Length > 0)
                    {
                        string[] OTR = OTR1.Split('►');
                        txtOTR.Text = OTR[0].Trim();
                        if (OTR[0].Trim() == "0" || OTR[0].Trim() == "99")
                        {
                            txtDpt.Text = (string)Session["CodPuesto"].ToString().Trim();
                            txtArea.Text = (string)Session["Puesto"].ToString().Trim();
                        }
                        else
                        {
                            txtDpt.Text = OTR[1].Trim();
                            txtArea.Text = OTR[3].Trim();
                        }
                        txtEmpleado.Text = OTR[2].Trim();
                    }
                    else
                    {
                        txtOTR.Text = "0";
                        txtDpt.Text = (string)Session["CodPuesto"].ToString().Trim();
                        txtArea.Text = (string)Session["Puesto"].ToString().Trim();
                        txtEmpleado.Text = "PEDIDOS SIN ORDEN DE TRABAJO (USO GENERAL)";

                    }
                    ART1 = (string)Session["ART"];
                    if (ART1.Length > 0)
                    {
                        string[] ART = ART1.Split('►');
                        txtArticulo.Text = ART[0].Trim();
                        txtDesArt.Text = ART[1].Trim();
                        vCodigoProd = ART[0].Trim();
                        vDescripcion = ART[1].Trim();
                        vStockC = Convert.ToDecimal(ART[3].Trim());
                        vStockD = Convert.ToDecimal(ART[4].Trim());
                        vUndMed = ART[2].Trim();
                        vPrecioSoles = Convert.ToDecimal(ART[5].Trim());
                        vPrecioDolares = Convert.ToDecimal(ART[6].Trim());
                        vUbicacion = ART[7].Trim();
                        vCuentaCargo = Convert.ToDecimal(ART[8].Trim());
                        vCtaAlmacen = Convert.ToDecimal(ART[10].Trim());
                        vProcedencia = Convert.ToDecimal(ART[9].Trim());
                    }
                }
                catch (Exception ex) { }
            } 
        }

        protected void btnBuscar3_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string ART1 = (string)Session["ART"];
                string cantiText = txtCan.Text.Trim();
                if ((cantiText != "") && (cantiText != "0"))
                {
                    if (ART1.Length > 0)
                    {
                        string[] ART = ART1.Split('►');
                        txtArticulo.Text = ART[0].Trim();
                        txtDesArt.Text = ART[1].Trim();
                        vCodigoProd = ART[0].Trim();
                        vDescripcion = ART[1].Trim();
                        vStockC = Convert.ToDecimal(ART[3].Trim());
                        vStockD = Convert.ToDecimal(ART[4].Trim());
                        vUndMed = ART[2].Trim();
                        vPrecioSoles = Convert.ToDecimal(ART[5].Trim());
                        vPrecioDolares = Convert.ToDecimal(ART[6].Trim());
                        vUbicacion = ART[7].Trim();
                        vCuentaCargo = Convert.ToDecimal(ART[8].Trim());
                        vCtaAlmacen = Convert.ToDecimal(ART[10].Trim());
                        vProcedencia = Convert.ToDecimal(ART[9].Trim());
                    }
                    CalcularDatarow();
                    tbldetalle = (DataTable)Session["CARRITO"];
                    dr = tbldetalle.NewRow();
                    dr["codProd"] = vCodigoProd;
                    dr["desProd"] = vDescripcion;
                    dr["PrecioS"] = vPrecioSoles;
                    dr["PrecioD"] = vPrecioDolares;
                    dr["Cantidad"] = Cantidad;
                    dr["UndMeda"] = vUndMed;
                    dr["TotalS"] = TotalS;
                    dr["TotalD"] = TotalD;
                    dr["stockD"] = vStockD;
                    dr["stockC"] = vStockC;
                    dr["vProcedencia"] = vProcedencia;
                    dr["vCtaAlmacen"] = vCtaAlmacen;
                    dr["vCuentaCargo"] = vCuentaCargo;
                    tbldetalle.Rows.Add(dr);
                    tbldetalle.AcceptChanges();
                    Session["CARRITO"] = tbldetalle;
                    dgvDetReq.DataSource = tbldetalle;
                    dgvDetReq.DataBind();
                    limpiar();
                    CalcularTotal();
                }
                else
                {
                    txtCan.Text = "";
                    txtCan.Focus();
                }
            }
            catch
            {
                //btnBuscar3.OnClientClick = "return confirm('¿desea Actualizar los datos estos datos?')";
                dr = tbldetalle.Rows.Find(vCodigoProd.Trim());
                dr.BeginEdit();
                dr["codProd"] = vCodigoProd.Trim();
                dr["desProd"] = vDescripcion;
                dr["PrecioS"] = vPrecioSoles;
                dr["PrecioD"] = vPrecioDolares;
                dr["Cantidad"] = Cantidad;
                dr["UndMeda"] = vUndMed;
                dr["TotalS"] = TotalS;
                dr["TotalD"] = TotalD;
                dr["stockD"] = vStockD;
                dr["stockC"] = vStockC;
                dr["vProcedencia"] = vProcedencia;
                dr["vCtaAlmacen"] = vCtaAlmacen;
                dr["vCuentaCargo"] = vCuentaCargo;
                dr.EndEdit();
                tbldetalle.AcceptChanges();
                Session["CARRITO"] = tbldetalle;
                dgvDetReq.DataSource = tbldetalle;
                dgvDetReq.DataBind();
                limpiar();
                CalcularTotal();
            }  
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            string expresion = "<script language='JavaScript'> window.open('WebBusquedaGral.aspx','','toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbar=no,resizable=no,width=950,height=500');</script>";
            ClientScript.RegisterStartupScript(typeof(Page), "", expresion);
        }

        protected void btnBuscar2_Click(object sender, ImageClickEventArgs e)
        {
            string expresion = "<script language='JavaScript'> window.open('WebBusquedaArticulo.aspx','','toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbar=no,resizable=no,width=950,height=500');</script>";
            ClientScript.RegisterStartupScript(typeof(Page), "", expresion);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string expresion = "<script language='JavaScript'>window.opener.location=window.opener.location; window.close()</script>";
            ClientScript.RegisterStartupScript(typeof(Page), "", expresion);
        }

        protected void Button2_PreRender(object sender, EventArgs e)
        {
            Button2.OnClientClick = "return confirm('¿Desea Salir del Formulario?')";
        }

        protected void Button1_PreRender(object sender, EventArgs e)
        {
            Button1.OnClientClick = "return confirm('¿Desea Guardar Requerimiento?')";
        }

        protected void dgvDetReq_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                tbldetalle = (DataTable)Session["CARRITO"];
                switch (e.CommandName)
                {
                    case "Eliminar":
                        string codigo = e.CommandArgument.ToString();
                        dr = tbldetalle.Rows.Find(Convert.ToString(codigo));
                        dr.Delete();
                        tbldetalle.AcceptChanges();
                        CalcularTotal();
                        Session["CARRITO"] = tbldetalle;
                        dgvDetReq.DataSource = tbldetalle;
                        dgvDetReq.DataBind();
                        break;
                }
            }
            catch { }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            FechaSis = DateTime.Now;
            tbldetalle = (DataTable)Session["CARRITO"];
            if (txtOTR.Text == "") { lblError.Visible = true; lblError.Text = "Ingrese Orden de Trabajo"; return; } else { lblError.Visible = false; lblError.Text = ""; }
            if (dgvDetReq.Rows.Count == 0) { lblError.Visible = true; lblError.Text = "Ingrese Items"; return; } else { lblError.Visible = false; lblError.Text = ""; }
            int h = 0;
            string Hostmaquina = (string)Session["Usuario"].ToString().Trim(); // Environment.MachineName.ToUpper().Trim();

            decimal codSolici = Convert.ToDecimal((string)Session["CodPlanilla"]);

            //switch (Hostmaquina)
            //{
            //    case "PCFME1":
            //        objTablas = new BTablas();
            //        Nro = objTablas.Query("SELECT (MPTDES + 1) AS CORR FROM TEST1.ALMTALMWEB WHERE MPTTAB='NDI' AND MPTARG='" + Hostmaquina + "'").Rows[0]["CORR"].ToString().Trim();
            //        nroReq = Hostmaquina + " - " + Nro;
            //        objTablas = new BTablas();
            //        h = objTablas.InUpDelTablas("UPDATE TEST1.ALMTALMWEB SET MPTDES='" + Nro + "' WHERE MPTTAB='NDI' AND MPTARG='" + Hostmaquina + "'");
            //        break;
            //    case "PCFME2":
            //        objTablas = new BTablas();
            //        Nro = objTablas.Query("SELECT (MPTDES + 1) AS CORR FROM TEST1.ALMTALMWEB WHERE MPTTAB='NDI' AND MPTARG='" + Hostmaquina + "'").Rows[0]["CORR"].ToString().Trim();
            //        nroReq = Hostmaquina + " - " + Nro;
            //        objTablas = new BTablas();
            //        h = objTablas.InUpDelTablas("UPDATE TEST1.ALMTALMWEB SET MPTDES='" + Nro + "' WHERE MPTTAB='NDI' AND MPTARG='" + Hostmaquina + "'");
            //        break;
            //    case "PCFME3":
            //        objTablas = new BTablas();
            //        Nro = objTablas.Query("SELECT (MPTDES + 1) AS CORR FROM TEST1.ALMTALMWEB WHERE MPTTAB='NDI' AND MPTARG='" + Hostmaquina.Trim() + "'").Rows[0]["CORR"].ToString().Trim();
            //        nroReq = Hostmaquina + " - " + Nro;
            //        objTablas = new BTablas();
            //        h = objTablas.InUpDelTablas("UPDATE TEST1.ALMTALMWEB SET MPTDES='" + Nro + "' WHERE MPTTAB='NDI' AND MPTARG='" + Hostmaquina + "'");
            //        break;
            //    default:
            //        objTablas = new BTablas();
            //        Nro = objTablas.Query("SELECT (MPTDES + 1) AS CORR FROM TEST1.ALMTALMWEB WHERE MPTTAB='NDI' AND MPTARG='PCOTR1'").Rows[0]["CORR"].ToString().Trim();
            //        nroReq = Hostmaquina + " - " + Nro;
            //        objTablas = new BTablas();
            //        h = objTablas.InUpDelTablas("UPDATE TEST1.ALMTALMWEB SET MPTDES='" + Nro + "' WHERE MPTTAB='NDI' AND MPTARG='PCOTR1'");
            //        break;
            //}


            objTablas = new BTablas();
            Nro = objTablas.Query("SELECT (COUNT(*) + 1) AS CORR FROM LALMINGB.ali011util WHERE A11SOL=" + codSolici + "").Rows[0]["CORR"].ToString().Trim();
            nroReq = Hostmaquina + " - " + Nro;



            fecha = FechaSis.ToShortDateString().Substring(6, 4) + FechaSis.ToShortDateString().Substring(3, 2) + FechaSis.ToShortDateString().Substring(0, 2);
            Hora = FechaSis.Hour.ToString() + FechaSis.Minute.ToString();
            decimal hor1 = FechaSis.Hour;
            if (hor1 >= 7 && hor1 < 15) { turno = 1; }
            if (hor1 >= 15 && hor1 < 23) { turno = 2; }
            if ((hor1 >= 1 && hor1 < 7) || hor1 == 23 || hor1 == 24) { turno = 3; }
            GrabarCabecera();
            GrabaDetalle();
            Mensaje("Requerimiento " + nroReq + " ha sido generado");            
        }
    }
}

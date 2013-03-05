<%@ Page Language="C#" MasterPageFile="~/MasterPage/AppMenu2.Master" AutoEventWireup="true" CodeBehind="WebNewSolicitudUtiles.aspx.cs" Inherits="LCSA.SGI.WebLogisticaUtiles.Presentacion.Utiles.Transaccion.WebNewSolicitudUtiles" Title="Página sin título" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language ="javascript" type="text/jscript">
    closingvar = true
    window.onbeforeunload = exitcheck;
    function exitcheck()
    {  
    ///control de cerrar la ventana///
      if(closingvar == true) 
      { 
        exitcheck = false
        //return "si decide continuar,abandonará la página pudiendo perder los cambios si no ha grabado ¡¡¡";  
        //window.opener.location=window.opener.location;    
      }
    }
    </script> 
    <style>
    .TextBox
    {
    TEXT-ALIGN: right
    }
    </style>
    <body>               
    <table style="width:100%;">
        <tr>
            <td colspan="4" style="height: 61px">
                <b style="color: #000066; font-size: small;">Solicitud Almacen de UTILES</b></td>
        </tr>
        <tr>
            <td style="width: 116px; font-size: x-small; color: #000000;">
                Orden Trabajo</td>
            <td style="color: #000000">
                <span style="font-size: x-small">Cod.Dpt</td>
            <td style="color: #000000">
                Area</td>
            <td style="color: #000000">
                Para ser empleado en :</span></td>
        </tr>
        <tr>
            <td style="width: 116px; height: 24px;">
                <asp:TextBox ID="txtOTR" runat="server" Width="72px" Font-Size="X-Small" 
                    Enabled="False"></asp:TextBox>
                    <asp:ImageButton ID="btnBuscar" runat="server" 
                    ImageUrl="~/Images/Buscar.ico" Height="18px" Width="20px" 
                    onclick="btnBuscar_Click" />
            </td>
            <td style="height: 24px">
                <asp:TextBox ID="txtDpt" runat="server" Enabled="False" Width="78px" 
                    Font-Size="X-Small"></asp:TextBox>
            </td>
            <td style="height: 24px">
                <asp:TextBox ID="txtArea" runat="server" Enabled="False" Width="137px" 
                    Font-Size="X-Small"></asp:TextBox>
            </td>
            <td style="height: 24px">
                <asp:TextBox ID="txtEmpleado" runat="server" Enabled="False" Width="278px" 
                    Font-Size="X-Small"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 116px; font-size: x-small;">
                Producto</td>
            <td>
            </td>
            <td>
                &nbsp;</td>
            <td style="font-size: x-small;">
                Cantidad&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:TextBox ID="txtArticulo" runat="server" Width="79px" Font-Size="X-Small" 
                    Enabled="False"></asp:TextBox>
            &nbsp;<asp:TextBox ID="txtDesArt" runat="server" Width="266px" Font-Size="X-Small" 
                    Enabled="False"></asp:TextBox>
            &nbsp;<asp:ImageButton ID="btnBuscar2" runat="server" Height="18px" 
                    ImageUrl="~/Images/Buscar.ico" Width="20px" onclick="btnBuscar2_Click" />
            </td>
            <td>
                <asp:TextBox ID="txtCan" runat="server" Width="79px" Font-Size="X-Small" 
                    MaxLength="5" CssClass ="TextBox"></asp:TextBox>
            &nbsp;&nbsp;
                <asp:ImageButton ID="btnBuscar3" runat="server" Height="18px" 
                    ImageUrl="~/Images/HojitaNueva.BMP" Width="20px" 
                    onclick="btnBuscar3_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
        </tr>
        <tr>
            <td style="width: 116px">
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtCan" ErrorMessage="Solo numeros" 
                    ValidationExpression="\d+"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td colspan="4">
    <asp:GridView ID="dgvDetReq" runat="server" Font-Size="Smaller" PageSize="15" 
        SkinID="booksSkin" Width="100%" AutoGenerateColumns="False" 
                    ShowFooter="True" onrowcommand="dgvDetReq_RowCommand" CellPadding="4" 
                    ForeColor="#333333" GridLines="None">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButton1" runat="server" Height="16px" 
                        ImageUrl="~/Images/LapicitoBorrar.bmp" Width="16px" 
                        CommandArgument='<%#Eval("CodProd")%>' CommandName="Eliminar" />
                </ItemTemplate>
                <ItemStyle Width="10px" />
            </asp:TemplateField>
            <asp:BoundField DataField="codProd" HeaderText="Producto">
                <ItemStyle Width="50px" />
            </asp:BoundField>
            <asp:BoundField DataField="desProd" HeaderText="Descripcion">
                <ItemStyle Width="150px" />
            </asp:BoundField>
            <asp:BoundField DataField="PrecioS" HeaderText="PrecioS" Visible="False" />
            <asp:BoundField DataField="PrecioD" HeaderText="PrecioD" Visible="False" />
            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad">
                <ItemStyle Width="40px" HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="UndMeda" HeaderText="Unid.Med">
                <ItemStyle Width="40px" />
            </asp:BoundField>
            <asp:BoundField DataField="TotalS" HeaderText="TotalS" Visible="False" />
            <asp:BoundField DataField="TotalD" HeaderText="TotalD" Visible="False" />
            <asp:BoundField DataField="stockD" HeaderText="Stck Dis.">
                <ItemStyle Width="40px" HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="stockC" HeaderText="Stck Con.">
                <ItemStyle Width="40px" HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="vProcedencia" HeaderText="vProcedencia" 
                Visible="False" />
            <asp:BoundField DataField="vCtaAlmacen" HeaderText="vCtaAlmacen" 
                Visible="False" />
            <asp:BoundField DataField="vCuentaCargo" HeaderText="vCuentaCargo" 
                Visible="False" />
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:TextBox ID="txtTotalS" runat="server" Visible="False"></asp:TextBox>
                <asp:TextBox ID="txtTotalD" runat="server" Visible="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center">
                
                <asp:Button ID="Button1" runat="server" Text="Grabar Req." 
                    onprerender="Button1_PreRender" onclick="Button1_Click" 
                    CssClass="button" />
&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" Text="Salir" onclick="Button2_Click" 
                    onprerender="Button2_PreRender" CssClass="button" />
                
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center">
                
                <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="Red" 
                    Text="Mensaje de Error" Visible="False"></asp:Label>
                
            </td>
        </tr>
    </table>
    
    </body>
</asp:Content>

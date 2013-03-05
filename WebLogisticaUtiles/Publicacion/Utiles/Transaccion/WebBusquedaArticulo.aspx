<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebBusquedaArticulo.aspx.cs" Inherits="LCSA.SGI.WebLogisticaUtiles.Presentacion.Utiles.Transaccion.WebBusquedaArticulo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
    <link href="../../App_Themes/Granite/Default.css" rel="stylesheet" 
        type="text/css" />
    <link href="../../App_Themes/Granite/EstilosFlotante.css" rel="stylesheet" 
        type="text/css" />
        <style type="text/css">
        .style1
        {
            height: 22px;
        }
        .style2
        {
            height: 63px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <table style="width: 95%; color: #990000; background-color: #E4E4E4; clip: rect(10px, 10px, 10px, 10px);">
            <tr>
                <td class="style2">
                    <asp:Label ID="Label1" runat="server" 
                        style="color: #0000CC; font-size: medium; font-weight: 700" 
                        Text="Busqueda de Orden de Trabajo"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="Label2" runat="server" Text="Busqueda    :"></asp:Label>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>Codigo</asp:ListItem>
                        <asp:ListItem>Descripcion</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="txtBusqueda" runat="server" Width="267px" ></asp:TextBox>
                    <asp:Button ID="Button2" runat="server" Text="Buscar" onclick="Button2_Click" 
                        CssClass="button" />
                </td>
            </tr>
            <tr>
                <td class="style1"></td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:GridView ID="dgvConsulta" runat="server" SkinID="booksSkin" 
                        AutoGenerateColumns="False" onpageindexchanging="dgvConsulta_PageIndexChanging" 
                        PageSize="15" Width="100%" AllowPaging="True" Font-Size="Small" 
                        HorizontalAlign="Center" onrowcommand="dgvConsulta_RowCommand" 
                        CellPadding="4" ForeColor="#333333" GridLines="None">
                        <PagerSettings NextPageText="Next" 
                            PreviousPageText="Previous" />
                        <RowStyle Font-Size="X-Small" BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Aprobar"
                                        ImageUrl="~/Images/BUSCAR.BMP" 
                                        CommandArgument='<%# Eval("MPMCOD") + "►" + Eval("MPMDES") + "►" + Eval("T01AL1") + "►" + Eval("MPMSCO") + "►" + Eval("MPMSDI") + "►" + Eval("MPMCPR") + "►" + Eval("MPMCDO") + "►" + Eval("MPMUBI") + "►" + Eval("MPMCCA")+ "►" + Eval("MPMPRO") + "►" + Eval("MPMCTA") %>' />
                                </ItemTemplate>
                                <ItemStyle Width="20px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="MPMCOD" HeaderText="Codigo">
                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MPMDES" HeaderText="Descripcion">
                                <ItemStyle HorizontalAlign="Left" Width="250px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MPMSDI" HeaderText="Stock">
                                <ItemStyle Width="30px" HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="T01AL1" HeaderText="Unid.Med">
                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="MPMSCO" Visible="False" />
                            <asp:BoundField HeaderText="MPMCPR" Visible="False" />
                            <asp:BoundField HeaderText="MPMCDO" Visible="False" />
                            <asp:BoundField HeaderText="MPMUBI" Visible="False" />
                            <asp:BoundField HeaderText="MPMCCA" Visible="False" />
                            <asp:BoundField HeaderText="MPMPRO" Visible="False" />
                            <asp:BoundField HeaderText="MPMCTA" Visible="False" />
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
                <td class="style1">
                    <asp:Button ID="Button1" runat="server" Text="Cerrar" onclick="Button1_Click" 
                        CssClass="button" />
                </td>
            </tr>
            </table>
    </div>
    </form>
</body>
</html>

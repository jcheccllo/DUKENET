<%@ Page Language="C#" MasterPageFile="~/MasterPage/AppMenu.Master" AutoEventWireup="true" CodeBehind="WebConsultaSolicitudUtiles.aspx.cs" Inherits="LCSA.SGI.WebLogisticaUtiles.Presentacion.Utiles.Transaccion.WebConsultaSolicitudUtiles" Title="Modulo Utiles - Consulta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <table style="width:100%;">
        <tr>
            <td colspan="2">
                <asp:Label ID="Label1" runat="server" ForeColor="#181892" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                </td>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                Area</td>
            <td>
                Para ser Empleado en</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtArea" runat="server" Enabled="False" Font-Size="X-Small"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtOtr" runat="server" Width="211px" Enabled="False" 
                    Font-Size="X-Small"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 18px">
                Usuario</td>
            <td style="height: 18px">
                <asp:TextBox ID="txtUsu1" runat="server" Width="211px" Enabled="False" 
                    Font-Size="X-Small"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 18px">
                &nbsp;</td>
            <td style="height: 18px">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
    <asp:GridView ID="dgvRequrimientos" runat="server" 
        AutoGenerateColumns="False" Font-Size="X-Small"  PageSize="15" 
        SkinID="booksSkin" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="A12COD" HeaderText="Codigo" />
            <asp:BoundField DataField="MPMDES" HeaderText="Descripción">
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="A12CAS" HeaderText="Cantidad">
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="T01AL1" HeaderText="Medida">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="A12CAD" HeaderText="A12CAD" Visible="False" />
            <asp:BoundField DataField="A12IMP" HeaderText="A12IMP" Visible="False" />
            <asp:BoundField DataField="A12IMD" HeaderText="A12IMD" Visible="False" />
            <asp:BoundField DataField="A12PRO" HeaderText="A12PRO" Visible="False" />
            <asp:BoundField DataField="A12CTA" HeaderText="A12CTA" Visible="False" />
            <asp:BoundField DataField="A12CCA" HeaderText="A12CCA" Visible="False" />
            <asp:BoundField DataField="MPMSCO" HeaderText="MPMSCO" Visible="False" />
            <asp:BoundField DataField="MPMSDI" HeaderText="MPMSDI" Visible="False" />
            <asp:BoundField DataField="MPMUBI" HeaderText="MPMUBI" Visible="False" />
            <asp:BoundField DataField="MPMCPR" HeaderText="MPMCPR" Visible="False" />
            <asp:BoundField DataField="MPMCDO" HeaderText="MPMCDO" Visible="False" />
            <asp:BoundField DataField="AREA" HeaderText="AREA" Visible="False" />
            <asp:BoundField DataField="ODTDES" HeaderText="ODTDES" Visible="False" />
            <asp:BoundField DataField="A11EST" HeaderText="A11EST" Visible="False" />
            <asp:BoundField DataField="A11STT" HeaderText="A11STT" Visible="False" />
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
            <td>
                &nbsp;</td>
            <td>
                <asp:ImageButton ID="btnAprobar" runat="server" ImageUrl="~/Images/APROBAR.BMP" 
                    ToolTip="Aprobar Requerimiento" Visible="False" onclick="btnAprobar_Click" 
                    onprerender="btnAprobar_PreRender" />
&nbsp;
                <asp:ImageButton ID="btnDesaprueba" runat="server" 
                    ImageUrl="~/Images/ELIMINA.BMP" ToolTip="Desaprobar Requerimiento" 
                    Visible="False" onclick="btnDesaprueba_Click" 
                    onprerender="btnDesaprueba_PreRender" />
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>

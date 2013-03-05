<%@ Page Language="C#" MasterPageFile="~/MasterPage/AppMenu.Master" AutoEventWireup="true" CodeBehind="WebConfiguracionUtil.aspx.cs" Inherits="LCSA.SGI.WebLogisticaUtiles.Presentacion.Utiles.Sistema.WebConfiguracionUtil" Title="Modulo Utiles - Configuración" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script language="javascript" type="text/javascript">
        function AbrirDialogoModal(url)
        {
            var vValorRetorno;
            if (url != null)
               vValorRetorno = window.showModalDialog(url,"#1","dialogHeight: 500px; dialogWidth: 950px; dialogTop: 150px; dialogLeft: 250px; edge: Raised; center: Yes; help: No; resizable: 0; status: 0; location: 0;");           
        }
    </script>
        <asp:GridView ID="dgvUsuarios" runat="server" AutoGenerateColumns="False" 
            SkinID="booksSkin" style="text-align: center" Font-Size="Smaller" 
        AllowPaging="True" onpageindexchanging="dgvUsuarios_PageIndexChanging" 
            onrowcommand="dgvUsuarios_RowCommand" onrowdatabound="dgvUsuarios_RowDataBound" 
            PageSize="15" CellPadding="4" ForeColor="#333333" GridLines="None" >
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
                <asp:BoundField DataField="CODUSE" HeaderText="Usuario" Visible="False">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="CODEMP" HeaderText="Codigo" >
                    <ItemStyle Width="20%" />
                </asp:BoundField>
                <asp:BoundField DataField="NOMEMP" HeaderText="Nombre">
                    <ItemStyle HorizontalAlign="Left" Width="65%" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Editar">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="21px" 
                            ImageUrl="~/Images/EditarPeq.gif" Width="23px" CommandName="Editar" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Eliminar">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Eliminar" 
                            ImageUrl="~/Images/Eliminar.gif" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        
    <p>
    </p>
    <p>
    </p>
</asp:Content>
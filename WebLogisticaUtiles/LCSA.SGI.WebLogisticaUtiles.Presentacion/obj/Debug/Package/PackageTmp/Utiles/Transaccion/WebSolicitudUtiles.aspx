<%@ Page Language="C#" MasterPageFile="~/MasterPage/AppMenu.Master" AutoEventWireup="true" CodeBehind="WebSolicitudUtiles.aspx.cs" Inherits="LCSA.SGI.WebLogisticaUtiles.Presentacion.Utiles.Transaccion.WebSolicitudUtiles" Title="Modulo Utiles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">
        function AbrirDialogoModal(url)
        {
            var vValorRetorno;
            if (url != null)
            {               
               //vValorRetorno = window.showModalDialog(url,"#1","dialogHeight: 500px; dialogWidth: 950px; dialogTop: 150px; dialogLeft: 250px; edge: Raised; center: Yes; help: No; resizable: 0; status: 0; location: 0;");
               //vValorRetorno = window.showModalDialog(url,"#1","");           
               vValorRetorno = window.open(url,"Solicitud","toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbar=no,resizable=no,width=950,height=500");
            }          
        }
    </script>
    <br />
    <asp:GridView ID="dgvRequrimientos" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" Font-Size="X-Small" 
        onpageindexchanging="dgvRequrimientos_PageIndexChanging" PageSize="15" 
        SkinID="booksSkin" Width="100%" CellPadding="4" ForeColor="#333333" 
        GridLines="None">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:HyperLinkField DataTextField="A11NSA" HeaderText="Solicitud" 
                DataNavigateUrlFields="A11NSA" 
                DataNavigateUrlFormatString="WebConsultaSolicitudUtiles.aspx?A11NSA={0}">
                <ItemStyle Font-Size="Smaller" />
            </asp:HyperLinkField>
            <asp:BoundField DataField="A11FSA" HeaderText="Fecha" 
                DataFormatString="{0:0000-00-00}" >
                <ItemStyle Font-Size="X-Small" HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="A11TUR" HeaderText="Turno" Visible="False" />
            <asp:BoundField DataField="T01AL1" HeaderText="Area" Visible="False" />
            <asp:BoundField DataField="Nombre" HeaderText="Solicitante" >
                <ItemStyle Font-Size="Smaller" />
            </asp:BoundField>
            <asp:BoundField DataField="ESTADO" HeaderText="Estado" >
                <ItemStyle Font-Size="XX-Small" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <br />    
    <asp:ImageButton ID="btnGenerarReq" runat="server" 
        ImageUrl="~/Images/Edit.ico" 
        ToolTip="Ingresar Nueva Solicitud"
        onprerender="ImageButton1_PreRender" onclick="ImageButton1_Click"/>    
    
</asp:Content>
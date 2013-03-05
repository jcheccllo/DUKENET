<%@ Page Language="C#" MasterPageFile="~/MasterPage/AppMenu.Master" AutoEventWireup="true" CodeBehind="WebCambioContrasenaUtil.aspx.cs" Inherits="LCSA.SGI.WebLogisticaUtiles.Presentacion.Utiles.Sistema.WebCambioContrasenaUtil" Title="Página sin título" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<p align="left">Ingresar Contrase&ntilde;a Anterior&nbsp;&nbsp;&nbsp; :<asp:TextBox ID="txtPWDAnterior" 
          runat="server" Width="173px" TextMode="Password"></asp:TextBox>
    </p>
    <asp:RequiredFieldValidator ID="rqv1" runat="server" 
        ControlToValidate="txtPWDAnterior" Display="Dynamic" 
        ErrorMessage="&lt;br&gt;&lt;div align=center&gt;&lt;b&gt;Contraseña&lt;/b&gt; es un campo obligatorio.&lt;/div&gt;"></asp:RequiredFieldValidator>
    <p align="left"><p style="text-align: center">Ingresar Contrase&ntilde;a Nueva &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :<asp:TextBox ID="txtPWDNuevo" 
          runat="server" Width="173px" TextMode="Password"></asp:TextBox>
    </p>
    <asp:RequiredFieldValidator ID="rqv2" runat="server" 
        ControlToValidate="txtPWDNuevo" Display="Dynamic" 
        ErrorMessage="&lt;br&gt;&lt;div align=center&gt;&lt;b&gt;Contraseña Nueva&lt;/b&gt; es un campo obligatorio.&lt;/div&gt;"></asp:RequiredFieldValidator>
    <p align="left"><p align="left">Confirmación Contrase&ntilde;a Nueva&nbsp; :<asp:TextBox ID="txtPWDConfirmacion" 
          runat="server" Width="173px" TextMode="Password"></asp:TextBox>
    </p>
    <asp:RequiredFieldValidator ID="rqv3" runat="server" 
        ControlToValidate="txtPWDConfirmacion" Display="Dynamic" 
        ErrorMessage="&lt;br&gt;&lt;div align=center&gt;&lt;b&gt;Confirmación Contraseña&lt;/b&gt; es un campo obligatorio.&lt;/div&gt;"></asp:RequiredFieldValidator>
    <p align="left">
        <asp:Label ID="lblVerificacion" runat="server" ForeColor="Red" Text="Label"></asp:Label>
    </p>
    <asp:CompareValidator ID="CompareValidator1" runat="server" 
        ControlToCompare="txtPWDNuevo" ControlToValidate="txtPWDConfirmacion" 
        Display="Dynamic" 
        
        ErrorMessage="&lt;br&gt;&lt;div align=center&gt;contraseñas Nueva y confirmacion deben &lt;b&gt;coincidir&lt;/b&gt;.&lt;/div&gt;"></asp:CompareValidator>
    <p align="left">
        <asp:Button ID="Button2" runat="server" Text="Aceptar" 
            onclick="Button2_Click" CssClass="button" />
    </p>
</asp:Content>


<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuDinamico.aspx.cs" Inherits="LCSA.SGI.WebLogisticaUtiles.Presentacion.MenuDinamico" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
    <link href="App_Themes/Granite/Default.css" rel="stylesheet" type="text/css" />
    <link href="App_Themes/Granite/EstilosFlotante.css" rel="stylesheet" 
        type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Menu ID="MyMenu" runat="server" Height="32px" Width="280px"
            MaximumDynamicDisplayLevels ="2" BackColor="#FFFBD6" 
            DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" 
            ForeColor="#990000" StaticSubMenuIndent="10px">
            <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <DynamicMenuStyle BackColor="#FFFBD6" />
            <DynamicSelectedStyle BackColor="#FFCC66" />
            <StaticHoverStyle BackColor="#990000" ForeColor="White" />
            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <StaticSelectedStyle BackColor="#FFCC66" />
        </asp:Menu>  
    </div>
    </form>
</body>
</html>

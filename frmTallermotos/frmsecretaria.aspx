<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmsecretaria.aspx.cs" Inherits="prjtallermotos.frmsecretaria" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:RadioButtonList runat="server" AutoPostBack="true" RepeatDirection="Vertical" ID="rdlOpciones" OnSelectedIndexChanged="rdSeleccion_SelectedIndexChanged">
                 <asp:ListItem Value="opcMecanico">Mecanico</asp:ListItem>
                <asp:ListItem Value="opcCliente">Cliente</asp:ListItem>
                <asp:ListItem Value="opcFacturacion">Facturacion</asp:ListItem>
            </asp:RadioButtonList>
        </div>

        <asp:Panel runat="server" Visible="false" ID="pnlmecanico">
            <asp:DropDownList runat="server" AutoPostBack="true" ID="dpCarro" >
             </asp:DropDownList>
            <asp:DropDownList runat="server" AutoPostBack="true" ID="dpmecanico">
             </asp:DropDownList>
        </asp:Panel>
    </form>
</body>
</html>

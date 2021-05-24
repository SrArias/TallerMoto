<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmadmin.aspx.cs" Inherits="prjtallermotos.frmadmin" %>

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
            <asp:DropDownList runat="server" AutoPostBack="true" ID="ddlCarro" >
             </asp:DropDownList>
            <asp:DropDownList runat="server" AutoPostBack="true" ID="ddlmecanico">
             </asp:DropDownList>
            <asp:Button runat="server" ID="btnregistrar" Text="Registrar"/>
        </asp:Panel>

        <asp:Panel runat="server" Visible="false" ID="pnlCliente">
            <asp:TextBox runat="server" ID="txtidentificación" TextMode="Number" ></asp:TextBox>
            <asp:TextBox runat="server" ID="txtnombre" ></asp:TextBox>
            <asp:TextBox runat="server" ID="txttelefono" TextMode="Number" ></asp:TextBox>
            <asp:TextBox runat="server" ID="txtdireccion" ></asp:TextBox>
            <asp:DropDownList runat="server" AutoPostBack="true" ID="ddlvehiculo" >
             </asp:DropDownList>
            
        </asp:Panel>
    </form>
</body>
</html>

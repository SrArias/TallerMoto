<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCliente.aspx.cs" Inherits="frmTallermotos.frmCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:RadioButtonList runat="server" AutoPostBack="true" ID="rdlOpciones" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdlOpciones_SelectedIndexChanged">
                <asp:ListItem Value="opcMantenimiento">Mantenimiento</asp:ListItem>
                <asp:ListItem Value="opcFactura">Factura</asp:ListItem>
            </asp:RadioButtonList>



            <asp:Panel runat="server" Visible="false" ID="pnlMantenimiento">

                <asp:GridView runat="server" ID="gvmantenimiento">
                    <HeaderStyle CssClass="thead-dark" />
                </asp:GridView>
            </asp:Panel>
            <asp:Panel runat="server" Visible="false" ID="pnlFactura">

                <asp:GridView runat="server" ID="gvFactura">
                    
                </asp:GridView>
            </asp:Panel>

        </div>
    </form>
</body>
</html>

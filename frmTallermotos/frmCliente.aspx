<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCliente.aspx.cs" Inherits="frmTallermotos.frmCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/style.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

              <div >

            <asp:RadioButtonList runat="server" AutoPostBack="true" ID="rdlOpciones" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdlOpciones_SelectedIndexChanged" CssClass="Centrar-Medio" >
                <asp:ListItem Value="opcMantenimiento">Mantenimiento</asp:ListItem>
                <asp:ListItem Value="opcFactura">Factura</asp:ListItem>
            </asp:RadioButtonList>

                  <br />
                  <br />

            <asp:Panel runat="server" Visible="false" ID="pnlMantenimiento" CssClass="Centrar-Medio">

                <asp:GridView runat="server" ID="gvmantenimiento">
                    <HeaderStyle CssClass="thead-dark" />
                </asp:GridView>
            </asp:Panel>
            <asp:Panel runat="server" Visible="false" ID="pnlFactura" CssClass="Centrar-Medio">

                <asp:GridView runat="server" ID="gvFactura">
                    
                </asp:GridView>
            </asp:Panel>

        </div>
    </form>
</body>
</html>

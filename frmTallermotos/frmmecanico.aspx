<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmmecanico.aspx.cs" Inherits="prjtallermotos.frmmecanico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList runat="server" ID="ddlvehiculoM">

            </asp:DropDownList>

            <asp:TextBox runat="server" ID="txtDiagnostico">

            </asp:TextBox>
            <asp:TextBox runat="server" ID="txtprocedimiento">

            </asp:TextBox>
            <asp:Button runat="server" ID="btnGuardar"/>
        </div>
    </form>
</body>
</html>

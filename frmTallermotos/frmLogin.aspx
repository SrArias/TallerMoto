<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="frmTallermotos.frmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="input-group mb-3">
  <div class="input-group-prepend">
    <span class="input-group-text" id="basic-addon1">@</span>
  </div>
  <input type="number" runat="server" id="txtusername" class="form-control" placeholder="Username" aria-label="Username" aria-describedby="basic-addon1"/>
  
</div>
        <div class="input-group mb-3">
  <div class="input-group-prepend">
    <span class="input-group-text" id="basic-addon1">#</span>
  </div>
  <input type="password" onclick="" runat="server" id="txtpassword" class="form-control" placeholder="Password" aria-label="Username" aria-describedby="basic-addon1"/>
  
</div>
        <div>
            
            <asp:Button runat="server" ID="btn" CssClass="btn btn-info" Text="Ingresar" OnClick="btn_Click"/>
        </div>
    </form>
</body>
</html>

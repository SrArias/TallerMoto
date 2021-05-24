<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmsecretaria.aspx.cs" Inherits="prjtallermotos.frmsecretaria" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta name="viewport" content="width=device-width, initial-scale=1" />
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
        <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />

    <link href="css/styleAdmin.css" rel="stylesheet" />

    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div class="card bg-dark text-black ">
            <img src="img/shutterstock_185512175-1024x576.jpg" />
  <div class="card-img-overlay  ">

      <div class="cuadrito">
    <h1 class="card-title posicion1">Taller de motos</h1>
    <h2 class="card-title posicion2">¡Bienvenido!</h2>
  </div>
  </div>
</div>





































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









<!-- The sidebar -->
<div class="sidebar">
     <a href="frmsecretaria.aspx"><i class="fa fa-home fa-2x"></i>Home</a>
  <a href="Admin/Empleado.aspx"><i class="fa fa-fw fa-user"></i>Empleados</a>
  <a href="Admin/Facturas.aspx"><i class="fa fa-fw fa-envelope"></i>Facturas</a>
  <a href="Admin/Detalles.aspx"><i class="fa fa-fw fa-envelope"></i>Detalles de las facturas</a>
  <a href="Admin/Mantenimiento.aspx"<i class="fa fa-fw fa-wrench"></i>Mantenimiento</a>
  <a href="Admin/Clientes.aspx"><i class="fa fa-fw fa-user"></i>Clientes</a>
  <a href="Admin/Vehiculos.aspx"><i class="fa fa-fw fa-wrench"></i>Vehículos</a>
  <a href="Admin/Proveedores.aspx""><i class="fa fa-fw fa-user"></i>Proveedores</a>
  <a href="Admin/Repuestos.aspx"><i class="fa fa-fw fa-wrench"></i>Repuestos</a>
</div>



    </form>



</body>
</html>



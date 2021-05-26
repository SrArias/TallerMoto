<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Facturas.aspx.cs" Inherits="prjtallermotos.Admin.Facturas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <meta name="viewport" content="width=device-width, initial-scale=1">
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
      <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <link href="../css/styleAdmin.css" rel="stylesheet" />

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       
    <!-- The sidebar -->
<div class="sidebar">
   <a href="../frmadmin.aspx"><i class="fa fa-home fa-2x"></i>Home</a>
  <a href="Empleado.aspx"><i class="fa fa-fw fa-user"></i>Empleados</a>
  <a href="Facturas.aspx"><i class="fa fa-fw fa-envelope"></i>Facturas</a>
  <a href="Detalles.aspx"><i class="fa fa-fw fa-envelope"></i>Detalles de las facturas</a>
  <a href="Mantenimiento.aspx"><i class="fa fa-fw fa-wrench"></i>Mantenimiento</a>
  <a href="Clientes.aspx"><i class="fa fa-fw fa-user"></i>Clientes</a>
  <a href="Vehiculos.aspx"><i class="fa fa-fw fa-wrench"></i>Vehículos</a>
  <a href="Proveedores.aspx""><i class="fa fa-fw fa-user"></i>Proveedores</a>
  <a href="Repuestos.aspx"><i class="fa fa-fw fa-wrench"></i>Repuestos</a>
    </div>



          <div class="Centrar-Medio">  
            <h1>Facturas</h1>
            </div>

        <br />

          <div class="row justify-content-center">
         <asp:DropDownList ID="drpvehiculoID" AutoPostBack="true" CssClass="text-center form-control list-group-horizontal list-group-item-action size" runat="server" >
                                                <asp:ListItem Text="Seleccione un vehículo" />
                                                
       </asp:DropDownList>
            </div>

        <br />

        

          <div class="row justify-content-center">
         <asp:DropDownList ID="drpEmpleadoID" AutoPostBack="true" CssClass="text-center form-control list-group-horizontal list-group-item-action size" runat="server" >
                                                <asp:ListItem Text="Seleccione un empleado" />
                                                
       </asp:DropDownList>
            </div>

        <br />

        

       <div class="Centrar-Medio">            
            <asp:Button  runat="server" ID="btnInsertarFac" CssClass="btn btn-info" Text="Insertar"/>
                  
        </div>
        <br />


            <asp:Panel runat="server" Visible="true" ID="pnlFactura" CssClass="tablaFactura">
                <asp:GridView runat="server" ID="gvFactura">                    
                </asp:GridView>
            </asp:Panel>


                <img src="../img/imageedit_3_5509983854.png" class="logPosicionFac"/>



    </form>
</body>
</html>

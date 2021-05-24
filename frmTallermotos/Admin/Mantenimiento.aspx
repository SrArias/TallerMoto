<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mantenimiento.aspx.cs" Inherits="prjtallermotos.Admin.Mantenimiento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      
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
     <a href="../frmsecretaria.aspx"><i class="fa fa-home fa-2x"></i>Home</a>
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
            <h1>Mantenimiento</h1>
            </div>

        <br />

       <div class="row justify-content-center">
         <asp:DropDownList ID="drpIdVehiculo" AutoPostBack="true" CssClass="text-center form-control list-group-horizontal list-group-item-action size" runat="server" >
         <asp:ListItem Text="Seleccione una placa" />                                                
       </asp:DropDownList>
           </div>

        <br />

         <div class="row justify-content-center">
         <asp:DropDownList ID="drpIdEmpleado" AutoPostBack="true" CssClass="text-center form-control list-group-horizontal list-group-item-action size" runat="server" >
         <asp:ListItem Text="Seleccione un ID de empleado" />                                                
       </asp:DropDownList>
           </div>

        <br />

        
       <div class="row justify-content-center">
        <div class="input-group mb-3 Centrar-Medio size" >
          <div class="input-group-prepend">
          <span class="input-group-text" id="basic-addon2">Diagnóstico</span>
          </div>
          <input type="text" onclick="" runat="server" id="txtDiagnostico" class="form-control"  aria-label="Diagnostico" aria-describedby="basic-addon1"/>  
        </div>
       </div>


         <div class="row justify-content-center">
        <div class="input-group mb-3 Centrar-Medio size" >
          <div class="input-group-prepend">
          <span class="input-group-text" >Procedimiento realizado</span>
          </div>
          <input type="text" onclick="" runat="server" id="txtProcRealiz" class="form-control"  aria-label="ProcRealiz" aria-describedby="basic-addon1"/>  
        </div>
       </div>


       <div class="Centrar-Medio">            
            <asp:Button  runat="server" ID="btnInsertarMant" CssClass="btn btn-info" Text="Insertar"/>
                  
            <asp:Button  runat="server" ID="btnActualizarMant" CssClass="btn btn-info" Text="Actualizar"/>
        </div>
        <br />

        <h5 class="Centrar-Medio">Si desea actualizar el mantenimiento debe escoger su ID</h5>

        <br />

          <div class="row justify-content-center">
         <asp:DropDownList ID="drpIdMantenim" AutoPostBack="true" CssClass="text-center form-control list-group-horizontal list-group-item-action size" runat="server" >
                                                <asp:ListItem Text="Seleccione un ID" />
                                                
       </asp:DropDownList>

               <br />

            <asp:Panel runat="server" Visible="true" ID="pnlMantenimiento" CssClass="tablaMantenimiento">
                <asp:GridView runat="server" ID="gvMantenimiento">                    
                </asp:GridView>
            </asp:Panel>

     </div>
            
         <img src="../img/imageedit_3_5509983854.png" class="logPosicionMant"/>

    </form>
</body>
</html>

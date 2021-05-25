<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vehiculos.aspx.cs" Inherits="prjtallermotos.Admin.Vehiculos" %>

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
            <h1>Vehículos</h1>
            </div>

        <br />


          <div class="row justify-content-center">         
        <div class="input-group mb-3 Centrar-Medio size " >
          <div class="input-group-prepend">
              <span class="input-group-text">Placa</span>
          </div>
           <input type="text" runat="server" id="txtIdVehiculo" class="form-control" aria-label="IdVehiculo" aria-describedby="basic-addon1"/>  
          </div>
        </div>  


       <div class="row justify-content-center">
        <div class="input-group mb-3 Centrar-Medio size" >
          <div class="input-group-prepend">
          <span class="input-group-text" id="basic-addon2">Marca</span>
          </div>
          <input type="text" onclick="" runat="server" id="txtMarca" class="form-control"  aria-label="Marca" aria-describedby="basic-addon1"/>  
        </div>
       </div>


         <div class="row justify-content-center">
        <div class="input-group mb-3 Centrar-Medio size" >
          <div class="input-group-prepend">
          <span class="input-group-text" >Cilindraje</span>
          </div>
          <input type="text" onclick="" runat="server" id="txtCilindraje" class="form-control"  aria-label="Cilindraje" aria-describedby="basic-addon1"/>  
        </div>
       </div>

         <div class="row justify-content-center">
        <div class="input-group mb-3 Centrar-Medio size" >
          <div class="input-group-prepend">
          <span class="input-group-text" >Modelo</span>
          </div>
          <input type="number" onclick="" runat="server" id="txtModelo" class="form-control"  aria-label="Modelo" aria-describedby="basic-addon1"/>  
        </div>
       </div>

            <div class="row justify-content-center">
        <div class="input-group mb-3 Centrar-Medio size" >
          <div class="input-group-prepend">
          <span class="input-group-text" >Color</span>
          </div>
          <input type="text" onclick="" runat="server" id="txtColor" class="form-control"  aria-label="Color" aria-describedby="basic-addon1"/>  
        </div>
       </div>

            <div class="row justify-content-center">
        <div class="input-group mb-3 Centrar-Medio size" >
          <div class="input-group-prepend">
          <span class="input-group-text" >Referencia</span>
          </div>
          <input type="text" onclick="" runat="server" id="txtReferencia" class="form-control"  aria-label="Referencia" aria-describedby="basic-addon1"/>  
        </div>
       </div>


        <br />

        

       <div class="Centrar-Medio">            
            <asp:Button  runat="server" ID="btnInsertarVeh" CssClass="btn btn-info" Text="Insertar"/>
                  
            <asp:Button  runat="server" ID="btnActualizarVeh" CssClass="btn btn-info" Text="Actualizar"/>
        </div>
        <br />

        <h5 class="Centrar-Medio">Si desea actualizar un vehículo debe seleccionar su placa</h5>


        <br />


           <div class="row justify-content-center">
         <asp:DropDownList ID="drpIdVehiculo" AutoPostBack="true" CssClass="text-center form-control list-group-horizontal list-group-item-action size" runat="server" >
                                                <asp:ListItem Text="Seleccione una placa" />
                                                
       </asp:DropDownList>
               </div>

               <br />



         <br />

            <asp:Panel runat="server" Visible="true" ID="pnlVehic" CssClass="tablaVehic">
                <asp:GridView runat="server" ID="gvVehic">                    
                </asp:GridView>
            </asp:Panel>


        <img src="../img/imageedit_3_5509983854.png" class="logPosicionVeh"/>

    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Repuestos.aspx.cs" Inherits="prjtallermotos.Admin.Repuestos" %>

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
            <h1>Repuestos</h1>
            </div>

        <br />
        
       <div class="row justify-content-center">
        <div class="input-group mb-3 Centrar-Medio size" >
          <div class="input-group-prepend">
          <span class="input-group-text" id="basic-addon2">Nombre de repuesto</span>
          </div>
          <input type="text" onclick="" runat="server" id="txtNomRep" class="form-control"  aria-label="NomRep" aria-describedby="basic-addon1"/>  
        </div>
       </div>


         <div class="row justify-content-center">
        <div class="input-group mb-3 Centrar-Medio size" >
          <div class="input-group-prepend">
          <span class="input-group-text" >Unidades en stock</span>
          </div>
          <input type="number" onclick="" runat="server" id="txtUnidStock" class="form-control"  aria-label="UnidStock" aria-describedby="basic-addon1"/>  
        </div>
       </div>

         <div class="row justify-content-center">
        <div class="input-group mb-3 Centrar-Medio size" >
          <div class="input-group-prepend">
          <span class="input-group-text" >Unidades ordenadas</span>
          </div>
          <input type="number" onclick="" runat="server" id="txtUnidOrden" class="form-control"  aria-label="UnidOrden" aria-describedby="basic-addon1"/>  
        </div>
       </div>

            <div class="row justify-content-center">
        <div class="input-group mb-3 Centrar-Medio size" >
          <div class="input-group-prepend">
          <span class="input-group-text" >Precio por unidad</span>
          </div>
          <input type="number" onclick="" runat="server" id="txtPropUnid" class="form-control"  placeholder="$" aria-label="PropUnid" aria-describedby="basic-addon1"/>  
        </div>
       </div>

          <div class="row justify-content-center">
         <asp:DropDownList ID="drpProvID" AutoPostBack="true" CssClass="text-center form-control list-group-horizontal list-group-item-action size" runat="server" >
                                                <asp:ListItem Text="Seleccione un ID de proveedor" />
                                                
       </asp:DropDownList>
               </div>

        <br />

       <div class="Centrar-Medio">            
            <asp:Button  runat="server" ID="btnInsertarRep" CssClass="btn btn-info" Text="Insertar"/>
                  
            <asp:Button  runat="server" ID="btnActualizarRep" CssClass="btn btn-info" Text="Actualizar"/>
        </div>
        <br />

        <h5 class="Centrar-Medio">Si desea actualizar un repuesto debe escoger su ID</h5>

        <br />

           <div class="row justify-content-center">
         <asp:DropDownList ID="drpIdRep" AutoPostBack="true" CssClass="text-center form-control list-group-horizontal list-group-item-action size" runat="server" OnSelectedIndexChanged="drpIdRep_SelectedIndexChanged" >
                                                <asp:ListItem Text="Seleccione un ID" />
                                                
       </asp:DropDownList>
               </div>


         <br />

            <asp:Panel runat="server" Visible="true" ID="pnlRep" CssClass="tablaRep">
                <asp:GridView runat="server" ID="gvRep">                    
                </asp:GridView>
            </asp:Panel>


                <img src="../img/imageedit_3_5509983854.png" class="logPosicionGen"/>


    </form>
</body>
</html>

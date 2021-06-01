<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Detalles.aspx.cs" Inherits="prjtallermotos.Admin.Detalles" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <link href="../css/styleAdmin.css" rel="stylesheet" />
    <title>Facturación</title>
</head>
<body>
    <form id="form1" runat="server">
        <!-- The sidebar -->
        <div class="sidebar">
            <a href="../frmadmin.aspx"><i class="fa fa-home fa-2x"></i>Home</a>
            <a href="Empleado.aspx"><i class="fa fa-fw fa-user"></i>Empleados</a>
            <a href="Proveedores.aspx"><i class="fa fa-fw fa-user"></i>Proveedores</a>
            <a href="Repuestos.aspx"><i class="fa fa-fw fa-wrench"></i>Repuestos</a>
            <a href="Vehiculos.aspx"><i class="fa fa-fw fa-wrench"></i>Vehículos</a>
            <a href="Clientes.aspx"><i class="fa fa-fw fa-user"></i>Clientes</a>
            <a href="Mantenimiento.aspx"><i class="fa fa-fw fa-wrench"></i>Mantenimiento</a>                     
            <a href="Detalles.aspx"><i class="fa fa-fw fa-envelope"></i>Facturación</a>            
            <asp:ImageButton runat="server" ID="logout_new" ImageUrl="~/img/image_icon_logout_pic_512x512.png"  style="margin-top:95%" OnClick="logout_new_Click"/>
        </div>
        <div class="Centrar-Medio">
            <h1>Facturación</h1>
        </div>
        <br />
        <br />
        <div class="Centrar-Medio">
            <asp:Button runat="server" ID="btnFactura" CssClass="btn btn-info" Text="Factura" OnClick="btnFactura_Click" />
            <asp:Button runat="server" ID="btnDetallesFac" CssClass="btn btn-info" Text="Detalles Factura" OnClick="btnDetallesFac_Click"  Enabled="false"/>
        </div>
        <asp:Panel runat="server" ID="pnldetalles" Visible="false">
            <br />

            <br />
            <div class="row justify-content-center">
                <div class="input-group mb-3 Centrar-Medio size">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="basic-addon2">Fecha</span>
                    </div>
                    <input type="text" onclick="" disabled="true" runat="server" id="txtFecha" class="form-control" placeholder="AAAA-MM-DD" aria-label="Fecha" aria-describedby="basic-addon1" />
                </div>
            </div>
            <div class="row justify-content-center">
                <div class="input-group mb-3 Centrar-Medio size">
                    <div class="input-group-prepend">
                        <span class="input-group-text">Repuesto</span>
                    </div>
                <asp:DropDownList ID="drpRepuesto" AutoPostBack="true" CssClass="text-center form-control list-group-horizontal list-group-item-action size" runat="server">
                </asp:DropDownList>
                    </div>
            </div>
            <div class="row justify-content-center">
                <div class="input-group mb-3 Centrar-Medio size">
                    <div class="input-group-prepend">
                        <span class="input-group-text">Cantidad del repuesto</span>
                    </div>
                    <input type="number" onclick="" runat="server" id="txtCantidadRep" class="form-control" aria-label="CantidadRep" aria-describedby="basic-addon1" />
                </div>
            </div>
            <div class="row justify-content-center">
                     <div class="input-group mb-3 Centrar-Medio size">
                    <div class="input-group-prepend">
                        <span class="input-group-text">Procedimiento</span>
                    </div>
                <asp:DropDownList ID="drpMantenimientoId" AutoPostBack="true" CssClass="text-center form-control list-group-horizontal list-group-item-action size" runat="server">                    
                </asp:DropDownList>
                     </div>
            </div>
            <br />
            <div class="row justify-content-center">
                <div class="input-group mb-3 Centrar-Medio size">
                    <div class="input-group-prepend">
                        <span class="input-group-text">Precio del mantenimiento</span>
                    </div>
                    <input type="number" onclick="" runat="server" id="txtPrecioMant" placeholder="$" class="form-control" aria-label="PrecioMant" aria-describedby="basic-addon1" />
                </div>
            </div>
            
            <br />
            <div class="Centrar-Medio">
                <asp:Button runat="server" ID="btnInsertarDet" CssClass="btn btn-info" Text="Insertar" OnClick="btnInsertarDet_Click"/>
            </div>
            <div class="Centrar-Medio">
                <br />
           <asp:GridView runat="server" ID="gvdetalles">
               
           </asp:GridView>

            </div>


            <img src="../img/imageedit_3_5509983854.png" class="logPosicionGen" />
            
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlFactura" Visible="true">
            <br />
            <div class="row justify-content-center">
                <div class="input-group-prepend">
                    <span class="input-group-text">Seleccion el vehiculo</span>
                </div>
                <asp:DropDownList ID="drpVehiculoId" AutoPostBack="true" CssClass="text-center form-control list-group-horizontal list-group-item-action size" runat="server">
                </asp:DropDownList>
            </div>
            <br />
            <div class="row justify-content-center">
                <div class="input-group-prepend">
                    <span class="input-group-text">Seleccione el empleado</span>
                </div>
                <asp:DropDownList ID="drpempleadofactura" AutoPostBack="true" CssClass="text-center form-control list-group-horizontal list-group-item-action size" runat="server">
                </asp:DropDownList>
                <br />
            </div>
                <br />
                <br />
            <div class="Centrar-Medio">
                <asp:Button runat="server" CssClass="btn btn-info" ID="btngenerarfactura" Text="Generar factura" OnClick="btngenerarfactura_Click"></asp:Button>

            </div>            
        </asp:Panel>
        <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11.0.11/dist/sweetalert2.all.min.js"></script>
        <script src="../js/sweetalert.js" type="text/javascript"></script>
    </form>
</body>
</html>
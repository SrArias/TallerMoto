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
            <a href="Detalles.aspx"><i class="fa fa-fw fa-envelope"></i>Facturación</a>
            <a href="Mantenimiento.aspx"><i class="fa fa-fw fa-wrench"></i>Mantenimiento</a>
            <a href="Clientes.aspx"><i class="fa fa-fw fa-user"></i>Clientes</a>
            <a href="Vehiculos.aspx"><i class="fa fa-fw fa-wrench"></i>Vehículos</a>
            <a href="Proveedores.aspx"><i class="fa fa-fw fa-user"></i>Proveedores</a>
            <a href="Repuestos.aspx"><i class="fa fa-fw fa-wrench"></i>Repuestos</a>
            <img src="../img/image_icon_logout_pic_512x512.png" style="margin-top:95%"/>
        </div>
        <div class="Centrar-Medio">
            <h1>Facturación</h1>
        </div>
        <br />
        <br />
        <div class="row justify-content-center">
            <asp:DropDownList ID="drpvehiculoID" AutoPostBack="true" CssClass="text-center form-control list-group-horizontal list-group-item-action size" runat="server">
                <asp:ListItem Text="Seleccione un vehículo" />
            </asp:DropDownList>
        </div>
        <br />
        <div class="row justify-content-center">
            <asp:DropDownList ID="drpEmpleadoID" AutoPostBack="true" CssClass="text-center form-control list-group-horizontal list-group-item-action size" runat="server">
                <asp:ListItem Text="Seleccione un empleado" />
            </asp:DropDownList>
        </div>
        <br />
        <div class="row justify-content-center">
            <div class="input-group mb-3 Centrar-Medio size">
                <div class="input-group-prepend">
                    <span class="input-group-text" id="basic-addon2">Fecha</span>
                </div>
                <input type="text" onclick="" runat="server" id="txtFecha" class="form-control" placeholder="AAAA-MM-DD" aria-label="Fecha" aria-describedby="basic-addon1" />
            </div>
        </div>
        <div class="row justify-content-center">
            <asp:DropDownList ID="drpRepuesto" AutoPostBack="true" CssClass="text-center form-control list-group-horizontal list-group-item-action size" runat="server">
                <asp:ListItem Text="Seleccione un repuesto" />
            </asp:DropDownList>
        </div>
        <br />
        <div class="row justify-content-center">
            <div class="input-group mb-3 Centrar-Medio size">
                <div class="input-group-prepend">
                    <span class="input-group-text">Cantidad del repuesto</span>
                </div>
                <input type="number" onclick="" runat="server" id="txtCantidadRep" class="form-control" aria-label="CantidadRep" aria-describedby="basic-addon1" />
            </div>
        </div>
        <div class="row justify-content-center">
            <asp:DropDownList ID="drpMantenimientoId" AutoPostBack="true" CssClass="text-center form-control list-group-horizontal list-group-item-action size" runat="server">
                <asp:ListItem Text="Seleccione un id de mantenimiento" />
            </asp:DropDownList>
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
        <div class="row justify-content-center">
            <asp:DropDownList ID="drpFacturaID" AutoPostBack="true" CssClass="text-center form-control list-group-horizontal list-group-item-action size" runat="server">
                <asp:ListItem Text="Seleccione un ID de factura" />
            </asp:DropDownList>
        </div>
        <br />
        <div class="Centrar-Medio">
            <asp:Button runat="server" ID="btnInsertarDet" CssClass="btn btn-info" Text="Insertar" />
            <asp:Button runat="server" ID="btnActualizarDet" CssClass="btn btn-info" Text="Actualizar" />
        </div>
        <br />
        <h5 class="Centrar-Medio">Si desea actualizar el detalle de la factura debe copiar su ID</h5>
        <br />
        <div class="row justify-content-center">
            <asp:DropDownList ID="drpIdDetalle" AutoPostBack="true" CssClass="text-center form-control list-group-horizontal list-group-item-action size" runat="server">
                <asp:ListItem Text="Seleccione un ID" />
            </asp:DropDownList>
            <br />
            <asp:Panel runat="server" Visible="true" ID="pnlDetalles" CssClass="tablaDetalles">
                <asp:GridView runat="server" ID="gvDetalles">
                </asp:GridView>
            </asp:Panel>
        </div>
        <img src="../img/imageedit_3_5509983854.png" class="logPosicionGen" />
    </form>
</body>
</html>

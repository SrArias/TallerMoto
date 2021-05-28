<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="prjtallermotos.Admin.Clientes" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <link href="../css/styleAdmin.css" rel="stylesheet" />
    <title>Cliente</title>
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
            <h1>Clientes</h1>
        </div>
        <br />
        <div class="row justify-content-center">
            <div class="input-group mb-3 Centrar-Medio size ">
                <div class="input-group-prepend">
                    <span class="input-group-text">ID</span>
                </div>
                <input type="number" runat="server" id="txtIdCliente" class="form-control" aria-label="IdCliente" aria-describedby="basic-addon1" />
            </div>
        </div>
        <div class="row justify-content-center">
            <div class="input-group mb-3 Centrar-Medio size">
                <div class="input-group-prepend">
                    <span class="input-group-text" id="basic-addon2">Nombre</span>
                </div>
                <input type="text" onclick="" runat="server" id="txtNombreCl" class="form-control" aria-label="Nombre" aria-describedby="basic-addon1" />
            </div>
        </div>
        <div class="row justify-content-center">
            <div class="input-group mb-3 Centrar-Medio size">
                <div class="input-group-prepend">
                    <span class="input-group-text">Teléfono</span>
                </div>
                <input type="text" onclick="" runat="server" id="txtTelefonoCl" class="form-control" aria-label="Telefono" aria-describedby="basic-addon1" />
            </div>
        </div>
        <div class="row justify-content-center">
            <div class="input-group mb-3 Centrar-Medio size">
                <div class="input-group-prepend">
                    <span class="input-group-text">Dirección</span>
                </div>
                <input type="text" onclick="" runat="server" id="txtDireccionCl" class="form-control" aria-label="Dirección" aria-describedby="basic-addon1" />
            </div>
        </div>
        <br />
        <div class="row justify-content-center">
            <asp:DropDownList ID="drpPlaca" AutoPostBack="true" CssClass="text-center form-control list-group-horizontal list-group-item-action size" runat="server">                
            </asp:DropDownList>
        </div>
        <br />
        <div class="Centrar-Medio">
            <asp:Button runat="server" ID="btnInsertarCli" CssClass="btn btn-info" Text="Insertar" OnClick="btnInsertarCli_Click" />
            <asp:Button runat="server" ID="btnActualizarCli" CssClass="btn btn-info" Text="Actualizar" />
        </div>
        <br />
        <h5 class="Centrar-Medio">Si desea actualizar un cliente debe seleccionar su ID</h5>
        <br />
        <div class="row justify-content-center">
            <asp:DropDownList ID="drpClientes" AutoPostBack="true" CssClass="text-center form-control list-group-horizontal list-group-item-action size" runat="server" OnSelectedIndexChanged="drpClientes_SelectedIndexChanged1">                
            </asp:DropDownList>
        </div>
        <br />
        <asp:Panel runat="server" Visible="true" ID="pnlCliente" CssClass="tablaCliente Centrar-Medio">
            <asp:GridView runat="server" ID="gvClientes">
            </asp:GridView>
        </asp:Panel>
        <img src="../img/imageedit_3_5509983854.png" class="logPosicionGen" />
    </form>
</body>
</html>

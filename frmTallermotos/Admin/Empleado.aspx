﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Empleado.aspx.cs" Inherits="prjtallermotos.Admin.Empleado" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <link href="../css/styleAdmin.css" rel="stylesheet" />
    <title>Empleados</title>
</head>
<body>
    <form id="form" runat="server">
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
            <asp:ImageButton runat="server" ID="logout_new" ImageUrl="~/img/image_icon_logout_pic_512x512.png" OnClick="logout_new_Click" style="margin-top:95%"/>
        </div>
        <div class="Centrar-Medio">
            <h1>Empleados</h1>
        </div>
        <br />
        <div class="row justify-content-center">
            <div class="input-group mb-3 Centrar-Medio size ">
                <div class="input-group-prepend">
                    <span class="input-group-text" id="basic-addon1">ID</span>
                </div>
                <input type="number" runat="server" id="txtIdEmpleado" class="form-control" aria-label="IDempleado" aria-describedby="basic-addon1" />
            </div>
        </div>
        <div class="row justify-content-center">
            <div class="input-group mb-3 Centrar-Medio size">
                <div class="input-group-prepend">
                    <span class="input-group-text" id="basic-addon2">Nombre</span>
                </div>
                <input type="text" onclick="" runat="server" id="txtNombre" class="form-control" aria-label="Nombre" aria-describedby="basic-addon1" />
            </div>
        </div>
        <div class="row justify-content-center">
            <div class="input-group mb-3 Centrar-Medio size">
                <div class="input-group-prepend">
                    <span class="input-group-text">Teléfono</span>
                </div>
                <input type="text" onclick="" runat="server" id="txtTelefono" class="form-control" aria-label="Telefono" aria-describedby="basic-addon1" />
            </div>
        </div>
        <div class="row justify-content-center">
            <div class="input-group mb-3 Centrar-Medio size">
                <div class="input-group-prepend">
                    <span class="input-group-text">Dirección</span>
                </div>
                <input type="text" onclick="" runat="server" id="txtDireccion" class="form-control" aria-label="Dirección" aria-describedby="basic-addon1" />
            </div>
        </div>
        <div class="row justify-content-center">
            <div class="input-group mb-3 Centrar-Medio size">
                <div class="input-group-prepend">
                    <span class="input-group-text">Salario</span>
                </div>
                <input type="number" onclick="" runat="server" id="txtSalario" class="form-control" placeholder="$" aria-label="Salario" aria-describedby="basic-addon1" />
            </div>
        </div>
        <div class="row justify-content-center">
            <asp:DropDownList ID="drpCargo" AutoPostBack="true" CssClass="text-center form-control list-group-horizontal list-group-item-action size  " runat="server">
                <asp:ListItem Text="Seleccione el cargo" />
                <asp:ListItem Text="Mecánico" />
                <asp:ListItem Text="Administrador" />
            </asp:DropDownList>
        </div>
        <br />
        <div class="row justify-content-center">
            <asp:DropDownList ID="drpTurno" AutoPostBack="true" CssClass="text-center form-control list-group-horizontal list-group-item-action size" runat="server">
                <asp:ListItem Text="Seleccione el turno" />
                <asp:ListItem Text="6-8" />
                <asp:ListItem Text="2-6" />
            </asp:DropDownList>
        </div>
        <br />
        <div class="Centrar-Medio">
            <asp:Button runat="server" ID="btnInsertarEmp" CssClass="btn btn-info" Text="Insertar" OnClick="btnInsertarEmp_Click" />
            <asp:Button runat="server" ID="btnActualizarEmp" CssClass="btn btn-info" Text="Actualizar" Enabled="false" OnClick="btnActualizarEmp_Click" />
            <asp:Button runat="server" ID="btnLimpiar" CssClass="btn btn-info" Text="Limpiar" OnClick="btnLimpiar_Click" />
        </div>
        <br />
        <h5 class="Centrar-Medio">Seleccione el nombre del empleado para actualizar sus datos</h5>
        <div class="row justify-content-center">
            <div class="input-group mb-3 Centrar-Medio size">
                <div class="input-group-prepend">
                    <span class="input-group-text">Empleado</span>
                </div>
                <asp:DropDownList ID="drpIdEmpleado" AutoPostBack="true" CssClass="text-center form-control list-group-horizontal list-group-item-action size" runat="server" OnSelectedIndexChanged="drpIdEmpleado_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
        </div>
        <br />
        <asp:Panel runat="server" Visible="true" ID="pnlEmpleado" CssClass="Centrar-Medio">
            <asp:GridView runat="server" ID="gvEmpleados">
            </asp:GridView>
        </asp:Panel>
        <img src="../img/imageedit_3_5509983854.png" class="logPosicionEmp" />
        <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11.0.11/dist/sweetalert2.all.min.js"></script>
        <script src="../js/sweetalert.js" type="text/javascript"></script>
    </form>
</body>
</html>

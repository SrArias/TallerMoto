<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCliente.aspx.cs" Inherits="frmTallermotos.frmCliente" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/styleCliente.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <title>Usuarios</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="jumbotron jumbotron-fluid propjumbo" style="height: 20px">
                <div class="container" style="margin-top: -30px">
                    <img src="img/MicrosoftTeams-image%20(2).png" style="margin-top: -1%; margin-left: -13%" />
                    <h2 class="lead" style="margin-left: -7%">¡Bienvenido! Consulte su historial</h2>
                    <img src="img/logout.png" style="margin-left: 105%; margin-top: -11.5%; height: 110px; width: 110px" />
                </div>
            </div>
            <div class="containerOptions" style="background-color: #41626a; width: 100%; height: 10%; margin-left: 0%; margin-top: -4%">
                <asp:RadioButtonList runat="server" AutoPostBack="true" ID="rdlOpciones" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdlOpciones_SelectedIndexChanged" ForeColor="White" CssClass="Centrar-Medio">
                    <asp:ListItem  class="rdbConsultar" Value="opcMantenimiento" Text="Mantenimiento"></asp:ListItem>
                    <asp:ListItem class="rdbRegistrar" Value="opcFactura" Text="Factura"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <br />
            <br />
            <br />
            <asp:Panel runat="server" ID="pnlMantenimiento" Visible="true" CssClass="Centrar-Medio">
                <asp:GridView runat="server" ID="gvmantenimiento"></asp:GridView>
            </asp:Panel>
            <asp:Panel runat="server" Visible="false" ID="pnlFactura" CssClass="Centrar-Medio">
                <asp:GridView runat="server" ID="gvFactura"></asp:GridView>
            </asp:Panel>
            <br />
            <div class="card-group">
                <div class="card">
                    <img src="img/moto111.jpg" class="card-img-top" style="height: 318px" />
                    <div class="card-body">
                        <p class="card-text">"Busqué mi libertad en todos lados, y la encontré justo aquí...sobre mi motocicleta"</p>
                    </div>
                </div>
                <div class="card">
                    <img src="img/moto222.jpg" class="card-img-top" />
                    <div class="card-body">
                        <p class="card-text">"Puedes confiar en in biker porque dice lo que piensa y hace lo que siente".</p>
                    </div>
                </div>
                <div class="card">
                    <img src="img/moto333.jpg" class="card-img-top" />
                    <div class="card-body">
                        <p class="card-text">No importa la moto que conduzcas, importa la manera de vivirla...</p>
                        <p class="card-text" style="margin-left: 70%"><i><b>#MotorcycleLover</b></i></p>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

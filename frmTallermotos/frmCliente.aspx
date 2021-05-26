<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCliente.aspx.cs" Inherits="frmTallermotos.frmCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/styleCliente.css" rel="stylesheet" />
       <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

              <div >


<div class="jumbotron jumbotron-fluid propjumbo">
  <div class="container">
    <h1 class="display-4">Taller de motos</h1>
    <h2 class="lead">¡Bienvenido! Consulte su historial</h2>
      <img src="img/imageedit_3_5509983854.png" class="imglogo"/>
  </div>
</div>
                    <br />
                    <br />
             
                  <img src="img/580b585b2edbce24c47b2d08.png" class="imgCliente"/>
                
                  <div class="containerOptions ">
            <asp:RadioButtonList runat="server" AutoPostBack="true" ID="rdlOpciones" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdlOpciones_SelectedIndexChanged">

                
                <asp:ListItem Selected="True" class="rdbConsultar" Value="opcMantenimiento" Text="Mantenimiento"></asp:ListItem>
                

                <asp:ListItem class="rdbRegistrar" Value="opcFactura" Text="Factura"></asp:ListItem>
            </asp:RadioButtonList>

        </div>




      

                  <br />
                  <br />
                  <br />
  

                 

            <asp:Panel runat="server" Visible="false" ID="pnlMantenimiento" CssClass="tablaMant">
                <asp:GridView runat="server" ID="gvmantenimiento">
                    <HeaderStyle CssClass="thead-dark" />
                </asp:GridView>
            </asp:Panel>



            <asp:Panel runat="server" Visible="false" ID="pnlFactura" CssClass="tablaFactura">
                <asp:GridView runat="server" ID="gvFactura">                    
                </asp:GridView>
            </asp:Panel>

        </div>
    </form>
</body>
</html>

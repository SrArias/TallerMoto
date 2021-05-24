<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="frmTallermotos.frmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <link href="css/style.css" rel="stylesheet" />
    <title></title>
</head>
<body >


        <form id="form1" runat="server">


            <div class="card bg-dark text-white sizeimg">
  
  <div class="card-img-overlay">
 
       
      <div class="form1" runat="server" >

          <h1 class="Centrar-Medio">Taller de motos</h1>
          <br />
          <h4 class="Centrar-Medio">Inicio de sesión</h4>

       <div class="row justify-content-center">         
        <div class="input-group mb-3 Centrar-Medio size " >
          <div class="input-group-prepend">
              <span class="input-group-text" id="basic-addon1" >@</span>
          </div>
           <input type="number" runat="server" id="txtusername" class="form-control" placeholder="Username" aria-label="Username" aria-describedby="basic-addon1"/>  
          </div>
        </div>  


       <div class="row justify-content-center">
        <div class="input-group mb-3 Centrar-Medio size" >
          <div class="input-group-prepend">
          <span class="input-group-text" id="basic-addon2">#</span>
          </div>
          <input type="password" onclick="" runat="server" id="txtpassword" class="form-control" placeholder="Password" aria-label="Username" aria-describedby="basic-addon1"/>  
        </div>
       </div>
          
         <br />

        <div class="Centrar-Medio">            
            <asp:Button  runat="server" ID="btn" CssClass="btn btn-info" Text="Ingresar" OnClick="btn_Click"/>
        </div>

          <br />
          <br />

</div>
  </div>
</div>
       
        

    </form>



    
</body>
</html>

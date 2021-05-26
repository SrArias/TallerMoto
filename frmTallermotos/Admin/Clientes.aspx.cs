using LibOperativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjtallermotos.Admin
{
    public partial class Clientes : System.Web.UI.Page
    {
        clsllenarope objcontroles;
        clsadminop objadmin;
        private string strnombreapp;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                strnombreapp = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
                objcontroles = new clsllenarope(strnombreapp);
                objadmin = new clsadminop(strnombreapp);
                if (!IsPostBack)
                {
                   
                    if (!objcontroles.llenarGrid(gvClientes))
                    {
                        return;
                    }
                   
                    if (!objcontroles.llenarDrop(drpPlaca))
                    {
                        return;
                    }
                    
                    if (!objcontroles.llenarDrop(drpClientes))
                    {
                        return;
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void drpClientes_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {
                objadmin.IntUsuario_id = int.Parse(drpClientes.SelectedItem.Value);
                if (!objadmin.getone_cliente())
                {
                    objadmin = null;
                    Response.Write($"<script>alert('{objadmin.StrError}')</script>");
                    return;
                }
                txtIdCliente.Disabled = true;
                //btnInsertarEmp.Enabled = true;
                txtIdCliente.Value = objadmin.IntUsuario_id.ToString();
                txtDireccionCl.Value = objadmin.StrDireccionC;
                txtNombreCl.Value = objadmin.StrNombreC;
                txtTelefonoCl.Value = objadmin.StrTelefonoC;
            }

            catch (Exception)
            {

                throw;
            }

        }
    }
}
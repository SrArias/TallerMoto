using LibOperativa;
using System;
using System.Reflection;

namespace prjtallermotos.Admin
{
    public partial class Clientes : System.Web.UI.Page
    {
        #region "Atributos"
        private string strnombreapp;
        #endregion

        #region "Instancias"
        clsllenarope objcontroles;
        clsadminop objadmin;
        #endregion

        #region "Métodos Privados"
        private void Recargar_grid()
        {
            if (!objcontroles.llenarGrid(gvClientes))
            {
                return;
            }
        }
        #endregion

        #region "Eventos"
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                strnombreapp = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
                objcontroles = new clsllenarope(strnombreapp);
                objadmin = new clsadminop(strnombreapp);
                btnActualizarCli.Enabled = false;
                Recargar_grid();
                if (!IsPostBack)
                {              
                 

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
                btnInsertarCli.Enabled = false;
                btnActualizarCli.Enabled = true;
                txtIdCliente.Value = objadmin.IntUsuario_id.ToString();
                txtDireccionCl.Value = objadmin.StrDireccionC;
                txtNombreCl.Value = objadmin.StrNombreC;
                txtTelefonoCl.Value = objadmin.StrTelefonoC;
                if (!objadmin.getone_vehiculo())
                {
                    objadmin = null;
                    Response.Write($"<script>alert('{objadmin.StrError}')</script>");
                    return;
                }
            }

            catch (Exception)
            {

                throw;
            }

        }

        #endregion

        protected void btnActualizarCli_Click(object sender, EventArgs e)
        {
            //objadmin.IntUsuario_id = int.Parse(txtIdCliente.Value.Trim());
            //objadmin.StrDireccionC = txtDireccionCl.Value.Trim();
            //objadmin.StrNombreC = txtNombreCl.Value.Trim();
            //objadmin.StrTelefonoC = txtTelefonoCl.Value.Trim();
            //objadmin.StrVehiculo_id = drpPlaca.SelectedItem.Value;
            //if (!objadmin.())
            //{
            //    objadmin = null;
            //    Response.Write($"<script>alert('{objadmin.StrError}')</script>");
            //    return;
            //}
            //Response.Write($"<script>alert('{objadmin.Resultado}')</script>");
        }

        protected void btnInsertarCli_Click(object sender, EventArgs e)
        {
            try
            {
                objadmin.IntUsuario_id = int.Parse(txtIdCliente.Value.Trim());
                objadmin.StrDireccionC = txtDireccionCl.Value.Trim();
                objadmin.StrNombreC = txtNombreCl.Value.Trim();
                objadmin.StrTelefonoC = txtTelefonoCl.Value.Trim();
                objadmin.StrVehiculo_id = drpPlaca.SelectedItem.Value;
                if (!objadmin.Ingresar_Usuario())
                {
                    objadmin = null;
                    Response.Write($"<script>alert('{objadmin.StrError}')</script>");
                    return;
                }
                Response.Write($"<script>alert('{objadmin.Resultado}')</script>");
                Recargar_grid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
using LibOperativa;
using System;
using System.Reflection;
using System.Web.UI;

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
        private void RecargarControles()
        {
            if (!IsPostBack)
            {
                if (!objcontroles.llenarGrid(gvClientes))
                {
                    mensajes("error", objcontroles.StrError);
                    return;
                }
                if (!objcontroles.llenarDrop(drpPlaca))
                {
                    mensajes("error", objcontroles.StrError);
                    return;
                }

                if (!objcontroles.llenarDrop(drpClientes))
                {
                    mensajes("error", objcontroles.StrError);
                    return;
                }
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
                RecargarControles();
            }
            catch (Exception ex)
            {

                mensajes("error", ex.Message);
            }
        }
        private void mensajes(string tipo, string mensajes)
        {
            string javaScript = $"mensajes('{tipo}','{mensajes}');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
        }

        private bool validar(string MetodoOrigen)
        {
            switch (MetodoOrigen.ToLower())
            {
                case "getonecliente":
                    if (drpClientes.SelectedIndex == 0)
                    {
                        mensajes("error", "Debe seleccionar un cliente");
                        return false;
                    }
                    break;
                case "insertcliente":
                    if (txtIdCliente.Value.Trim() == string.Empty)
                    {
                        mensajes("error", "Debe ingresar una id de cliente");
                        return false;
                    }
                    if (txtNombreCl.Value.Trim() == string.Empty)
                    {
                        mensajes("error", "Debe ingresar un nombre de cliente");
                        return false;
                    }
                    if (txtDireccionCl.Value.Trim() == string.Empty)
                    {
                        mensajes("error", "Debe ingresar una dirección");
                        return false;
                    }
                    if (txtTelefonoCl.Value.Trim() == string.Empty)
                    {
                        mensajes("error", "Debe ingresar un número de teléfono");
                        return false;
                    }
                    break;
                case "updatecliente":

                    if (drpClientes.SelectedIndex == 0)
                    {
                        mensajes("error", "Debe seleccionar un cliente");
                        return false;
                    }
                    if (txtIdCliente.Value.Trim() == string.Empty)
                    {
                        mensajes("error", "Debe ingresar una id de cliente");
                        return false;
                    }
                    if (txtNombreCl.Value.Trim() == string.Empty)
                    {
                        mensajes("error", "Debe ingresar un nombre de cliente");
                        return false;
                    }
                    if (txtDireccionCl.Value.Trim() == string.Empty)
                    {
                        mensajes("error", "Debe ingresar una dirección");
                        return false;
                    }
                    if (txtTelefonoCl.Value.Trim() == string.Empty)
                    {
                        mensajes("error", "Debe ingresar un número de teléfono");
                        return false;
                    }
                    break;
                default:
                    break;

            }
            return true;
        }
        protected void drpClientes_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {
                if (!validar("getonecliente"))
                {
                    return;
                }
                objadmin.IntUsuario_id = int.Parse(drpClientes.SelectedItem.Value);
                if (!objadmin.getone_cliente())
                {
                    objadmin = null;
                    mensajes("error", objadmin.StrError);
                    return;
                }
                txtIdCliente.Disabled = true;
                btnInsertarCli.Enabled = false;
                btnActualizarCli.Enabled = true;
                txtIdCliente.Value = objadmin.IntUsuario_id.ToString();
                txtDireccionCl.Value = objadmin.StrDireccionC;
                txtNombreCl.Value = objadmin.StrNombreC;
                txtTelefonoCl.Value = objadmin.StrTelefonoC;

            }

            catch (Exception ex)
            {

                mensajes("error", ex.Message);
            }

        }

        #endregion

        protected void btnActualizarCli_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validar("updatecliente"))
                {
                    return;
                }

                objadmin.IntUsuario_id = int.Parse(txtIdCliente.Value.Trim());
                objadmin.StrDireccionC = txtDireccionCl.Value.Trim();
                objadmin.StrNombreC = txtNombreCl.Value.Trim();
                objadmin.StrTelefonoC = txtTelefonoCl.Value.Trim();
                objadmin.StrVehiculo_id = drpPlaca.SelectedItem.Value;
                if (!objadmin.Actualizar_Usuario()) 
                {
                    objadmin = null;
                    mensajes("error", objadmin.StrError); 
                    return;
                }
                mensajes("success", objadmin.Resultado);
                RecargarControles();
            }
            catch (Exception ex)
            {

                mensajes("error",ex.Message);
            }
        }

        protected void btnInsertarCli_Click(object sender, EventArgs e)
        {
            try
            {

                if (!validar("insertcliente"))
                {
                    return;
                }
                objadmin.IntUsuario_id = int.Parse(txtIdCliente.Value.Trim());
                objadmin.StrDireccionC = txtDireccionCl.Value.Trim();
                objadmin.StrNombreC = txtNombreCl.Value.Trim();
                objadmin.StrTelefonoC = txtTelefonoCl.Value.Trim();
                objadmin.StrVehiculo_id = drpPlaca.SelectedItem.Value;
                if (!objadmin.Ingresar_Usuario())
                {
                    objadmin = null;
                    mensajes("error", objadmin.StrError);
                    return;
                }
                mensajes("success", objadmin.Resultado);
                RecargarControles();
            }
            catch (Exception ex)
            {
                mensajes("error", ex.Message);
            }

        }
    }
}
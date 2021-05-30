using LibOperativa;
using System;
using System.Reflection;
using System.Web.UI;

namespace prjtallermotos.Admin
{
    public partial class Vehiculos : System.Web.UI.Page
    {
        #region "Instancias"
        clsllenarope objcontroles;
        clsadminop objadmin;
        private string strnombreapp;
        #endregion

        #region "Métodos Privados"

        private void Limpiar()
        {
            txtIdVehiculo.Disabled = false;
            btnInsertarVeh.Enabled = true;
            btnActualizarVeh.Enabled = false;
            txtIdVehiculo.Value = string.Empty;
            txtMarca.Value = string.Empty;
            txtCilindraje.Value = string.Empty;
            txtModelo.Value = string.Empty;
            txtColor.Value = string.Empty;
            txtReferencia.Value = string.Empty;
            drpIdVehiculo.DataSource = null;
            drpIdVehiculo.Items.Clear();
            RecargarControles();
        }

        private void RecargarControles()
        {

            if (!objcontroles.llenarGrid(gvVehic))
            {
                mensajes("error", objcontroles.StrError);
                return;
            }
            if (!objcontroles.llenarDrop(drpIdVehiculo))
            {
                mensajes("error", objcontroles.StrError);
                return;
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
                case "getonevehiculo":
                    if (drpIdVehiculo.SelectedIndex == 0)
                    {
                        mensajes("error", "Debe seleccionar un vehículo");
                        return false;
                    }
                    break;

                case "insertvehiculo":
                    if (txtIdVehiculo.Value.Trim() == string.Empty)
                    {
                        mensajes("error", "Debe ingresar la placa de la moto");
                        return false;
                    }

                    if (txtMarca.Value.Trim() == string.Empty)
                    {
                        mensajes("error", "Debe ingresar una marca de la moto");
                        return false;
                    }
                    if (txtCilindraje.Value.Trim() == string.Empty)
                    {
                        mensajes("error", "Debe ingresar el cilindraje de la moto");
                        return false;
                    }
                    if (txtModelo.Value.Trim() == string.Empty)
                    {
                        mensajes("error", "Debe ingresar el modelo de la moto");
                        return false;
                    }
                    if (txtColor.Value.Trim() == string.Empty)
                    {
                        mensajes("error", "Debe ingresar el color de la moto");
                        return false;
                    }
                    if (txtReferencia.Value.Trim() == string.Empty)
                    {
                        mensajes("error", "Debe ingresar la referencia de la moto");
                        return false;
                    }
                    break;
                case "updatevehiculo":

                    if (drpIdVehiculo.SelectedIndex == 0)
                    {
                        mensajes("error", "Debe seleccionar un vehículo de la moto");
                        return false;
                    }
                    if (txtIdVehiculo.Value.Trim() == string.Empty)
                    {
                        mensajes("error", "Debe ingresar la placa de la moto");
                        return false;
                    }
                    if (txtMarca.Value.Trim() == string.Empty)
                    {
                        mensajes("error", "Debe ingresar una marca de la moto");
                        return false;
                    }
                    if (txtCilindraje.Value.Trim() == string.Empty)
                    {
                        mensajes("error", "Debe ingresar el cilindraje de la moto");
                        return false;
                    }
                    if (txtModelo.Value.Trim() == string.Empty)
                    {
                        mensajes("error", "Debe ingresar el modelo de la moto");
                        return false;
                    }
                    if (txtColor.Value.Trim() == string.Empty)
                    {
                        mensajes("error", "Debe ingresar el color de la moto");
                        return false;
                    }
                    if (txtReferencia.Value.Trim() == string.Empty)
                    {
                        mensajes("error", "Debe ingresar la referencia de la moto");
                        return false;
                    }
                    break;
                default:
                    break;

            }
            return true;
        }
        private void Insertar()
        {
            try
            {
                if (!validar("insertvehiculo"))
                {
                    return;
                }

                objadmin.StrVehiculo_id = txtIdVehiculo.Value.Trim();
                objadmin.StrMarca = txtMarca.Value.Trim();
                objadmin.StrCilindraje = txtCilindraje.Value.Trim();
                objadmin.IntModelo = int.Parse(txtModelo.Value.Trim());
                objadmin.StrColor = txtColor.Value.Trim();
                objadmin.StrRefencia = txtReferencia.Value.Trim();

                if (!objadmin.Ingresar_Vehiculo())
                {

                    objadmin = null;
                    mensajes("error", objadmin.StrError);
                    return;
                }
                mensajes("success", objadmin.Resultado);
                Limpiar();
            }
            catch (Exception ex)
            {
                mensajes("error", ex.Message);
            }
        }
        private void Actualizar()
        {
            try
            {
                if (!validar("updatevehiculo"))
                {
                    return;
                }

                objadmin.StrVehiculo_id = txtIdVehiculo.Value.Trim();
                objadmin.StrMarca = txtMarca.Value.Trim();
                objadmin.StrCilindraje = txtCilindraje.Value.Trim();
                objadmin.IntModelo = int.Parse(txtModelo.Value.Trim());
                objadmin.StrColor = txtColor.Value.Trim();
                objadmin.StrRefencia = txtReferencia.Value.Trim();

                if (!objadmin.Actualizar_Vehiculo())
                {

                    objadmin = null;
                    mensajes("error", objadmin.StrError);
                    return;
                }
                mensajes("success", objadmin.Resultado);
                Limpiar();
            }
            catch (Exception ex)
            {
                mensajes("error", ex.Message);
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
            btnActualizarVeh.Enabled = false;
                if (!IsPostBack)
                {
                    RecargarControles();
                }
            
            }
            catch (Exception ex)
            {

                mensajes("error", ex.Message);
            }

        }

        protected void drpIdVehiculo_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {
                if (!validar("getonevehiculo"))
                {
                    return;
                }

                objadmin.StrVehiculo_id = drpIdVehiculo.SelectedItem.Value;

                if (!objadmin.getone_vehiculo())
                {
                    objadmin = null;
                    mensajes("error", objadmin.StrError);
                    return;
                }

                txtIdVehiculo.Disabled = true;
                btnActualizarVeh.Enabled = true;
                btnInsertarVeh.Enabled = false;
                txtIdVehiculo.Value = objadmin.StrVehiculo_id;
                txtMarca.Value = objadmin.StrMarca;
                txtCilindraje.Value = objadmin.StrCilindraje;
                txtModelo.Value = objadmin.IntModelo.ToString();
                txtColor.Value = objadmin.StrColor;
                txtReferencia.Value = objadmin.StrRefencia;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void btnInsertarVeh_Click(object sender, EventArgs e)
        {
            Insertar();
        }

        protected void btnActualizarVeh_Click(object sender, EventArgs e)
        {

            Actualizar();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        #endregion
    }
}
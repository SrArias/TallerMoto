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
    public partial class Vehiculos : System.Web.UI.Page
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
            btnActualizarVeh.Enabled = false;
            Recargar_grid();
            if (!IsPostBack)
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
                case "getonevehiculo":
                    if (drpIdVehiculo.SelectedIndex == 0)
                    {
                        mensajes("error", "Debe seleccionar un vehículo");
                        return false;
                    }
                    break;

                case "insertvehiculo":
                case "updatevehiculo":

                    if (drpIdVehiculo.SelectedIndex == 0)
                    {
                        mensajes("error", "Debe seleccionar un vehículo de la moto");
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
                //btnInsertarEmp.Enabled = true;
                txtIdVehiculo.Value = objadmin.StrVehiculo_id;
                txtMarca.Value = objadmin.StrMarca;
                txtCilindraje.Value = objadmin.StrCilindraje;
                txtModelo.Value = objadmin.IntModelo.ToString();
                txtColor.Value = objadmin.StrColor;
                txtReferencia.Value = objadmin.StrRefencia;

                if (!objadmin.getone_vehiculo())
                {
                    objadmin = null;
                    mensajes("error", objadmin.StrError);
                    return;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        private void Recargar_grid()
        {
            if (!objcontroles.llenarGrid(gvVehic))
            {
                mensajes("error", objcontroles.StrError);
                return;
            }
        }



        protected void btnInsertarVeh_Click(object sender, EventArgs e)
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
                Recargar_grid();
            }
            catch (Exception ex)
            {
                mensajes("error", ex.Message);
            }
        }
    }
}
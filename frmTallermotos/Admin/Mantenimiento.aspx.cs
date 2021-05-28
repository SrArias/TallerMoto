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
    public partial class Mantenimiento : System.Web.UI.Page
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

                    if (!objcontroles.llenarDrop(drpIdMantenim))
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
                case "getonemantenimiento":
                    if (drpIdMantenim.SelectedIndex == 0)
                    {
                        mensajes("error", "Debe seleccionar una placa");
                        return false;
                    }
                    break;
                case "insertmantenimiento":
                    if (drpIdEmpleado.SelectedIndex == 0)
                    {
                        mensajes("error", "Debe seleccionar un empleado");
                        return false;
                    }
                    if (txtDiagnostico.Value.Trim() == string.Empty)
                    {
                        mensajes("error", "Debe ingresar el diagnóstico");
                        return false;
                    }
                    if (txtProcRealiz.Value.Trim() == string.Empty)
                    {
                        mensajes("error", "Debe ingresar el proceso reliazado");
                        return false;
                    }
                    break;
                case "updatemantenimiento":
                    if (txtidmantenimiento.Value.Trim()== string.Empty)
                    {
                        mensajes("error", "Debe seleccionar un ID mantenimiento");
                        return false;
                    }

                    if (drpIdMantenim.SelectedIndex == 0)
                    {
                        mensajes("error", "Debe seleccionar una placa");
                        return false;
                    }
                    if (drpIdEmpleado.SelectedIndex == 0)
                    {
                        mensajes("error", "Debe seleccionar un empleado");
                        return false;
                    }
                    if (txtDiagnostico.Value.Trim() == string.Empty)
                    {
                        mensajes("error", "Debe ingresar el diagnóstico");
                        return false;
                    }
                    if (txtProcRealiz.Value.Trim() == string.Empty)
                    {
                        mensajes("error", "Debe ingresar el proceso reliazado");
                        return false;
                    }
                   
                    break;
                default:
                    break;

            }
            return true;
        }
        protected void drpIdMantenim_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!validar("getonemantenimiento"))
                {
                    return;
                }
                objcontroles.Vehiculo = drpIdMantenim.SelectedItem.Value;
                
                if (!objcontroles.llenarGrid(gvMantenimiento))
                {
                    objadmin = null;
                    mensajes("error", objcontroles.StrError);
                    return;
                }

                if (!objcontroles.llenarDrop(drpIdEmpleado))
                {
                    mensajes("error", objcontroles.StrError);
                    return;
                }

                btnInsertarMant.Enabled = false;
                drpIdVehiculo.Enabled = false;
                idman.Visible = true;
                drpIdVehiculo.SelectedItem.Text = objcontroles.Vehiculo;
                txtDiagnostico.Value = objadmin.StrDiagnostico;
                txtProcRealiz.Value = objadmin.StrProc_Realizado;
             
            }
            catch (Exception ex)
            {
                mensajes("error",ex.Message);
            }

        }

        private void Recargar_grid()
        {
            if (!objcontroles.llenarGrid(gvMantenimiento))
            {
                mensajes("error", objcontroles.StrError);
                return;
            }
        }

        protected void btnInsertarMant_Click(object sender, EventArgs e)
        {

            try
            {
                if (!validar("insertmantenimiento"))
                {
                    return;
                }

                objadmin.StrDiagnostico = txtDiagnostico.Value.Trim();
                objadmin.StrProc_Realizado = txtProcRealiz.Value.Trim();
                objadmin.StrVehiculo_id = drpIdVehiculo.SelectedItem.Value.ToString();//correguir
                objadmin.IntEmpleado_id = int.Parse(drpIdEmpleado.SelectedItem.Value);



                if (!objadmin.Ingresar_Empleado())
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

        protected void btnActualizarMant_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validar("updatemantenimiento"))
                {
                    return;
                }

                objadmin.StrDiagnostico = txtDiagnostico.Value.Trim();
                objadmin.StrProc_Realizado = txtProcRealiz.Value.Trim();
                objadmin.StrVehiculo_id = drpIdVehiculo.SelectedItem.Value.ToString();//correguir
                objadmin.IntEmpleado_id = int.Parse(drpIdEmpleado.SelectedItem.Value);
                objadmin.IntMantenimiento_id = int.Parse(txtidmantenimiento.Value.ToString());


                objcontroles.Vehiculo= drpIdVehiculo.SelectedItem.Value.ToString(); 
                if (!objadmin.Actualizar_Mantenimiento())
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
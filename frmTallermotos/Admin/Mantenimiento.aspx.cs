using LibOperativa;
using System;
using System.Reflection;
using System.Web.UI;

namespace prjtallermotos.Admin
{
    public partial class Mantenimiento : System.Web.UI.Page
    {
        #region "Instancias"
        clsllenarope objcontroles;
        clsadminop objadmin;
        private string strnombreapp;
        #endregion

        #region "Métodos Privados"

        private void Limpiar()
        {
            btnActualizarMant.Enabled = false;
            btnInsertarMant.Enabled = true;
            drpIdVehiculo.Enabled = true;
            txtDiagnostico.Value = string.Empty;
            txtProcRealiz.Value = string.Empty;
            idman.Visible = false;
            txtidmantenimiento.Value = string.Empty;
            drpIdVehiculo.DataSource = null;
            drpIdEmpleado.DataSource = null;
            drpIdMantenim.DataSource = null;
            drpIdVehiculo.Items.Clear();
            drpIdEmpleado.Items.Clear();
            drpIdMantenim.Items.Clear();
            RecargarControles();

        }

        private void Recargar_grid()
        {
            if (!objcontroles.llenarGrid(gvMantenimiento))
            {
                mensajes("error", objcontroles.StrError);
                return;
            }
        }
        private void RecargarControles()
        {

            if (!objcontroles.llenarDrop(drpIdMantenim))
            {
                mensajes("error", objcontroles.StrError);
                return;
            }
            if (!objcontroles.llenarDrop(drpIdVehiculo))
            {
                mensajes("error", objcontroles.StrError);
                return;
            }
            if (!objcontroles.llenarDrop(drpIdEmpleado))
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
                case "getonemantenimiento":
                    if (drpIdMantenim.SelectedIndex == 0)
                    {
                        mensajes("error", "Debe seleccionar una placa");
                        return false;
                    }
                    break;
                case "insertmantenimiento":
                    if (drpIdVehiculo.SelectedIndex == 0)
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
                        mensajes("error", "Debe ingresar el proceso realizado");
                        return false;
                    }
                    break;
                case "updatemantenimiento":
                    if (txtidmantenimiento.Value.Trim() == string.Empty)
                    {
                        mensajes("error", "Debe seleccionar un ID mantenimiento");
                        return false;
                    }
                    if (drpIdVehiculo.SelectedItem.Text == string.Empty)
                    {
                        mensajes("error", "Debe seleccionar una placa");
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
        private void Insertar()
        {

            try
            {
                if (!validar("insertmantenimiento"))
                {
                    return;
                }
                objadmin.StrVehiculo_id = drpIdVehiculo.SelectedItem.Value.ToString();
                objadmin.IntEmpleado_id = int.Parse(drpIdEmpleado.SelectedItem.Value);
                objadmin.StrDiagnostico = txtDiagnostico.Value.Trim();
                objadmin.StrProc_Realizado = txtProcRealiz.Value.Trim();

                if (!objadmin.Ingresar_Mantenimiento())
                {

                    objadmin = null;
                    mensajes("error", objadmin.StrError);
                    return;
                }
                mensajes("success", objadmin.Resultado);
                Recargar_grid();
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
                if (!validar("updatemantenimiento"))
                {
                    return;
                }

                objadmin.StrDiagnostico = txtDiagnostico.Value.Trim();
                objadmin.StrProc_Realizado = txtProcRealiz.Value.Trim();
                objadmin.StrVehiculo_id = drpIdVehiculo.SelectedItem.ToString();
                objadmin.IntEmpleado_id = int.Parse(drpIdEmpleado.SelectedItem.Value);
                objadmin.IntMantenimiento_id = int.Parse(txtidmantenimiento.Value.ToString());


                objcontroles.Vehiculo = drpIdVehiculo.SelectedItem.Value.ToString();
                if (!objadmin.Actualizar_Mantenimiento())
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

       
        protected void drpIdMantenim_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!validar("getonemantenimiento"))
                {
                    return;
                }
                objadmin.StrVehiculo_id = drpIdMantenim.SelectedItem.Value;
                

                if (!objadmin.getone_Mantenimiento(gvMantenimiento))
                {
                    objadmin = null;
                    mensajes("error", objcontroles.StrError);
                    return;
                }
                btnActualizarMant.Enabled = true;
                btnInsertarMant.Enabled = false;
                drpIdVehiculo.Enabled = false;
                idman.Visible = true;
                drpIdVehiculo.SelectedItem.Text = objadmin.StrVehiculo_id;
                drpIdEmpleado.SelectedItem.Text = objadmin.StrNombreE;
                txtDiagnostico.Value = objadmin.StrDiagnostico;
                txtProcRealiz.Value = objadmin.StrProc_Realizado;

             
            }
            catch (Exception ex)
            {
                mensajes("error",ex.Message);
            }

        }

        protected void btnInsertarMant_Click(object sender, EventArgs e)
        {
            Insertar();
        }

        protected void btnActualizarMant_Click(object sender, EventArgs e)
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
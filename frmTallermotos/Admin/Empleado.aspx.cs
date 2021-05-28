using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibOperativa;

namespace prjtallermotos.Admin
{
    public partial class Empleado : System.Web.UI.Page
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
                    
                    if (!objcontroles.llenarGrid(gvEmpleados))
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
                case "getoneempleado":
                    if (drpIdEmpleado.SelectedIndex == 0)
                    {
                        mensajes("error", "Debe seleccionar un cliente");
                        return false;
                    }
                    break;
                case "insertempleado":
                case "updateempleado":

                    if (drpIdEmpleado.SelectedIndex == 0)
                    {
                        mensajes("error", "Debe seleccionar un cliente");
                        return false;
                    }
                    if (txtIdEmpleado.Value.Trim() == string.Empty)
                    {
                        mensajes("error", "Debe ingresar una id de empleado");
                        return false;
                    }
                    if (txtNombre.Value.Trim() == string.Empty)
                    {
                        mensajes("error", "Debe ingresar un nombre de empleado");
                        return false;
                    }
                    if (txtDireccion.Value.Trim() == string.Empty)
                    {
                        mensajes("error", "Debe ingresar una dirección");
                        return false;
                    }
                    if (txtTelefono.Value.Trim() == string.Empty)
                    {
                        mensajes("error", "Debe ingresar un número de teléfono");
                        return false;
                    }
                    if (txtSalario.Value.Trim() == string.Empty)
                    {
                        mensajes("error", "Debe ingresar el salario");
                        return false;
                    }
                    if (drpCargo.SelectedIndex == 0)
                    {
                        mensajes("error", "Debe seleccionar un cargo");
                        return false;
                    }
                    if (drpTurno.SelectedIndex == 0)
                    {
                        mensajes("error", "Debe seleccionar un turno");
                        return false;
                    }
                    break;
                default:
                    break;

            }
            return true;
        }
        protected void drpIdEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!validar("getoneempleado"))
                {
                    return;
                }
                objadmin.IntEmpleado_id = int.Parse(drpIdEmpleado.SelectedItem.Value);
                if (!objadmin.getone_empleado())
                {
                    objadmin = null;
                    mensajes("error", objadmin.StrError);
                    return;
                }
                txtIdEmpleado.Disabled = true;
                btnInsertarEmp.Enabled = true;
                txtIdEmpleado.Value = objadmin.IntEmpleado_id.ToString();
                txtDireccion.Value = objadmin.StrDireccionE;
                txtNombre.Value = objadmin.StrNombreE;
                txtTelefono.Value = objadmin.StrTelefonoE;
                txtSalario.Value = objadmin.IntSalarioE.ToString();
                drpCargo.SelectedIndex = int.Parse(objadmin.IntCargo.ToString());
                drpTurno.SelectedIndex = int.Parse(objadmin.IntTurno.ToString());
            }
            catch (Exception ex)
            {

                mensajes("error", ex.Message);
            }

        }
        private void Recargar_grid()
        {
            if (!objcontroles.llenarGrid(gvEmpleados))
            {
                mensajes("error", objcontroles.StrError);
                return;
            }
        }
        protected void btnInsertarEmp_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validar("insertempleado"))
                {
                    return;
                }

                objadmin.IntEmpleado_id = int.Parse(txtIdEmpleado.Value.Trim());
                objadmin.StrNombreE = txtNombre.Value.Trim();
                objadmin.StrTelefonoE = txtTelefono.Value.Trim();
                objadmin.StrDireccionE = txtDireccion.Value.Trim();
                objadmin.IntSalarioE = int.Parse(txtSalario.Value.Trim());
                objadmin.IntCargo= int.Parse(drpCargo.SelectedItem.Value);
                objadmin.IntTurno = int.Parse(drpTurno.SelectedItem.Value);


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

        protected void btnActualizarEmp_Click(object sender, EventArgs e)
        {

        }
    }
}
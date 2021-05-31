using System;
using System.Reflection;
using System.Web.UI;
using LibOperativa;

namespace prjtallermotos.Admin
{
    public partial class Empleado : System.Web.UI.Page
    {
        #region "Instancias"
        clsllenarope objcontroles;
        clsadminop objadmin;
        private string strnombreapp;
        #endregion

        #region "Métodos Privados"
        private void Limpiar()
        {

            txtIdEmpleado.Value = string.Empty;
            txtIdEmpleado.Disabled = false;
            txtNombre.Value = string.Empty;
            txtTelefono.Value = string.Empty;
            txtDireccion.Value = string.Empty;
            txtSalario.Value = string.Empty;
            drpCargo.SelectedIndex = 0;
            drpTurno.SelectedIndex = 0;
            drpIdEmpleado.DataSource = null;
            drpIdEmpleado.Items.Clear();
            btnActualizarEmp.Enabled = false;
            btnInsertarEmp.Enabled = true;
            RecargarControles();

        }

        private void RecargarControles()
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

        private void Insertar()
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
                objadmin.IntCargo = drpCargo.SelectedIndex;
                objadmin.IntTurno = drpTurno.SelectedIndex;



                if (!objadmin.Ingresar_Empleado())
                {

                    objadmin = null;
                    mensajes("error", objadmin.StrError);
                    return;
                }
                mensajes("success", objadmin.Resultado);
                RecargarControles();
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
                if (!validar("updateempleado"))
                {
                    return;
                }

                objadmin.IntEmpleado_id = int.Parse(txtIdEmpleado.Value.Trim());
                objadmin.StrNombreE = txtNombre.Value.Trim();
                objadmin.StrTelefonoE = txtTelefono.Value.Trim();
                objadmin.StrDireccionE = txtDireccion.Value.Trim();
                objadmin.IntSalarioE = int.Parse(txtSalario.Value.Trim());
                objadmin.IntCargo = drpCargo.SelectedIndex;
                objadmin.IntTurno = drpTurno.SelectedIndex;


                if (!objadmin.Actualizar_Empleado())
                {

                    objadmin = null;
                    mensajes("error", objadmin.StrError);
                    return;
                }
                mensajes("success", objadmin.Resultado);
                RecargarControles();
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
                if (Session["identificacion"].ToString()==string.Empty)
                {
                    Response.Redirect("../frmlogin.aspx");
                }
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
                btnInsertarEmp.Enabled = false;
                btnActualizarEmp.Enabled = true;
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


        protected void btnInsertarEmp_Click(object sender, EventArgs e)
        {
            Insertar();

        }

        protected void btnActualizarEmp_Click(object sender, EventArgs e)
        {
            Actualizar();

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        #endregion

        

        
        

        protected void logout_new_Click(object sender, ImageClickEventArgs e)
        {
            Session["identificacion"] =string.Empty;
            Response.Redirect("../frmlogin.aspx");
        }
    }
}
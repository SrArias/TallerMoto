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
                        return;
                    }
                    

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void drpIdMantenim_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                objadmin.IntMantenimiento_id = int.Parse(drpIdMantenim.SelectedItem.Value);
                if (!objadmin.getone_empleado())
                {
                    objadmin = null;
                    Response.Write($"<script>alert('{objadmin.StrError}')</script>");
                    return;
                }


                txtDiagnostico.Value = objadmin.StrDiagnostico;
                txtProcRealiz.Value = objadmin.StrProc_Realizado;
             
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void Recargar_grid()
        {
            if (!objcontroles.llenarGrid(gvMantenimiento))
            {
                return;
            }
        }

        protected void btnInsertarMant_Click(object sender, EventArgs e)
        {

            try
            {

                objadmin.StrDiagnostico = txtDiagnostico.Value.Trim();
                objadmin.StrProc_Realizado = txtProcRealiz.Value.Trim();
                objadmin.StrVehiculo_id = drpIdVehiculo.SelectedItem.Value.ToString();//correguir
                objadmin.IntEmpleado_id = int.Parse(drpIdEmpleado.SelectedItem.Value);



                if (!objadmin.Ingresar_Empleado())
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
using LibOperativa;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
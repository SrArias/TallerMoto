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
        private string strnombreapp;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                strnombreapp = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
                objcontroles = new clsllenarope(strnombreapp);
                if (!IsPostBack)
                {
                    objcontroles.Opcion = 2;
                    if (!objcontroles.llenarGrid(gvEmpleados))
                    {
                        return;
                    } objcontroles.Opcion = 1;
                    if (!objcontroles.llenarDrop(drpIdEmpleado))
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
    }
}
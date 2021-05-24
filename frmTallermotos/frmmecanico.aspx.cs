using LibReglasNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjtallermotos
{
    public partial class frmmecanico : System.Web.UI.Page
    {
        clsLlenarControles objcontroles;
        private string strnombreapp;
        protected void Page_Load(object sender, EventArgs e)
        {
            strnombreapp = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
            objcontroles = new clsLlenarControles(strnombreapp);
            try
            {
                objcontroles.Identificacion = int.Parse(Session["identificacion"].ToString());
                if (!objcontroles.Llenarddl(ddlvehiculoM))
                {
                    objcontroles = null;
                    return;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
using LibOperativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjtallermotos.Admin
{
    public partial class Proveedores : System.Web.UI.Page
    {
        clsllenarope objcontroles;
        clsadminop objadmin;
        private string strnombreapp;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void drpIdProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                objadmin.IntProv_id = int.Parse(drpIdProv.SelectedItem.Value);
                if (!objadmin.getone_proveedor())
                {
                    objadmin = null;
                    Response.Write($"<script>alert('{objadmin.StrError}')</script>");
                    return;
                }
                txtNomCompania.Value = objadmin.StrNombreProv;
                txtNomContac.Value = objadmin.StrNombreContacProv;
                txtTitulo.Value = objadmin.StrTituloContacProv;
                txtNumContact.Value = objadmin.StrNumeroContacprov;
                txtDireccionProv.Value = objadmin.StrDireccionProv;            
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
    
}
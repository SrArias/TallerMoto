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
    public partial class Proveedores : System.Web.UI.Page
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

                    if (!objcontroles.llenarGrid(gvProv))
                    {
                        return;
                    }
                    if (!objcontroles.llenarDrop(drpIdProv))
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
        private void Recargar_grid()
        {
            if (!objcontroles.llenarGrid(gvProv))
            {
                return;
            }
        }
            protected void btnInsertarProv_Click(object sender, EventArgs e)
            {
                try
                {

                    objadmin.StrNombreProv = txtNomCompania.Value.Trim();
                    objadmin.StrNombreContacProv = txtNomContac.Value.Trim();
                    objadmin.StrTituloContacProv = txtTitulo.Value.Trim();
                    objadmin.StrNumeroContacprov = txtNumContact.Value;
                    objadmin.StrDireccionProv = txtDireccionProv.Value;
                    if (!objadmin.Ingresar_proveedor())
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
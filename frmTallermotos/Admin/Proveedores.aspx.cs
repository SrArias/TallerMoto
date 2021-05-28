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
                        mensajes("error", objcontroles.StrError);
                        return;
                    }
                    if (!objcontroles.llenarDrop(drpIdProv))
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
        private bool validar(string MetodoOrigen)
        {
            switch (MetodoOrigen.ToLower())
            {
                case "getoneproveedor":
                    if (drpIdProv.SelectedIndex == 0)
                    {
                        mensajes("error", "Debe seleccionar un cliente");
                        return false;
                    }
                    break;
                case "insertproveedor":
                case "updateproveedor":
                    if (txtNomCompania.Value == string.Empty)
                    {
                        mensajes("error", "Debe ingresar el nombre de la compañia");
                        return false;
                    }
                    if (txtNomContac.Value == string.Empty)
                    {
                        mensajes("error", "Debe ingresar el nombre del contacto");
                        return false;
                    }
                    if (txtNumContact.Value == string.Empty)
                    {
                        mensajes("error", "Debe ingresar el numero del contacto");
                        return false;
                    }
                    if (txtDireccionProv.Value == string.Empty)
                    {
                        mensajes("error", "Debe ingresar la direccion del contacto");
                        return false;
                    }
                    if (txtTitulo.Value == string.Empty)
                    {
                        mensajes("error", "Debe ingresar el cargo del contacto");
                        return false;
                    }

                    break;
                default:
                    break;
            }
            return true;

        }
       

        protected void drpIdProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!validar("getoneproveedor"))
                {
                    return;
                }
                objadmin.IntProv_id = int.Parse(drpIdProv.SelectedItem.Value);
                if (!objadmin.getone_proveedor())
                {
                    objadmin = null;
                    mensajes("error", objadmin.StrError);
                    return;
                }
                btnInsertarProv.Enabled = false;
                txtNomCompania.Value = objadmin.StrNombreProv;
                txtNomContac.Value = objadmin.StrNombreContacProv;
                txtTitulo.Value = objadmin.StrTituloContacProv;
                txtNumContact.Value = objadmin.StrNumeroContacprov;
                txtDireccionProv.Value = objadmin.StrDireccionProv;
            }
            catch (Exception ex)
            {

                mensajes("error", ex.Message);
            }

        }
        private void Recargar_grid()
        {
            if (!objcontroles.llenarGrid(gvProv))
            {
                mensajes("error", objcontroles.StrError);
                return;
            }
        }
        protected void btnInsertarProv_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validar("insertproveedor"))
                {
                    return;
                }

                objadmin.StrNombreProv = txtNomCompania.Value.Trim();
                objadmin.StrNombreContacProv = txtNomContac.Value.Trim();
                objadmin.StrTituloContacProv = txtTitulo.Value.Trim();
                objadmin.StrNumeroContacprov = txtNumContact.Value;
                objadmin.StrDireccionProv = txtDireccionProv.Value;
                if (!objadmin.Ingresar_proveedor())
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
        private void mensajes(string tipo, string mensajes)
        {
            string javaScript = $"mensajes('{tipo}','{mensajes}');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
        }

        protected void btnActualizarProv_Click(object sender, EventArgs e)
        {

        }
    }


}
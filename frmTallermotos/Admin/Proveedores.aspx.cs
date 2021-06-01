using LibOperativa;
using System;
using System.Reflection;
using System.Web.UI;

namespace prjtallermotos.Admin
{
    public partial class Proveedores : System.Web.UI.Page
    {
        #region "Atributos"
        private string strnombreapp;
        #endregion

        #region "Instancias"
        clsllenarope objcontroles;
        clsadminop objadmin;
        #endregion

        #region "Métodos Privados"
        private void Limpiar()
        {
            txtNomCompania.Disabled = false;
            txtIdProv.Disabled = false;
            btnInsertarProv.Enabled = true;
            btnActualizarProv.Enabled = false;
            txtIdProv.Value = string.Empty;
            txtNomCompania.Value = string.Empty;
            txtNomContac.Value = string.Empty;
            txtTitulo.Value = string.Empty;
            txtNumContact.Value = string.Empty;
            txtDireccionProv.Value = string.Empty;
            drpIdProv.DataSource = null;
            drpIdProv.Items.Clear();
            RecargarControles();

        }
        private void RecargarControles()
        {
            try
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
                        mensajes("error", "Debe seleccionar un proveedor");
                        return false;
                    }
                    break;
                case "insertproveedor":
                    if (txtIdProv.Value == string.Empty)
                    {
                        mensajes("error", "Debe ingresar el id de la compañia");
                        return false;
                    }

                    if (txtNomCompania.Value == string.Empty)
                    {
                        mensajes("error", "Debe ingresar el de la compañia");
                        return false;
                    }

                    if (txtNomContac.Value == string.Empty)
                    {
                        mensajes("error", "Debe ingresar el nombre del contacto");
                        return false;
                    }
                    if (txtTitulo.Value == string.Empty)
                    {
                        mensajes("error", "Debe ingresar el cargo del contacto");
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


                    break;
                case "updateproveedor":
                    if (drpIdProv.SelectedIndex == 0)
                    {
                        mensajes("error", "Debe seleccionar un proveedor");
                        return false;
                    }
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
        private void mensajes(string tipo, string mensajes)
        {
            string javaScript = $"mensajes('{tipo}','{mensajes}');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
        }
        private void Insertar()
        {
            try
            {
                if (!validar("insertproveedor"))
                {
                    return;
                }

                objadmin.IntProv_id = int.Parse(txtIdProv.Value.Trim());
                objadmin.StrNombreProv = txtNomCompania.Value.Trim();
                objadmin.StrNombreContacProv = txtNomContac.Value.Trim();
                objadmin.StrTituloContacProv = txtTitulo.Value.Trim();
                objadmin.StrNumeroContacprov = txtNumContact.Value.Trim();
                objadmin.StrDireccionProv = txtDireccionProv.Value.Trim();
                if (!objadmin.Ingresar_proveedor())
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
        private void Actualizar()
        {
            try
            {
                if (!validar("updateproveedor"))
                {
                    return;
                }

                objadmin.IntProv_id = int.Parse(txtIdProv.Value.Trim());
                objadmin.StrNombreProv = txtNomCompania.Value.Trim();
                objadmin.StrNombreContacProv = txtNomContac.Value.Trim();
                objadmin.StrTituloContacProv = txtTitulo.Value.Trim();
                objadmin.StrNumeroContacprov = txtNumContact.Value.Trim();
                objadmin.StrDireccionProv = txtDireccionProv.Value.Trim();
                if (!objadmin.Actualizar_proveedor())
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
                if (Session["identificacion"].ToString() == string.Empty)
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

                txtIdProv.Disabled = true;
                txtNomCompania.Disabled = true;
                txtIdProv.Value =objadmin.IntProv_id.ToString();
                btnActualizarProv.Enabled = true;
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

        protected void btnInsertarProv_Click(object sender, EventArgs e)
        {
            Insertar();
        }



        protected void btnActualizarProv_Click(object sender, EventArgs e)
        {
            Actualizar();
        }


        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }


        protected void logout_new_Click(object sender, ImageClickEventArgs e)
        {
            Session["identificacion"] = string.Empty;
            Response.Redirect("../frmlogin.aspx");
        }
        #endregion
    }

}
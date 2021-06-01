using LibOperativa;
using System;
using System.Reflection;
using System.Web.UI;


namespace prjtallermotos.Admin
{

    public partial class Repuestos : System.Web.UI.Page
    {
        #region "Atributos"
        private string strnombreapp;
        #endregion

        #region "Instancias"
        clsllenarope objcontroles;
        clsadminop objadmin;
        #endregion

        #region "Métodos Privados"

        private bool validar(string MetodoOrigen)
        {
            switch (MetodoOrigen.ToLower())
            {
                case "getonerepuesto":
                    if (drpIdRep.SelectedIndex == 0)
                    {
                        mensajes("error", "Debe seleccionar un repuesto");
                        return false;
                    }
                    break;
                case "insertrepuesto":

                    if (txtNomRep.Value == string.Empty)
                    {
                        mensajes("error", "Debe ingresar el nombre del repuesto");
                        return false;
                    }
                    if (txtUnidStock.Value == string.Empty)
                    {
                        mensajes("error", "Debe ingresar las unidades disponibles en stock del repuesto");
                        return false;
                    }
                    if (txtUnidOrden.Value == string.Empty)
                    {
                        mensajes("error", "Debe ingresar las unidades ordenadas del repuesto");
                        return false;
                    }
                    if (txtPrecioxUnid.Value == string.Empty)
                    {
                        mensajes("error", "Debe ingresar el precio por unidad del repuesto");
                        return false;
                    }
                    if (drpProvID.SelectedIndex == 0)
                    {
                        mensajes("error", "Debe ingresar el nombre de la compañía");
                        return false;
                    }

                    break;
                case "updaterepuesto":

                    if (drpIdRep.SelectedIndex == 0)
                    {
                        mensajes("error", "Debe seleccionar el nombre del repuesto");
                        return false;
                    }

                    if (txtNomRep.Value == string.Empty)
                    {
                        mensajes("error", "Debe ingresar el nombre del repuesto");
                        return false;
                    }

                    if (txtNomRep.Value == string.Empty)
                    {
                        mensajes("error", "Debe ingresar el nombre del repuesto");
                        return false;
                    }
                    if (txtUnidStock.Value == string.Empty)
                    {
                        mensajes("error", "Debe ingresar las unidades disponibles en stock del repuesto");
                        return false;
                    }
                    if (txtUnidOrden.Value == string.Empty)
                    {
                        mensajes("error", "Debe ingresar las unidades ordenadas del repuesto");
                        return false;
                    }
                    if (txtPrecioxUnid.Value == string.Empty)
                    {
                        mensajes("error", "Debe ingresar el precio por unidad del repuesto");
                        return false;
                    }
                    if (drpProvID.SelectedIndex == 0)
                    {
                        mensajes("error", "Debe ingresar el nombre de la compañía");
                        return false;
                    }

                    break;
                default:
                    break;
            }
            return true;

        }

        private void Limpiar()
        {
            btnInsertarRep.Enabled = true;
            btnActualizarRep.Enabled = false;
            txtNomRep.Value = string.Empty;
            txtUnidStock.Value = string.Empty;
            txtUnidOrden.Value = string.Empty;
            txtPrecioxUnid.Value = string.Empty;
            drpProvID.DataSource = null;
            drpIdRep.DataSource = null;
            drpProvID.Items.Clear();
            drpIdRep.Items.Clear();
            RecargarControles();
        }

        private void RecargarControles()
        {
            try
            {
                if (!objcontroles.llenarDrop(drpIdRep))
                {
                    mensajes("error", objcontroles.StrError);
                    return;
                }
                if (!objcontroles.llenarDrop(drpProvID))
                {
                    mensajes("error", objcontroles.StrError);
                    return;
                }
                if (!objcontroles.llenarGrid(gvRep))
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

        private void mensajes(string tipo, string mensajes)
        {
            string javaScript = $"mensajes('{tipo}','{mensajes}');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
        }

        private void Insertar()
        {
            try
            {
                if (!validar("insertrepuesto"))
                {
                    return;
                }

                objadmin.StrNombreRep = txtNomRep.Value.Trim();
                objadmin.IntUnidStock = int.Parse(txtUnidStock.Value.Trim());
                objadmin.IntUnidOrdenadas = int.Parse(txtUnidOrden.Value.Trim());
                objadmin.IntPrecioUnid = int.Parse(txtPrecioxUnid.Value.Trim());
                objadmin.IntProv_id = int.Parse(drpProvID.SelectedItem.Value);
                if (!objadmin.Ingresar_Repuesto())
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
                if (!validar("updaterepuesto"))
                {
                    return;
                }


                objadmin.StrNombreRep = txtNomRep.Value.Trim();
                objadmin.IntUnidStock = int.Parse(txtUnidStock.Value.Trim());
                objadmin.IntUnidOrdenadas = int.Parse(txtUnidOrden.Value.Trim());
                objadmin.IntPrecioUnid = int.Parse(txtPrecioxUnid.Value.Trim());
                objadmin.IntProv_id = int.Parse(drpProvID.SelectedItem.Value);
                drpProvID.SelectedItem.Text = objadmin.IntProv_id.ToString();

                if (!objadmin.Actualizar_Repuesto())
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

        protected void drpIdRep_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!validar("getonerepuesto"))
                {
                    return;
                }

                objadmin.IntRepuesto_id = int.Parse(drpIdRep.SelectedItem.Value);
                if (!objadmin.getone_repuesto())
                {
                    objadmin = null;
                    mensajes("error", objadmin.StrError);
                    return;
                }
                btnInsertarRep.Enabled = false;
                btnActualizarRep.Enabled = true;
                txtNomRep.Value = objadmin.StrNombreRep;
                txtUnidStock.Value = objadmin.IntUnidStock.ToString();
                txtUnidOrden.Value = objadmin.IntUnidOrdenadas.ToString();
                txtPrecioxUnid.Value = objadmin.IntPrecioUnid.ToString();

            }
            catch (Exception ex)
            {

                mensajes("error", ex.Message);
            }
        }

        protected void btnInsertarRep_Click(object sender, EventArgs e)
        {
            Insertar();
        }

        protected void btnActualizarRep_Click(object sender, EventArgs e)
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
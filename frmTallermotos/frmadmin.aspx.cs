using LibOperativa;
using System;
using System.Reflection;
using System.Web.UI;

namespace prjtallermotos
{
    public partial class frmadmin : System.Web.UI.Page
    {

        #region "Atributos"
        private string strnombreapp;
        #endregion

        #region "Instancias"
        clsllenarope objcontroles;
        #endregion

        #region "Métodos Privados"
        private void mostrarpanel()
        {

            pnlmecanico.Visible = false;
            pnlCliente.Visible = false;

            switch (rdlOpciones.SelectedIndex)
            {
                default:
                case 0:
                    pnlmecanico.Visible = true;

                    try
                    {

                        if (!objcontroles.llenarDrop(ddlmecanico))
                        {
                            objcontroles = null;
                            return;
                        }
                        if (!objcontroles.llenarDrop(ddlCarro))
                        {
                            objcontroles = null;
                            return;
                        }

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case 1:
                    pnlCliente.Visible = true;

                    try
                    {

                        if (!objcontroles.llenarDrop(ddlvehiculo))
                        {
                            objcontroles = null;
                            return;
                        }

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;


            }
        }

        private void mensajes(string tipo, string mensajes)
        {
            string javaScript = $"mensajes('{tipo}','{mensajes}');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
        }

        #endregion

        #region "Eventos"

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["identificacion"].ToString() == string.Empty)
                {
                    Response.Redirect("frmlogin.aspx");
                }

                strnombreapp = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
                objcontroles = new clsllenarope(strnombreapp);
            }
            catch (Exception ex)
            {

                mensajes("error", ex.Message);
            }

        }

        protected void rdSeleccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            mostrarpanel();
        }

        protected void logout_new_Click(object sender, ImageClickEventArgs e)
        {
            Session["identificacion"] = string.Empty;
            Response.Redirect("frmlogin.aspx");
        }
        #endregion
    }
}
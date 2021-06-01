using LibOperativa;
using System;
using System.Reflection;
using System.Web.UI;

namespace frmTallermotos
{
    public partial class frmCliente : System.Web.UI.Page
    {
        #region "Atributos"
        private string strnombreapp;
        #endregion

        #region "Instancias"
        clsClienteOpe objmantenimiento;
        #endregion

        #region "Métodos privados"
        private void mostrarpanel()
        {
            pnlMantenimiento.Visible = false;
            pnlFactura.Visible = false;

            switch (rdlOpciones.SelectedIndex)
            {
                default:
                case 0:
                    pnlMantenimiento.Visible = true;
                    objmantenimiento = new clsClienteOpe(strnombreapp);
                    try
                    {
                        objmantenimiento.Identificacion = int.Parse(Session["identificacion"].ToString());
                        if (!objmantenimiento.Mantenimiento(gvmantenimiento))
                        {
                            objmantenimiento = null;
                            return;
                        }

                    }
                    catch (Exception ex)
                    {

                        mensajes("error", ex.Message);
                    }
                    break;
                case 1:
                    pnlFactura.Visible = true;
                    objmantenimiento = new clsClienteOpe(strnombreapp);
                    try
                    {
                        objmantenimiento.Identificacion = int.Parse(Session["identificacion"].ToString());
                        if (!objmantenimiento.Factura(gvFactura))
                        {
                            objmantenimiento = null;
                            return;
                        }

                    }
                    catch (Exception ex)
                    {

                        mensajes("error", ex.Message);
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
            }
            catch (Exception ex)
            {

                mensajes("error", ex.Message);
            }
   

        }

        protected void rdlOpciones_SelectedIndexChanged(object sender, EventArgs e)
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
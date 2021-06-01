using LibOperativa;
using System;
using System.Reflection;
using System.Web.UI;

namespace frmTallermotos
{
    public partial class frmLogin : System.Web.UI.Page
    {
        #region "Atributos"
        private string strnombreapp;
        #endregion

        #region "Métodos Privados"
        public bool validar()
        {
            if (txtusername.Value == "")
            {
                mensajes("error", "Debe ingresar el usuario");
                return false;
            }
            if (txtpassword.Value == "")
            {
                mensajes("error", "Debe ingresar la contraseña");
                return false;
            }
            return true;
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
                strnombreapp = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
            }
            catch (Exception ex)
            {

                mensajes("error", ex.Message);
            }

        }


        protected void btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validar())
                {
                    return;
                }

                clsLogin objlogin = new clsLogin(strnombreapp);
                objlogin.Username = int.Parse(txtusername.Value.Trim());
                objlogin.Password = txtpassword.Value.Trim();
                if (!objlogin.login())
                {

                    objlogin = null;
                    return;
                }
                switch (objlogin.Tipo_usuario)
                {
                    case "cliente":
                        Session["identificacion"] = objlogin.Username;
                        Response.Redirect("frmCliente.aspx");
                        break;
                    case "admin":
                        Session["identificacion"] = objlogin.Username;
                        Response.Redirect("frmadmin.aspx");
                        break;
                    
                    default:
                        mensajes("error",objlogin.Tipo_usuario);
                        break;
                }
            }
            catch (Exception ex)
            {

                mensajes("error", ex.Message);
            }
        }

        #endregion
    }
}
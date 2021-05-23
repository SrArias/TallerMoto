﻿using LibOperativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace frmTallermotos
{
    public partial class frmLogin : System.Web.UI.Page
    {
        #region "Atributos"
        private string strnombreapp;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            strnombreapp = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
        }

        

        protected void btn_Click(object sender, EventArgs e)
        {
            try
            {


                clsLogin objlogin = new clsLogin(strnombreapp);
                objlogin.Username = int.Parse(txtusername.Value.Trim());
                objlogin.Password = txtpassword.Value.Trim();
                if (!objlogin.login())
                {
                    //Mensajes(objlogin.Error);
                    objlogin = null;
                    return;
                }
                switch (objlogin.Tipo_usuario)
                {
                    case "cliente":
                        Session["identificacion"] = objlogin.Username;
                        Response.Redirect("frmCliente.aspx");
                        break;
                    
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
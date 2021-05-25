using LibOperativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjtallermotos
{
    public partial class frmadmin : System.Web.UI.Page
    {
        clsllenarope objcontroles;
        private string strnombreapp;
        protected void Page_Load(object sender, EventArgs e)
        {
            strnombreapp = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
            objcontroles = new clsllenarope(strnombreapp);
        }

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

        protected void rdSeleccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            mostrarpanel();
        }
    }
}
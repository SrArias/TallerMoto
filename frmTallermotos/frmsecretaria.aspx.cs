using LibReglasNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjtallermotos
{
    public partial class frmsecretaria : System.Web.UI.Page
    {
        clsLlenarControles objcontroles;
        private string strnombreapp;
        protected void Page_Load(object sender, EventArgs e)
        {
            strnombreapp = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
            objcontroles = new clsLlenarControles(strnombreapp);
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
                        
                        if (!objcontroles.Llenarddl(ddlmecanico))
                        {
                            objcontroles = null;
                            return;
                        }
                        if (!objcontroles.Llenarddl(ddlCarro))
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
                        
                        if (!objcontroles.Llenarddl(ddlvehiculo))
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
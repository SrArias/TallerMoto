using LibOperativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

        #region "Eventos"

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            strnombreapp = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
            

        }
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
                        throw ex;
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
                        throw ex;
                    }
                    break;
                
                    

            }
        }
        protected void rdlOpciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            mostrarpanel();
        }
    }
}
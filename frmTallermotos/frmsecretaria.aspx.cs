using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjtallermotos
{
    public partial class frmsecretaria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void mostrarpanel()
        {
            pnlmecanico.Visible = false;
            //pnlFactura.Visible = false;

            switch (rdlOpciones.SelectedIndex)
            {
                default:
                case 0:
                    pnlmecanico.Visible = true;
                    objmantenimiento = new clsmantenimiento(strnombreapp);
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
                    //pnlFactura.Visible = true;
                    //objmantenimiento = new clsmantenimiento(strnombreapp);
                    //try
                    //{
                    //    objmantenimiento.Identificacion = int.Parse(Session["identificacion"].ToString());
                    //    if (!objmantenimiento.Factura(gvFactura))
                    //    {
                    //        objmantenimiento = null;
                    //        return;
                    //    }

                    //}
                    //catch (Exception ex)
                    //{
                    //    throw ex;
                    //}
                    break;



            }
        }

        protected void rdSeleccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            mostrarpanel();
        }
    }
}
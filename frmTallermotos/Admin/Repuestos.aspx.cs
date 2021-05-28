using LibOperativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace prjtallermotos.Admin
{
    
    public partial class Repuestos : System.Web.UI.Page
    {
        clsllenarope objcontroles;
        clsadminop objadmin;
        private string strnombreapp;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                strnombreapp = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
                objcontroles = new clsllenarope(strnombreapp);
                objadmin = new clsadminop(strnombreapp);
                if (!IsPostBack)
                {

                    if (!objcontroles.llenarGrid(gvRep))
                    {
                        return;
                    }
                    if (!objcontroles.llenarDrop(drpIdRep))
                    {
                        return;
                    }
                    if (!objcontroles.llenarDrop(drpProvID))
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void drpIdRep_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                objadmin.IntRepuesto_id = int.Parse(drpIdRep.SelectedItem.Value);
                if (!objadmin.getone_repuesto())
                {
                    objadmin = null;
                    Response.Write($"<script>alert('{objadmin.StrError}')</script>");
                    return;
                }

                txtNomRep.Value = objadmin.StrNombreRep;
                txtUnidStock.Value=objadmin.IntUnidStock.ToString();
                txtUnidOrden.Value = objadmin.IntUnidOrdenadas.ToString();
                txtPrecioxUnid.Value = objadmin.IntPrecioUnid.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void Recargar_grid()
        {
            if (!objcontroles.llenarGrid(gvRep))
            {
                return;
            }
        }
        protected void btnInsertarRep_Click(object sender, EventArgs e)
        {
            try
            {

                objadmin.StrNombreRep = txtNomRep.Value.Trim();
                objadmin.IntUnidStock = int.Parse(txtUnidStock.Value.Trim());
                objadmin.IntUnidOrdenadas = int.Parse(txtUnidOrden.Value.Trim());
                objadmin.IntPrecioUnid = int.Parse(txtPrecioxUnid.Value.Trim());
                objadmin.IntProv_id = int.Parse(drpProvID.SelectedItem.Value);
                if (!objadmin.Ingresar_Repuesto())
                {

                    objadmin = null;
                    Response.Write($"<script>alert('{objadmin.StrError}')</script>");
                    return;
                }
                Response.Write($"<script>alert('{objadmin.Resultado}')</script>");
                Recargar_grid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
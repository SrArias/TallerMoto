using LibOperativa;
using System;
using System.Collections.Generic;
using System.Linq;
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
                txtUnidStock.Value = objadmin.IntUnidStock.ToString();
                txtUnidOrden.Value = objadmin.IntUnidOrdenadas.ToString();
               
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
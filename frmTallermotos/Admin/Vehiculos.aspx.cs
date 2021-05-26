using LibOperativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjtallermotos.Admin
{
    public partial class Vehiculos : System.Web.UI.Page
    {
        clsllenarope objcontroles;
        clsadminop objadmin;
        private string strnombreapp;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
     
        protected void drpIdVehiculo_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {
                objadmin.StrVehiculo_id = drpIdVehiculo.SelectedItem.Value;
                if (!objadmin.getone_vehiculo())
                {
                    objadmin = null;
                    Response.Write($"<script>alert('{objadmin.StrError}')</script>");
                    return;
                }
                txtIdVehiculo.Disabled = true;
                //btnInsertarEmp.Enabled = true;
                txtIdVehiculo.Value = objadmin.StrVehiculo_id;
                txtMarca.Value = objadmin.StrMarca;
                txtCilindraje.Value = objadmin.StrCilindraje;
                txtModelo.Value = objadmin.IntModelo.ToString();
                txtColor.Value = objadmin.StrColor;
                txtReferencia.Value = objadmin.StrRefencia;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
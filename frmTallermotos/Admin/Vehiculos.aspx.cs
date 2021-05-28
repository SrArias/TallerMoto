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
    public partial class Vehiculos : System.Web.UI.Page
    {
        clsllenarope objcontroles;
        clsadminop objadmin;
        private string strnombreapp;
        protected void Page_Load(object sender, EventArgs e)
        {
            strnombreapp = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
            objcontroles = new clsllenarope(strnombreapp);
            objadmin = new clsadminop(strnombreapp);
            if (!IsPostBack)
            {

                if (!objcontroles.llenarGrid(gvVehic))
                {
                    return;
                }
                if (!objcontroles.llenarDrop(drpIdVehiculo))
                {
                    return;
                }
  
            }

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
        private void Recargar_grid()
        {
            if (!objcontroles.llenarGrid(gvVehic))
            {
                return;
            }
        }
        protected void btnInsertarVeh_Click(object sender, EventArgs e)
        {
            try
            {

                objadmin.StrVehiculo_id = txtIdVehiculo.Value.Trim();
                objadmin.StrMarca = txtMarca.Value.Trim();
                objadmin.StrCilindraje = txtCilindraje.Value.Trim();
                objadmin.IntModelo = int.Parse(txtModelo.Value.Trim());
                objadmin.StrColor = txtColor.Value.Trim();
                objadmin.StrRefencia = txtReferencia.Value.Trim();

                if (!objadmin.Ingresar_Vehiculo())
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
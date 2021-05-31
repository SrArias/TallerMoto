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
    public partial class Detalles : System.Web.UI.Page
    {
        #region "Atributos"
        private string strnombreapp;
        public int factura_id;
        #endregion

        #region "Instancias"
        clsllenarope objcontroles;
        clsadminop objadmin;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                strnombreapp = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
                objcontroles = new clsllenarope(strnombreapp);
                objadmin = new clsadminop(strnombreapp);
                RecargarControles();
            }
            catch (Exception ex)
            {

                mensajes("error", ex.Message);
            }
        }
        #region "Metodos Privados"

        private bool validar(string MetodoOrigen)
        {
            switch (MetodoOrigen.ToLower())
            {

                case "insertfactura":
                    if (drpVehiculoId.SelectedIndex == 0)
                    {
                        mensajes("error", "Debe ingresar un vehiculo");
                        return false;
                    }
                    if (drpempleadofactura.SelectedIndex == 0)
                    {
                        mensajes("error", "Debe ingresar un empleado");
                        return false;
                    }
                    break;
                case "insertdetalles":
                    if (drpRepuesto.SelectedIndex == 0)
                    {
                        mensajes("error", "Debe ingresar un repuesto");
                        return false;
                    }
                    if (txtCantidadRep.Value==string.Empty)
                    {
                        mensajes("error", "Debe ingresar la cantidad de repuestos");
                        return false;
                    } 
                    
                    if (drpMantenimientoId.SelectedIndex == 0)
                    {
                        mensajes("error", "Debe ingresar el procedimeinto realizado");
                        return false;
                    }
                    if (txtPrecioMant.Value == string.Empty)
                    {
                        mensajes("error", "Debe ingresar el precio del mantenimiento");
                        return false;
                    }
                    break;

                default:
                    break;

            }
            return true;
        }
        private void InsertarFactura()
        {
            try
            {
                if (!validar("insetfactura"))
                {
                    return;
                }

                objadmin.StrVehiculo_id = drpVehiculoId.SelectedItem.Value;
                objadmin.IntEmpleado_id  = int.Parse(drpempleadofactura.SelectedItem.Value);

                if (!objadmin.Ingresar_factura())
                {

                    objadmin = null;
                    mensajes("error", objadmin.StrError);
                    return;
                }
                Session["factura_id"] = objadmin.Resultado;
                mensajes("success", "Se genero la factura correctamente");
                btnDetallesFac.Enabled = true;
                //Limpiar();
                
            }
            catch (Exception ex)
            {
                mensajes("error", ex.Message);
            }
        }
        private void InsertarDetalleFactura()
        {
            try
            {
                if (!validar("insetdetalles"))
                {
                    return;
                }

                objadmin.IntMantenimiento_id = int.Parse(drpMantenimientoId.SelectedItem.Value);
                objadmin.IntRepuesto_id= int.Parse(drpRepuesto.SelectedItem.Value);
                objadmin.DatFecha = DateTime.Parse(txtFecha.Value);
                objadmin.IntCant_Repuesto= int.Parse(txtCantidadRep.Value.Trim());
                objadmin.IntPrecio_Mant=int.Parse(txtPrecioMant.Value.Trim());
                objadmin.IntFactura_id=int.Parse(Session["factura_id"].ToString());
                if (!objadmin.Ingresar_Detalle_factura(gvdetalles))
                {
                    objadmin = null;
                    mensajes("error", objadmin.StrError);
                    return;
                }
                
                mensajes("success", "Se genero la factura correctamente");
                //Limpiar();

            }
            catch (Exception ex)
            {
                mensajes("error", ex.Message);
            }
        }
        #endregion
        private void RecargarControles()
        {
            if (!IsPostBack)
            {

                if (!objcontroles.llenarDrop(drpVehiculoId))
                {
                    mensajes("error", objcontroles.StrError);
                    return;
                }

                if (!objcontroles.llenarDrop(drpempleadofactura))
                {
                    mensajes("error", objcontroles.StrError);
                    return;
                }

                if (!objcontroles.llenarDrop(drpRepuesto))
                {
                    mensajes("error", objcontroles.StrError);
                    return;
                }
            }

        }

        private void mensajes(string tipo, string mensajes)
        {
            string javaScript = $"mensajes('{tipo}','{mensajes}');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
        }


        protected void btnFactura_Click(object sender, EventArgs e)
        {
            pnldetalles.Visible = false;
            pnlFactura.Visible = true;
           
        }

        protected void btnDetallesFac_Click(object sender, EventArgs e)
        {
            pnlFactura.Visible = false;
            pnldetalles.Visible = true;
            txtFecha.Value = DateTime.Now.ToString();
            try
            {
                objcontroles.Vehiculo = drpVehiculoId.SelectedItem.Value;
                if (!objcontroles.llenarDrop(drpMantenimientoId))
                {
                    mensajes("error", objcontroles.StrError);
                    return;
                }
            }
            catch (Exception ex)
            {

                mensajes("error", ex.Message);
            }
            drpVehiculoId.DataSource = null;
            drpVehiculoId.Items.Clear();
            

        }
        private void Limpiar()
        {
            //txtFecha.Value = string.Empty;
            txtCantidadRep.Value = string.Empty;
            txtPrecioMant.Value = string.Empty;
            //drpMantenimientoId.DataSource = null;
            drpempleadofactura.DataSource = null;
            drpempleadofactura.Items.Clear();
            //drpMantenimientoId.Items.Clear();
            RecargarControles();

        }

        protected void btnInsertarDet_Click(object sender, EventArgs e)
        {
            InsertarDetalleFactura();
            
        }

        protected void btngenerarfactura_Click(object sender, EventArgs e)
        {
            InsertarFactura();
        }
    }
}

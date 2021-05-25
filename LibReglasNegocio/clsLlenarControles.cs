using libLlenarCombos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using libLlenarGrids;

namespace LibReglasNegocio
{
    public class clsLlenarControles
    {

        private const string ID = "Id";
        private clsLlenarGrids objGrid;
        private SqlParameter[] objDatosEscuela;
        private clsLlenarCombos objcnx;
        private DataSet dsDatos;
        private string strError;
        private string strid;
        private int intidtypesports;
        private string strcampostext;
        private int idSport;
        private int intidteacher;
        private string intidgrupo;
        private int identificacion;
        private int opcion;

        public int Identificacion { get => identificacion; set => identificacion = value; }
        public string Error { get => strError; set => strError = value; }
        public int Opcion { get => opcion; set => opcion = value; }

        public clsLlenarControles(string NombreApp)
        {
            objGrid = new clsLlenarGrids(NombreApp);
            objcnx = new clsLlenarCombos(NombreApp);
            
        }
        private bool AgregarParametros(string MetodoOrigen)
        {
            try
            {
                objDatosEscuela = null;

                switch (MetodoOrigen.ToUpper())
                {
                    case "DRPIDEMPLEADO":
                    case "GVEMPLEADOS":
                        objDatosEscuela = new SqlParameter[1];
                        objDatosEscuela[0] = new SqlParameter("opcion", opcion);
                        break;
                   

                        
                    default:
                        strError = "Caso no valido en las reglas del negocio";
                        return false;
                }
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Llenarddl(DropDownList ddlGenerico)
        {
            try
            {
                if (!AgregarParametros(ddlGenerico.ID))
                {
                    return false;
                }
                
                switch (ddlGenerico.ID.ToLower())
                {
                    case "ddlvehiculo":
                    case "ddlcarro":
                        strid = "vehiculo_id";
                        strcampostext = "placa";
                        objcnx.SQL = "sp_getautos";
                        break;
                    case "ddlmecanico":
                        strid = "empleado_id";
                        strcampostext = "nombre";
                        objcnx.SQL = "sp_getmecanico";
                        break;
                    case "drpidempleado":
                        strid = "empleado_id";
                        strcampostext = "nombre";
                        objcnx.ParametrosSQL = objDatosEscuela;
                        objcnx.SQL = "sp_getempleados";
                        break;
                    case "ddlvehiculoM":
                        strid = "vehiculo_id";
                        strcampostext = "placa";
                        objcnx.SQL = "sp_getvehiculoMecanico";
                        objcnx.ParametrosSQL = objDatosEscuela;
                        break;

                    default:
                        strError = "ddl no programado";
                        return false;
                }
                objcnx.CampoID = strid;
                objcnx.CampoTexto = strcampostext;
                
                if (!objcnx.llenarComboWeb(ddlGenerico))
                {
                    strError = objcnx.Error;
                    objcnx = null;
                    return false;
                }
                objcnx = null;
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public bool LlenarGrid(GridView gvGenerico)
        {
            try
            {
                if (!AgregarParametros(gvGenerico.ID))
                {
                    return false;
                }

                switch (gvGenerico.ID.ToLower())
                {
                    case "gvempleados":                        
                        objGrid.SQL = "sp_getempleados";
                        objGrid.ParametrosSQL = objDatosEscuela;
                        break;
                    case "ddlmecanico":
                        strid = "empleado_id";
                        strcampostext = "nombre";
                        objcnx.SQL = "sp_getmecanico";
                        break;
                 

                    default:
                        strError = "ddl no programado";
                        return false;
                }
         

                if (!objGrid.llenarGridWeb(gvGenerico))
                {
                    strError = objGrid.Error;
                    objGrid = null;
                    return false;
                }
                objGrid = null;
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

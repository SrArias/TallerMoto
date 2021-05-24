using libLlenarCombos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace LibReglasNegocio
{
    public class clsLlenarControles
    {
        private const string ID = "Id";
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
        private int intidstudent;

        public clsLlenarControles(string NombreApp)
        {
            objcnx = new clsLlenarCombos(NombreApp);
            
        }
        public bool Llenarddl(DropDownList ddlGenerico)
        {
            try
            {
                
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
                
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

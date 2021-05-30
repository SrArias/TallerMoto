using libConexionBd;
using System;
using System.Data;
using System.Data.SqlClient;

namespace LibReglasNegocio
{
    public class clsClienteRN
    {
        #region "Atributos"
        private int identificacion;
        private string strError;
        private string strNombreApp;
        private SqlParameter[] objDatosMatri;
        private clsConexionBd objCnx;
        private DataSet dsDatos;
        #endregion

        #region "Constructor"
        public clsClienteRN(string strNombreApp)
        {
            this.identificacion = -1;
            this.strNombreApp = strNombreApp;
            this.strError = "";

        }
        #endregion

        #region "Propiedades"

        public int Identificacion { set => identificacion = value; }
        public string Error { get => strError;  }        
        public DataSet DsDatos { get => dsDatos;  }

        #endregion

        #region "Métodos Privados"
        private bool validar(string metodoOrigen)
        {
            if (strNombreApp == "")
            {
                strError = "Olvidó enviar el nombre de la aplicación";
                return false;
            }
            switch (metodoOrigen.ToLower())
            {
                case "mantenimiento":
                    if (identificacion <= 0)
                    {
                        strError = "Debe ingresar su cedula";
                        return false;
                    }
                    break;
            }
            return true;
        }
        private bool agregarParam(String metodoOrgien)
        {
            try
            {
                if (!validar(metodoOrgien))
                {
                    return false;
                }
                objDatosMatri = new SqlParameter[1];

                switch (metodoOrgien.ToLower())
                {
                    case "factura":
                    case "mantenimiento":
                        objDatosMatri = new SqlParameter[1];
                        objDatosMatri[0] = new SqlParameter("@identificacion", identificacion);
                        
                        break;
                    
                        
                    
                    default:
                        strError = "Caso no válido RN";
                        return false;
                }
                return true;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region "Métodos públicos"

        public bool Mantenimiento()
        {
            try
            {
                if (!agregarParam("mantenimiento"))
                {
                    return false;
                }
                objCnx = new clsConexionBd(strNombreApp);
                objCnx.SQL = "sp_getmantenimiento";
                objCnx.ParametrosSQL = objDatosMatri;

                if (!objCnx.llenarDataSet(true, true))
                {
                    strError = objCnx.Error;
                    objCnx.cerrarCnx();
                    objCnx = null;
                    return false;
                }
                dsDatos = objCnx.DataSetLleno;
                objCnx.cerrarCnx();
                objCnx = null;
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool factura()
        {
            try
            {
                if (!agregarParam("factura"))
                {
                    return false;
                }
                objCnx = new clsConexionBd(strNombreApp);
                objCnx.SQL = "sp_getfactura";
                objCnx.ParametrosSQL = objDatosMatri;

                if (!objCnx.llenarDataSet(true, true))
                {
                    strError = objCnx.Error;
                    objCnx.cerrarCnx();
                    objCnx = null;
                    return false;
                }
                dsDatos = objCnx.DataSetLleno;
                objCnx.cerrarCnx();
                objCnx = null;
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}

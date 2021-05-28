using libConexionBd;
using System;
using System.Data;
using System.Data.SqlClient;

namespace LibReglasNegocio
{
    public class clsLoginRN
    {
        #region "Atributos"
        private const string LOGIN = "LOGIN";
        private int intUsername;
        private string strPassword, strNombreApp, strError;        
        private SqlParameter[] objDatosEscuela;
        private clsConexionBd objcnx;
        private DataSet dsDatos;
        #endregion

        #region "Constructor"
        public clsLoginRN(string NombreApp)
        {
            strNombreApp = NombreApp;
            intUsername = -1;
            strPassword = string.Empty;
            strError = string.Empty;
            objcnx = new clsConexionBd(NombreApp);
        }
        #endregion

        #region "Propiedades"
        public int Username { set => intUsername = value; }
        public string Password { set => strPassword = value; }
        public string Error { get => strError; }
        public DataSet Datos { get => dsDatos; }
        #endregion

        #region "Métodos Privados"

        private bool validar(string MetodoOrigen)
        {
            if (string.IsNullOrEmpty(strNombreApp))
            {
                strError = "Se debe enviar el nombre de la aplicación";
                return false;
            }
            switch (MetodoOrigen.ToUpper())
            {
                case LOGIN:
                    if (intUsername<=0)
                    {
                        strError = "Debe ingresar la cedula con la cual se encuentra registrado";
                        return false;
                    }
                    if (string.IsNullOrEmpty(strPassword.Trim()))
                    {
                        strError = "Debes ingresar las contraseña";
                        return false;
                    }
                    
                    break;
                default:
                    strError = "Método aún no establecido";

                    break;
            }
            return true;
        }
        private bool AgregarParametros(string MetodoOrigen)
        {
            try
            {
                if (!validar(MetodoOrigen))
                {
                    return false;
                }
                objDatosEscuela = new SqlParameter[0];
                switch (MetodoOrigen.ToUpper())
                {
                    case LOGIN:
                        objDatosEscuela = new SqlParameter[2];
                        objDatosEscuela[0] = new SqlParameter("@username", intUsername);
                        objDatosEscuela[1] = new SqlParameter("@password", strPassword);
                       break;

                    default:
                        strError = "Caso no valido en las reglas del negocio";
                        break;
                }
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region "Métodos Públicos"

        public bool Login()
        {
            try
            {
                if (!AgregarParametros(LOGIN))
                {
                    return false;
                }
                objcnx.SQL = "sp_login";
                objcnx.ParametrosSQL = objDatosEscuela;
                if (!objcnx.llenarDataSet(true, true))
                {
                    strError = objcnx.Error;
                    objcnx.cerrarCnx();
                    objcnx = null;
                    return false;
                }
                dsDatos = objcnx.DataSetLleno;
                objcnx.cerrarCnx();
                objcnx = null;
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

    #endregion
}

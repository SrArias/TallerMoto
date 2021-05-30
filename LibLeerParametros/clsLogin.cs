using LibReglasNegocio;
using System;

namespace LibOperativa
{
    public class clsLogin
    {
        #region "Atributos"
        private int intUsername;
        private string strNombreApp;
        private string strPassword;
        private string strError;
        private string tipo_usuario;
        #endregion

        #region "Constructor"
        public clsLogin(string nombreapp)
        {
            this.strNombreApp = nombreapp;
            this.intUsername = -1;
            this.strPassword = string.Empty;
            this.strError = string.Empty;
            this.tipo_usuario = string.Empty;

        }
        #endregion

        #region "Propiedades"
        public int Username { get => intUsername; set => intUsername = value; }
        public string Password { get => strPassword; set => strPassword = value; }
        public string Error { get => strError; set => strError = value; }
        public string Tipo_usuario { get => tipo_usuario; set => tipo_usuario = value; }
        #endregion

        #region "Métodos privados"
        private bool validar(string metodoOrigen)
        {
            if (string.IsNullOrEmpty(strNombreApp))
            {
                strError = "No envió el nombre de la aplicación.";
                return false;
            }
            switch (metodoOrigen.ToLower())
            {
                case "login":
                    if (intUsername <= 0)
                    {
                        strError = "Debe enviar el Id para iniciar sesión.";
                        return false;
                    }
                    if (string.IsNullOrEmpty(strPassword))
                    {
                        strError = "Debe enviar la contraseña para iniciar sesión.";
                        return false;
                    }

                    break;

                default:
                    strError = "Caso no válido OPE";
                    return false;
            }
            return true;
        }

        #endregion

        #region "Métodos Públicas"
        public bool login()
        {
            try
            {
                if (!validar("login"))
                {
                    return false;
                }
                clsLoginRN objLogRn = new clsLoginRN(strNombreApp);

                objLogRn.Username = intUsername;
                objLogRn.Password = strPassword;


                if (!objLogRn.Login())
                {
                    strError = objLogRn.Error;
                    objLogRn = null;
                    return false;
                }


                Tipo_usuario = objLogRn.Datos.Tables[0].Rows[0]["tipo_usuario"].ToString();


                objLogRn = null;
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

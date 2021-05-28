using LibReglasNegocio;
using System;
using System.Web.UI.WebControls;

namespace LibOperativa
{
    public class clsllenarope
    {
        #region "Atributos"
        private string strNombreApp;
        private string strError;
        private int intidentificacion;
        private string strvehiculo;
        private int opcion;
        private string error;
        #endregion

        #region "Propiedades"
        public int Identificacion { get => intidentificacion; set => intidentificacion = value; }
        public string Vehiculo { get => strvehiculo; set => strvehiculo = value; }
        public string StrError { get => error; set => error = value; }
        public int Opcion { get => opcion; set => opcion = value; }
        #endregion

        #region "Constructor"
        public clsllenarope(string nombreapp)
        {
            strNombreApp = nombreapp;
            strError = string.Empty;
            intidentificacion=0;
            opcion=0;
        }
        #endregion

        #region "Métodos Públicos

        public bool llenarGrid(GridView gvGenerico)
        {
            try
            {
                clsLlenarControles objLnRn = new clsLlenarControles(strNombreApp);

                objLnRn.Vehiculo = strvehiculo;

                if (!objLnRn.LlenarGrid(gvGenerico))
                {

                    strError = objLnRn.Error;
                    objLnRn = null;
                    return false;
                }
                objLnRn = null;

                return true;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public bool llenarDrop(DropDownList ddlGenerico)
        {
            try
            {
                clsLlenarControles objLnRn = new clsLlenarControles(strNombreApp);

                objLnRn.Opcion = opcion;
                if (!objLnRn.Llenarddl(ddlGenerico))
                {

                    strError = objLnRn.Error;
                    objLnRn = null;
                    return false;
                }
                objLnRn = null;

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

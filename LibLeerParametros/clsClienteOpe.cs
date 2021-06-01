using libLlenarGrids;
using LibReglasNegocio;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace LibOperativa
{
    public class clsClienteOpe
    {
        #region "Atributos"
        private int identificacion;
        private string strError;
        private string strNombreApp;
        #endregion

        #region "Constructor"
        public clsClienteOpe()
        {
            identificacion = -1 ;
            strError=string.Empty;
            strNombreApp=string.Empty;
        }
        
        #endregion

        #region "Propiedades"
        public int Identificacion { get => identificacion; set => identificacion = value; }
        #endregion

        #region "MétodosPúblicos"
        public clsClienteOpe(string strNombreApp)
        {
            this.strNombreApp = strNombreApp;
            this.identificacion  = 0;
            this.strError = "";
            
        }
        public bool Mantenimiento(GridView gvgenerico)
        {
            try
            {

                if (!validar("mantenimiento"))
                {
                    return false;
                }

                clsClienteRN objmantenimento = new clsClienteRN(strNombreApp);
                objmantenimento.Identificacion = identificacion;
                if (!objmantenimento.Mantenimiento())
                {
                    strError = objmantenimento.Error;
                    objmantenimento = null;
                    return false;
                }
                if (!llenarGrid(gvgenerico, objmantenimento.DsDatos.Tables[0]))
                {
                    objmantenimento = null;
                    return false;
                }
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Factura(GridView gvgenerico)
        {
            try
            {

                if (!validar("factura"))
                {
                    return false;
                }

                clsClienteRN objmantenimento = new clsClienteRN(strNombreApp);
                objmantenimento.Identificacion = identificacion;
                if (!objmantenimento.factura())
                {
                    strError = objmantenimento.Error;
                    objmantenimento = null;
                    return false;
                }
                if (!llenarGrid(gvgenerico, objmantenimento.DsDatos.Tables[0]))
                {
                    objmantenimento = null;
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

        #region "Métodos Privados"
        private bool validar(string metodoOrigen)
        {

            switch (metodoOrigen.ToLower())
            {
                case "factura":
                case "mantenimiento":
                    if (identificacion <= 0)
                    {
                        strError = "Debe ingresar un ID mayor a 0";
                        return false;
                    }                    
                   break;

                default:
                    strError = "Caso no válido OPE";
                    return false;
            }
            return true;
        }
        private bool llenarGrid(GridView dvGenerica, DataTable dtDatos)
        {
            try
            {
                
                clsLlenarGrids objLlenar = new clsLlenarGrids();

                if (!objLlenar.llenarGridWeb(dvGenerica, dtDatos))
                {
                    strError = objLlenar.Error;
                    objLlenar = null;
                    return false;
                }
                objLlenar = null;
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

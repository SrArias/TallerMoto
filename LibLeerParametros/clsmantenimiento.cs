using libLlenarGrids;
using LibReglasNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace LibLeerParametros
{
    public class clsmantenimiento
    {
        private int identificacion;
        private string strError;
        private string strNombreApp;

        public int Identificacion { get => identificacion; set => identificacion = value; }

        public clsmantenimiento(string strNombreApp)
        {
            this.strNombreApp = strNombreApp;
            this.identificacion  = 0;
            this.strError = "";
            
        }
        private bool validar(string metodoOrigen)
        {

            switch (metodoOrigen.ToLower())
            {
                case "mantenimiento":
                    if (identificacion <= 0)
                    {
                        strError = "Debe buscar un estudiante para realizar la matrícula";
                        return false;
                    }
                    
                   break;
                case "factura":
                    if (identificacion <= 0)
                    {
                        strError = "Debe buscar un estudiante para realizar la matrícula";
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

        public bool Mantenimiento(GridView gvgenerico)
        {
            try
            {
                
                if (!validar("mantenimiento"))
                {
                    return false;
                }
                
                clsMantenimientoRN objmantenimento = new clsMantenimientoRN(strNombreApp);
                objmantenimento.Identificacion = identificacion;
                if (!objmantenimento.Mantenimiento())
                {
                    strError = objmantenimento.Error;
                    objmantenimento = null;
                    return false;
                }
                if (!llenarGrid(gvgenerico,objmantenimento.DsDatos.Tables[0]))
                {
                    objmantenimento = null;
                    return false;
                }
                return true;

            }catch(Exception ex)
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

                clsMantenimientoRN objmantenimento = new clsMantenimientoRN(strNombreApp);
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
    }
}

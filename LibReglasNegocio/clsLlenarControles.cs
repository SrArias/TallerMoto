﻿using libLlenarCombos;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using libLlenarGrids;

namespace LibReglasNegocio
{
    public class clsLlenarControles
    {
        #region "Atributos"
        private clsLlenarGrids objGrid;
        private SqlParameter[] objDatosTaller;
        private clsLlenarCombos objcnx;
        private DataSet dsDatos;
        private string strError;
        private string strid;
        private string strcampostext;
        private string strvehiculo;
        private int identificacion;
        private int opcion;

        #endregion

        #region "Constructor"
        public clsLlenarControles(string NombreApp)
        {
            this.objGrid = new clsLlenarGrids(NombreApp);
            this.objcnx = new clsLlenarCombos(NombreApp);
            this.strError=string.Empty;
            this.strid=string.Empty;
            this.strcampostext=string.Empty;
            this.strvehiculo=string.Empty;
            this.identificacion=-1;
            this.opcion=-1;
    }

        #endregion

        #region "Propiedades"
        public int Identificacion { get => identificacion; set => identificacion = value; }
        public string Error { get => strError; set => strError = value; }
        public string Vehiculo { get => strvehiculo; set => strvehiculo = value; }
        public int Opcion { get => opcion; set => opcion = value; }

        #endregion

        #region "Métodos Privados"
        private bool AgregarParametros(string MetodoOrigen)
        {
            try
            {
                objDatosTaller = null;

                switch (MetodoOrigen.ToUpper())
                {
                    case "DRPIDEMPLEADO":
                    case "GVEMPLEADOS":

                        break;

                    case "GVMANTENIMIENTO":
                        objDatosTaller = new SqlParameter[1];
                        objDatosTaller[0] = new SqlParameter("vehiculo_id", strvehiculo);
                        break;
                    case "GVVEHIC":
                      
                        break;

                    case "DRPIDMANTENIM":
                    case "DRPIDVEHICULO":
                    case "GVPROV":
                    case "DRPPLACA":
                    case "DRPCLIENTES":
                    case "GVCLIENTES":
                    case "GVREP":                   
                    case "DRPIDPROV":
                    case "DRPPROVID":
                    case "DRPIDREP":

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

        #endregion

        #region "Métodos Públicos"

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
                    case "drpplaca":
                    case "drpidvehiculo":
                    case "drpidmantenim":
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
                        objcnx.ParametrosSQL = objDatosTaller;
                        objcnx.SQL = "sp_getempleados";
                        break;
                    case "drpclientes":
                    
                        strid = "cliente_id";
                        strcampostext = "nombre";
                        objcnx.ParametrosSQL = objDatosTaller;
                        objcnx.SQL = "sp_getclientes";
                        break;
                    case "drpidprov":
                    case "drpprovid":
                        strid = "prov_id";
                        strcampostext = "nombre_compania";
                        objcnx.ParametrosSQL = objDatosTaller;
                        objcnx.SQL = "sp_getproveedor";
                        break;
                    case "drpidrep":
                        strid = "repuesto_id";
                        strcampostext = "nombre_repuesto";
                        objcnx.ParametrosSQL = objDatosTaller;
                        objcnx.SQL = "sp_getrepuesto";
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
                        objGrid.ParametrosSQL = objDatosTaller;
                        break;
                    case "drpClientes":
                    case "gvclientes":
                        objGrid.SQL = "sp_getclientes";
                        break;
                    case "ddlmecanico":
                        strid = "empleado_id";
                        strcampostext = "nombre";
                        objcnx.SQL = "sp_getmecanico";
                        break;
                    case "gvmantenimiento":
                        objGrid.ParametrosSQL = objDatosTaller;
                        objGrid.SQL = "sp_getonemantenimiento";
                        break;
                    case "gvprov":
                        objGrid.SQL = "sp_getproveedor";
                        break;
                    case "gvrep":
                        objGrid.SQL = "sp_getrepuesto";
                        break;
                    case "gvvehic":
                        objGrid.ParametrosSQL = objDatosTaller;
                        objGrid.SQL = "sp_getautos";
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
        #endregion
    }
}

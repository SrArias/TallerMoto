using libConexionBd;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibReglasNegocio
{
    public class clsadminRN
    {
        private int intUsuario_id;
        private string strContrasena;
        private string strVehiculo_id;
        private string strMarca;
        private string strCilindraje;
        private int intModelo;
        private string strColor;
        private string strRefencia;
        private string strNombreC;
        private string strTelefonoC;
        private string strDireccionC;
        private int intEmpleado_id;
        private string strNombreE;
        private string strTelefonoE;
        private string strDireccionE;
        private int intSalarioE;
        private int intProv_id;
        private string strNombreProv;
        private string strNombreContacProv;
        private string strTituloContacProv;
        private string strNumeroContacprov;
        private string strDireccionProv;
        private int intRepuesto_id;
        private string strNombreRep;
        private int intUnidStock;
        private int intUnidOrdenadas;
        private int intPrecioUnid;
        private int intcargo;
        private int intsalario;
        private int intMantenimiento_id;
        private string strDiagnostico;
        private string strProc_Realizado;
        private DateTime datFecha;
        private int intCant_Repuesto;
        private int intPrecio_Mant;
        private string strNombreApp;
        private SqlParameter[] objDatosEscuela;
        private clsConexionBd objcnx;
        private string strError;
        private DataSet dsDatos;


        public int IntUsuario_id { get => intUsuario_id; set => intUsuario_id = value; }
        public string StrContrasena { get => strContrasena; set => strContrasena = value; }
        public string StrVehiculo_id { get => strVehiculo_id; set => strVehiculo_id = value; }
        public string StrMarca { get => strMarca; set => strMarca = value; }
        public string StrCilindraje { get => strCilindraje; set => strCilindraje = value; }
        public int IntModelo { get => intModelo; set => intModelo = value; }
        public string StrColor { get => strColor; set => strColor = value; }
        public string StrRefencia { get => strRefencia; set => strRefencia = value; }
        public string StrNombreC { get => strNombreC; set => strNombreC = value; }
        public string StrTelefonoC { get => strTelefonoC; set => strTelefonoC = value; }
        public string StrDireccionC { get => strDireccionC; set => strDireccionC = value; }

        public string StrNombreE { get => strNombreE; set => strNombreE = value; }
        public string StrTelefonoE { get => strTelefonoE; set => strTelefonoE = value; }
        public string StrDireccionE { get => strDireccionE; set => strDireccionE = value; }
        public int IntSalarioE { get => intSalarioE; set => intSalarioE = value; }
        public int IntProv_id { get => intProv_id; set => intProv_id = value; }
        public string StrNombreProv { get => strNombreProv; set => strNombreProv = value; }
        public string StrNombreContacProv { get => strNombreContacProv; set => strNombreContacProv = value; }
        public string StrTituloContacProv { get => strTituloContacProv; set => strTituloContacProv = value; }
        public string StrNumeroContacprov { get => strNumeroContacprov; set => strNumeroContacprov = value; }
        public string StrDireccionProv { get => strDireccionProv; set => strDireccionProv = value; }
        public string StrNombreRep { get => strNombreRep; set => strNombreRep = value; }
        public int IntUnidStock { get => intUnidStock; set => intUnidStock = value; }
        public int IntUnidOrdenadas { get => intUnidOrdenadas; set => intUnidOrdenadas = value; }
        public int IntPrecioUnid { get => intPrecioUnid; set => intPrecioUnid = value; }
        public int IntCargo { get => intcargo; set => intcargo = value; }
        public int IntSalario { get => intsalario; set => intsalario = value; }
        public string StrDiagnostico { get => strDiagnostico; set => strDiagnostico = value; }
        public string StrProc_Realizado { get => strProc_Realizado; set => strProc_Realizado = value; }
        public DateTime DatFecha { get => datFecha; set => datFecha = value; }
        public int IntCant_Repuesto { get => intCant_Repuesto; set => intCant_Repuesto = value; }
        public int IntPrecio_Mant { get => intPrecio_Mant; set => intPrecio_Mant = value; }
        public string StrError { get => strError; set => strError = value; }
        public DataSet DsDatos { get => dsDatos; set => dsDatos = value; }
        public int IntEmpleado_id { get => intEmpleado_id; set => intEmpleado_id = value; }
        public int IntRepuesto_id { get => intRepuesto_id; set => intRepuesto_id = value; }
        public int IntMantenimiento_id { get => intMantenimiento_id; set => intMantenimiento_id = value; }

        public clsadminRN(string nombreapp)
        {
            strNombreApp = nombreapp;
            objcnx = new clsConexionBd(nombreapp);
            this.intUsuario_id = 0;
            this.strContrasena="";
            this.strVehiculo_id = "";
            this.strMarca = "";
            this.strCilindraje = "";
            this.intModelo = 0;
            this.strColor = "";
            this.strRefencia = "";
            this.strNombreC = "";
            this.strTelefonoC = "";
            this.strDireccionC = "";
            this.intEmpleado_id = 0;
            this.strNombreE = "";
            this.strTelefonoE = "";
            this.strDireccionE = "";
            this.intSalarioE = 0;
            this.intProv_id = 0;
            this.strNombreProv = "";
            this.strNombreContacProv = "";
            this.strTituloContacProv = "";
            this.strNumeroContacprov = "";
            this.strDireccionProv = "";
            this.intRepuesto_id = 0;
            this.strNombreRep = "";
            this.intUnidStock = 0;
            this.intUnidOrdenadas = 0;
            this.intPrecioUnid = 0;
            this.intcargo = 0;
            this.intsalario = 0;
            this.intMantenimiento_id = 0;
            this.strDiagnostico = "";
            this.strProc_Realizado = "";
            this.datFecha = DateTime.Now;
            this.intCant_Repuesto = 0;
            this.intPrecio_Mant = 0;
            this.strNombreApp = "";
    }

    private bool validar(string MetodoOrigen)
        {
            if (string.IsNullOrEmpty(strNombreApp))
            {
                strError = "Se debe enviar el nombre de la aplicación";
                return false;
            }
            switch (MetodoOrigen.ToLower())
            {
                case "user":

                    if (intUsuario_id <= 0)
                    {
                        strError = "Ingrese la id del cliente";
                    }

                    if (StrNombreC == string.Empty)
                    {
                        strError = "Ingrese el nombre del cliente";
                    }

                    if (StrTelefonoC == string.Empty)
                    {
                        strError = "Ingrese el telefono del cliente";
                    }

                    if (StrVehiculo_id == string.Empty)
                    {
                        strError = "Ingrese la placa del vehiculo del cliente";
                    }

                    if (StrContrasena == string.Empty)
                    {
                        strError = "Ingrese una contraseña";
                    }
                    break;

                case "vehiculo":
                    if (StrVehiculo_id == string.Empty)
                    {
                        strError = "La placa del vehiculo no  a sido ingresada correctamente";
                    }
                    if (strMarca == string.Empty)
                    {
                        strError = "la marca del vehiculo no a sido ingresada";
                    }
                    if (StrCilindraje == string.Empty)
                    {
                        strError = "el cilindraje del vehiculo no a sido ingresada";
                    }
                    if (intModelo <= 0)
                    {
                        strError = "El modelo del vehiculo no a sido ingresada";
                    }
                    if (strColor == string.Empty)
                    {
                        strError = "El color del vehiculo no a sido ingresada";
                    }
                    if (strRefencia == string.Empty)
                    {
                        strError = "La Refencia del vehiculo no a sido ingresada";
                    }

                    break;
                case "proveedores":
                    if (intProv_id <= 0)
                    {
                        strError = "El id del proveedor no a sido ingresado";
                    }
                    if (strNombreProv == string.Empty)
                    {
                        strError = "El nombre del proveedor no a sido ingresado";
                    }
                    if (strNombreContacProv == string.Empty)
                    {
                        strError = "El nombre del contacto no a sido ingresado";
                    }
                    if (strTituloContacProv == string.Empty)
                    {
                        strError = "El titulo del contacto no a sido ingresado";
                    }
                    if (strNumeroContacprov == string.Empty)
                    {
                        strError = "El numero del proveedor no a sido ingresado";
                    }
                    if (strDireccionProv == string.Empty)
                    {
                        strError = "La direccion del proveedor no a sido ingresado";
                    }

                    break;
                case "detalle_factura":
                    if (datFecha < new DateTime().Date)
                    {
                        strError = "la fecha  no a sido ingresado";
                    }
                    if (intCant_Repuesto <= -1)
                    {
                        strError = "la cantidad de no a sido ingresado";
                    }
                    if (intPrecio_Mant <= 0)
                    {
                        strError = "El el precio del mantenimiento no a sido ingresado";
                    }
                    //revisar valores auto incrementables tambien en el inset into de la BD ATT: Harol
                    break;
                case "empleado":
                    if (intEmpleado_id <= 0)
                    {
                        strError = "Ingrese la id del empleado";
                    }
                    if (strNombreE == string.Empty)
                    {
                        strError = "Ingrese el nombre del empleado";
                    }
                    if (strTelefonoE == string.Empty)
                    {
                        strError = "Ingrese el telefono del empleado";
                    }
                    if (strDireccionE == string.Empty)
                    {
                        strError = "Ingrese la direccion del empleado";
                    }
                    if (intcargo <= 0)
                    {
                        strError = "Seleccione un cargo";
                    }
                    if (intSalarioE <= 0)
                    {
                        strError = "Ingrese un salario";
                    }
                    if (StrContrasena == string.Empty)
                    {
                        strError = "Ingrese una contraseña";
                    }
                    break;
                case "repuesto":
                    if (strNombreRep == string.Empty)
                    {
                        strError = "Ingrese el nombre del repuesto";
                    }
                    if (intUnidStock <= 0)
                    {
                        strError = "Ingrese las unidades en stock";
                    }
                    if (intUnidOrdenadas <= 0)
                    {
                        strError = "Ingrese las unidades ordenadas";
                    }
                    if (intPrecioUnid <= 0)
                    {
                        strError = "Ingrese el valor por unidad del repuesto";
                    }
                    if (intProv_id <= 0)
                    {
                        strError = "El id del proveedor no a sido ingresado";
                    }

                    break;
                case "mantenimiento":
                    if (StrVehiculo_id == string.Empty)
                    {
                        strError = "La placa del vehiculo no  a sido ingresada correctamente";
                    }
                    if (intEmpleado_id <= 0)
                    {
                        strError = "Ingrese la id del empleado";
                    }
                    if (strDiagnostico == string.Empty)
                    {
                        strError = "Escriba el diagnostico del vehiculo";
                    }
                    if (strProc_Realizado == string.Empty)
                    {
                        strError = "Escriba el procedimiento realizado";
                    }

                    break;
                case "facturas":
                    if (StrVehiculo_id == string.Empty)
                    {
                        strError = "La placa del vehiculo no  a sido ingresada correctamente";
                    }
                    if (intEmpleado_id <= 0)
                    {
                        strError = "Ingrese la id del empleado";
                    }
                    break;
                case "getoneempleado":
                    if (intEmpleado_id <= 0)
                    {
                        strError = "Seleccione el nombre del empleado";
                    }
                    break;
                case "getonecliente":
                    if (intUsuario_id <= 0)
                    {
                        strError = "Seleccione el nombre del  cliente";
                    }
                    break;
                case "getonevehiculo":
                    if (strVehiculo_id == string.Empty)
                    {
                        strError = "La placa del vehiculo no ha sido ingresada correctamente";
                    }
                    break;
                case "getonerespuesto":
                    if (intRepuesto_id <= 0)
                    {
                        strError = "Seleccione el nombre del repuesto";
                    }
                    break;
                case "getoneproveedor":
                    if (intProv_id <= 0)
                    {
                        strError = "Seleccione el nombre de la compañía proveedora";
                    }
                    break;
                case "getonemantenimiento":
                    if (intMantenimiento_id <= 0)
                    {
                        strError = "Seleccione un mantenimiento";
                    }
                    break;

                default:
                    strError = "Caso no válido OPE";
                    return false;
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
                switch (MetodoOrigen.ToUpper())
                {
                    case "USER":
                        objDatosEscuela = new SqlParameter[6];
                        objDatosEscuela[0] = new SqlParameter("cliente_id", intUsuario_id);
                        objDatosEscuela[1] = new SqlParameter("nombre", strNombreC);
                        objDatosEscuela[2] = new SqlParameter("telefono", strTelefonoC);
                        objDatosEscuela[3] = new SqlParameter("direccion", strDireccionC);
                        objDatosEscuela[4] = new SqlParameter("vehiculo_id", strVehiculo_id);
                        objDatosEscuela[5] = new SqlParameter("password", strContrasena);
                        break;
                    case "EMPLEADO":
                        objDatosEscuela = new SqlParameter[7];
                        objDatosEscuela[0] = new SqlParameter("empleado", intEmpleado_id);
                        objDatosEscuela[1] = new SqlParameter("nombre", strNombreE);
                        objDatosEscuela[2] = new SqlParameter("telefono", strTelefonoE);
                        objDatosEscuela[3] = new SqlParameter("direccion", strDireccionE);
                        objDatosEscuela[4] = new SqlParameter("cargo", intcargo);
                        objDatosEscuela[5] = new SqlParameter("salario", intsalario);
                        objDatosEscuela[6] = new SqlParameter("password", strContrasena);
                        break;
                    case "PROVEEDORES":
                        objDatosEscuela = new SqlParameter[6];
                        objDatosEscuela[0] = new SqlParameter("proveedor_id", intProv_id);
                        objDatosEscuela[1] = new SqlParameter("nombre_compañia", strNombreProv);
                        objDatosEscuela[2] = new SqlParameter("nombre_contacto", strNombreContacProv);
                        objDatosEscuela[3] = new SqlParameter("titulo_contacto", strTituloContacProv);
                        objDatosEscuela[4] = new SqlParameter("numero_contacto", strNumeroContacprov);
                        objDatosEscuela[5] = new SqlParameter("direccion", strDireccionProv);
                        break;
                    case "MANTENIMIENTO":
                        objDatosEscuela = new SqlParameter[4];
                        objDatosEscuela[0] = new SqlParameter("Vehículo_id", strVehiculo_id);
                        objDatosEscuela[1] = new SqlParameter("empleado_id", intEmpleado_id);
                        objDatosEscuela[2] = new SqlParameter("diagnostico", strDiagnostico);
                        objDatosEscuela[3] = new SqlParameter("procedimiento_realizado", strProc_Realizado);
                        break;
                    case "REPUESTO":
                        objDatosEscuela = new SqlParameter[5];
                        objDatosEscuela[0] = new SqlParameter("nombre_repuesto", strNombreRep);
                        objDatosEscuela[1] = new SqlParameter("unidades_en_stock", intUnidStock);
                        objDatosEscuela[2] = new SqlParameter("unidades_ordenadas", intUnidOrdenadas);
                        objDatosEscuela[3] = new SqlParameter("precio_por_unidad", intPrecioUnid);
                        objDatosEscuela[4] = new SqlParameter("prov_id", intProv_id);
                        break;
                    case "FACTURA":
                        objDatosEscuela = new SqlParameter[2];
                        objDatosEscuela[0] = new SqlParameter("Vehículo_id", strVehiculo_id);
                        objDatosEscuela[1] = new SqlParameter("empleado_id", intEmpleado_id);
                        break;
                    case "VEHICULO":
                        objDatosEscuela = new SqlParameter[5];
                        objDatosEscuela[0] = new SqlParameter("Vehículo_id", strVehiculo_id);
                        objDatosEscuela[1] = new SqlParameter("marca", strMarca);
                        objDatosEscuela[2] = new SqlParameter("modelo", intModelo);
                        objDatosEscuela[3] = new SqlParameter("color", strColor);
                        objDatosEscuela[4] = new SqlParameter("refencia", strRefencia);
                        break;
                    case " DETALLES_FACTURA":
                        objDatosEscuela = new SqlParameter[3];
                        objDatosEscuela[0] = new SqlParameter("fecha", datFecha);
                        objDatosEscuela[1] = new SqlParameter("cantidad_respuesto", intCant_Repuesto);
                        objDatosEscuela[2] = new SqlParameter("precio_mantenimiento", intPrecio_Mant);
                        //revisar valores auto incrementables 
                        break;
                    case "GETONEEMPLEADO":
                        objDatosEscuela = new SqlParameter[1];
                        objDatosEscuela[0] = new SqlParameter("empleado_id", intEmpleado_id);
                        break;
                    case "GETONECLIENTE":
                        objDatosEscuela = new SqlParameter[1];
                        objDatosEscuela[0] = new SqlParameter("cliente_id", intUsuario_id);
                        break;
                    case "GETONEVEHICULO":
                        objDatosEscuela = new SqlParameter[1];
                        objDatosEscuela[0] = new SqlParameter("Vehículo_id", strVehiculo_id);
                        break;
                    case "GETONEREPUESTO":
                        objDatosEscuela = new SqlParameter[1];
                        objDatosEscuela[0] = new SqlParameter("respuesto_id", intRepuesto_id);
                        break;
                    case "GETONEPROVEEDOR":
                        objDatosEscuela = new SqlParameter[1];
                        objDatosEscuela[0] = new SqlParameter("prov_id", intProv_id);
                        break;
                    case "GETONEMANTENIMIENTO":
                        objDatosEscuela = new SqlParameter[1];
                        objDatosEscuela[0] = new SqlParameter("mantenimiento_id", intMantenimiento_id);
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

        public bool Usuario()
        {
            try
            {
                if (!AgregarParametros("User"))
                {
                    return false;
                }
                objcnx.SQL = "sp_insertcliente";
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
        public bool Empleado()
        {
            try
            {
                if (!AgregarParametros("Empleado"))
                {
                    return false;
                }
                objcnx.SQL = "sp_insertempleado";
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
        public bool Proveedores()
        {
            try
            {
                if (!AgregarParametros("Proveedores"))
                {
                    return false;
                }
                objcnx.SQL = "sp_insertproveedores";
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
        public bool Mantenimiento()
        {
            try
            {
                if (!AgregarParametros("mantenimiento"))
                {
                    return false;
                }
                objcnx.SQL = "sp_insertmatenimiento";
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
        public bool Repuesto()
        {
            try
            {
                if (!AgregarParametros("repuesto"))
                {
                    return false;
                }
                objcnx.SQL = "sp_insertrepuesto";
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
        public bool Vehiculo()
        {
            try
            {
                if (!AgregarParametros("vehiculo"))
                {
                    return false;
                }
                objcnx.SQL = "sp_insertvehiculo";
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
        public bool Factura()
        {
            try
            {
                if (!AgregarParametros("factura"))
                {
                    return false;
                }
                objcnx.SQL = "sp_insertfactura";
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
        public bool Detalle_factura()
        {
            try
            {
                if (!AgregarParametros("factura"))
                {
                    return false;
                }
                objcnx.SQL = "sp_insertdetallefactura";
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
        public bool Obtener_Empleado()
        {
            try
            {
                if (!AgregarParametros("getoneempleado"))
                {
                    return false;
                }
                objcnx.SQL = "sp_getoneempleado";
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
            catch (Exception)
            {

                throw;
            }
        }
        public bool Obtener_Cliente()
        {
            try
            {
                if (!AgregarParametros("getonecliente"))
                {
                    return false;
                }
                objcnx.SQL = "sp_getonecliente";
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
            catch (Exception)
            {

                throw;
            }
        }
        public bool Obtener_Vehiculo()
        {
            try
            {
                if (!AgregarParametros("getonevehiculo"))
                {
                    return false;
                }
                objcnx.SQL = "sp_getonevehiculo";
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
            catch (Exception)
            {

                throw;
            }
        }
        public bool Obtener_Repuesto()
        {
            try
            {
                if (!AgregarParametros("getonerepuesto"))
                {
                    return false;
                }
                objcnx.SQL = "sp_getonerepuesto";
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
            catch (Exception)
            {

                throw;
            }
        }
        public bool Obtener_Proveedor()
        {
            try
            {
                if (!AgregarParametros("getonerepuesto"))
                {
                    return false;
                }
                objcnx.SQL = "sp_getoneproveedor";
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
            catch (Exception)
            {

                throw;
            }
        }
        public bool Obtener_Mantenimiento()
        {
            try
            {
                if (!AgregarParametros("getonemantenimiento"))
                {
                    return false;
                }
                objcnx.SQL = "sp_getonemantenimiento";
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
            catch (Exception)
            {

                throw;
            }
        }

    }
}

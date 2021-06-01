using libConexionBd;
using System;
using System.Data;
using System.Data.SqlClient;

namespace LibReglasNegocio
{
    public class clsadminRN
    {
        #region "Atributos"
        
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
        private int intFactura_id;
        private int intRepuesto_id;
        private string strNombreRep;
        private int intUnidStock;
        private int intUnidOrdenadas;
        private int intPrecioUnid;
        private int intcargo;
        private int intTurno;
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
        #endregion

        #region "Constructor"
         public clsadminRN(string nombreapp)
         {
                strNombreApp = nombreapp;
                objcnx = new clsConexionBd(nombreapp);

        }
        
        #endregion

        #region "Propiedades"
        public int IntUsuario_id { get => intUsuario_id; set => intUsuario_id = value; }
        public string StrContrasena { get => strContrasena; set => strContrasena = value; }
        public string StrVehiculo_id { get => strVehiculo_id; set => strVehiculo_id = value; }
        public string StrMarca { get => strMarca; set => strMarca = value; }
        public string StrCilindraje { get => strCilindraje; set => strCilindraje = value; }
        public int IntModelo { get => intModelo; set => intModelo = value; }
        public int IntTurno { get => intTurno; set => intTurno = value; }
        public string StrColor { get => strColor; set => strColor = value; }
        public string StrRefencia { get => strRefencia; set => strRefencia = value; }
        public string StrNombreC { get => strNombreC; set => strNombreC = value; }
        public string StrTelefonoC { get => strTelefonoC; set => strTelefonoC = value; }
        public string StrDireccionC { get => strDireccionC; set => strDireccionC = value; }
        public int IntFactura_id { get => intFactura_id; set => intFactura_id = value; }
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
        #endregion

        #region "Métodos Privados"
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
                        strError = "Ingrese el id del cliente";
                        return false;
                    }

                    if (StrNombreC == string.Empty)
                    {
                        strError = "Ingrese el nombre del cliente";
                        return false;
                    }

                    if (StrTelefonoC == string.Empty)
                    {
                        strError = "Ingrese el teléfono del cliente";
                        return false;
                    }

                    if (StrVehiculo_id == string.Empty)
                    {
                        strError = "Ingrese la placa de la moto del cliente";
                        return false;
                    }

                    if (StrContrasena == string.Empty)
                    {
                        strError = "Ingrese una contraseña";
                        return false;
                    }
                    break;
                case "userupdate":

                    if (intUsuario_id <= 0)
                    {
                        strError = "Ingrese el id del cliente";
                        return false;
                    }

                    if (StrNombreC == string.Empty)
                    {
                        strError = "Ingrese el nombre del cliente";
                        return false;
                    }

                    if (StrTelefonoC == string.Empty)
                    {
                        strError = "Ingrese el teléfono del cliente";
                        return false;
                    }

                    if (StrVehiculo_id == string.Empty)
                    {
                        strError = "Ingrese la placa del vehículo del cliente";
                        return false;
                    }


                    break;

                case "vehiculo":
                    if (StrVehiculo_id == string.Empty)
                    {
                        strError = "La placa del vehiculo no  ha sido ingresada correctamente";
                        return false;
                    }
                    if (strMarca == string.Empty)
                    {
                        strError = "la marca del vehiculo no ha sido ingresada correctamente";
                        return false;
                    }
                    if (StrCilindraje == string.Empty)
                    {
                        strError = "el cilindraje del vehiculo no ha sido ingresada correctamente";
                        return false;
                    }
                    if (intModelo <= 0)
                    {
                        strError = "El modelo del vehiculo no ha sido ingresada correctamente";
                        return false;
                    }
                    if (strColor == string.Empty)
                    {
                        strError = "El color del vehiculo no ha sido ingresada correctamente";
                        return false;
                    }
                    if (strRefencia == string.Empty)
                    {
                        strError = "La Refencia del vehiculo no ha sido ingresada correctamente";
                        return false;
                    }

                    break;
                case "vehiculoupdate":
                    if (StrVehiculo_id == string.Empty)
                    {
                        strError = "La placa del vehiculo no  ha sido ingresada correctamente";
                        return false;
                    }
                    if (strMarca == string.Empty)
                    {
                        strError = "La marca del vehiculo no ha sido ingresada correctamente";
                        return false;
                    }
                    if (StrCilindraje == string.Empty)
                    {
                        strError = "El cilindraje del vehiculo no ha sido ingresada correctamente";
                        return false;
                    }
                    if (intModelo <= 0)
                    {
                        strError = "El modelo del vehiculo no ha sido ingresado correctamente";
                        return false;
                    }
                    if (strColor == string.Empty)
                    {
                        strError = "El color del vehículo no ha sido ingresado correctamente";
                        return false;
                    }
                    if (strRefencia == string.Empty)
                    {
                        strError = "La Referencia del vehículo no ha sido ingresado correctamente";
                        return false;
                    }

                    break;
                case "proveedores":
                case "updateproveedores":
                    if (intProv_id <= 0)
                    {
                        strError = "El id del proveedor no ha sido ingresado";
                        return false;
                    }
                    if (strNombreProv == string.Empty)
                    {
                        strError = "El nombre del proveedor no ha sido ingresado";
                        return false;
                    }
                    if (strNombreContacProv == string.Empty)
                    {
                        strError = "El nombre del contacto no ha sido ingresado";
                        return false;
                    }
                    if (strTituloContacProv == string.Empty)
                    {
                        strError = "El titulo del contacto no ha sido ingresado";
                        return false;
                    }
                    if (strNumeroContacprov == string.Empty)
                    {
                        strError = "El número del proveedor no ha sido ingresado";
                        return false;
                    }
                    if (strDireccionProv == string.Empty)
                    {
                        strError = "La dirección del proveedor hno a sido ingresado";
                        return false;
                    }
                    break;
                case "detalles_factura":
                    if (datFecha < new DateTime().Date)
                    {
                        strError = "La fecha  no ha sido ingresada";
                        return false;
                    }
                    if (intCant_Repuesto <= -1)
                    {
                        strError = "La cantidad del repuesto no ha sido ingresada";
                        return false;
                    }
                    if (intPrecio_Mant <= 0)
                    {
                        strError = "El  precio del mantenimiento no ha sido ingresado";
                        return false;
                    }
                    break;
                case "empleado":
                    if (intEmpleado_id <= 0)
                    {
                        strError = "Ingrese el id del empleado";
                        return false;
                    }
                    if (strNombreE == string.Empty)
                    {
                        strError = "Ingrese el nombre del empleado";
                        return false;
                    }
                    if (strTelefonoE == string.Empty)
                    {
                        strError = "Ingrese el teléfono del empleado";
                        return false;
                    }
                    if (strDireccionE == string.Empty)
                    {
                        strError = "Ingrese la dirección del empleado";
                        return false;
                    }
                    if (intcargo <= 0)
                    {
                        strError = "Seleccione un cargo";
                        return false;
                    }
                    if (intSalarioE <= 0)
                    {
                        strError = "Ingrese un salario";
                        return false;
                    }
                    if (StrContrasena == string.Empty)
                    {
                        strError = "Ingrese una contraseña";
                        return false;
                    }
                    break;
                case "empleadoupdate":
                    if (intEmpleado_id <= 0)
                    {
                        strError = "Ingrese el id del empleado";
                        return false;
                    }
                    if (strNombreE == string.Empty)
                    {
                        strError = "Ingrese el nombre del empleado";
                        return false;
                    }
                    if (strTelefonoE == string.Empty)
                    {
                        strError = "Ingrese el telefono del empleado";
                        return false;
                    }
                    if (strDireccionE == string.Empty)
                    {
                        strError = "Ingrese la direccion del empleado";
                        return false;
                    }
                    if (intcargo <= 0)
                    {
                        strError = "Seleccione un cargo";
                        return false;
                    }
                    if (intSalarioE <= 0)
                    {
                        strError = "Ingrese un salario";
                        return false;
                    }                
                    break;
                case "repuesto":
                case "repuestoupdate":
                    if (strNombreRep == string.Empty)
                    {
                        strError = "Ingrese el nombre del repuesto";
                        return false;
                    }
                    if (intUnidStock < 0)
                    {
                        strError = "Ingrese las unidades en stock del repuesto";
                        return false;
                    }
                    if (intUnidOrdenadas < 0)
                    {
                        strError = "Ingrese las unidades ordenadas del repuesto";
                        return false;
                    }
                    if (intPrecioUnid <= 0)
                    {
                        strError = "Ingrese el valor por unidad del repuesto";
                        return false;
                    }
                    if (intProv_id <= 0)
                    {
                        strError = "El id del proveedor no ha sido ingresado";
                        return false;
                    }

                    break;
                case "mantenimiento":
                    if (StrVehiculo_id == string.Empty)
                    {
                        strError = "La placa del vehículo no  ha sido ingresada correctamente";
                        return false;
                    }
                    if (intEmpleado_id <= 0)
                    {
                        strError = "Ingrese el id del empleado";
                        return false;
                    }
                    if (strDiagnostico == string.Empty)
                    {
                        strError = "Escriba el diagnóstico del vehículo";
                        return false;
                    }
                    if (strProc_Realizado == string.Empty)
                    {
                        strError = "Escriba el procedimiento realizado";
                        return false;
                    }
                    break;
                case "mantenimientoupdate":
                    if (intMantenimiento_id <= 0)
                    {
                        strError = "El ID debe ser mayor que cero";
                        return false;
                    }
                    if (StrVehiculo_id == string.Empty)
                    {
                        strError = "La placa del vehículo no  ha sido ingresada correctamente";
                        return false;
                    }
                    if (intEmpleado_id <= 0)
                    {
                        strError = "Ingrese el id del empleado";
                        return false;
                    }
                    if (strDiagnostico == string.Empty)
                    {
                        strError = "Escriba el diagnóstico del vehículo";
                        return false;
                    }
                    if (strProc_Realizado == string.Empty)
                    {
                        strError = "Escriba el procedimiento realizado";
                        return false;
                    }

                    break;
                case "facturas":
                    if (StrVehiculo_id == string.Empty)
                    {
                        strError = "La placa del vehículo no  ha sido ingresada correctamente";
                        return false;
                    }
                    if (intEmpleado_id <= 0)
                    {
                        strError = "Ingrese el id del empleado";
                        return false;
                    }
                    break;
                case "getoneempleado":
                    if (intEmpleado_id <= 0)
                    {
                        strError = "Seleccione el nombre del empleado";
                        return false;
                    }
                    break;
                case "getonecliente":
                    if (intUsuario_id <= 0)
                    {
                        strError = "Seleccione el nombre del  cliente";
                        return false;
                    }
                    break;
                case "getonevehiculo":
                    if (strVehiculo_id == string.Empty)
                    {
                        strError = "La placa del vehículo no ha sido ingresada correctamente";
                        return false;
                    }
                    break;
                case "getonerepuesto":
                    if (intRepuesto_id <= 0)
                    {
                        strError = "Seleccione el nombre del repuesto";
                        return false;
                    }
                    break;
                case "getoneproveedor":
                    if (intProv_id <= 0)
                    {
                        strError = "Seleccione el nombre de la compañía proveedora";
                        return false;
                    }
                    break;
                case "getonemantenimiento":
                    if (StrVehiculo_id ==string.Empty)
                    {
                        strError = "Seleccione un mantenimiento";
                        return false;
                    }
                    break;


                default:
                    strError = "Caso no válido RN";
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
                    case "USERUPDATE":
                        objDatosEscuela = new SqlParameter[5];
                        objDatosEscuela[0] = new SqlParameter("cliente_id", intUsuario_id);
                        objDatosEscuela[1] = new SqlParameter("nombre", strNombreC);
                        objDatosEscuela[2] = new SqlParameter("telefono", strTelefonoC);
                        objDatosEscuela[3] = new SqlParameter("direccion", strDireccionC);
                        objDatosEscuela[4] = new SqlParameter("vehiculo_id", strVehiculo_id);
                        break;
                    case "EMPLEADO":
                        objDatosEscuela = new SqlParameter[8];
                        objDatosEscuela[0] = new SqlParameter("empleado_id", intEmpleado_id);
                        objDatosEscuela[1] = new SqlParameter("nombre", strNombreE);
                        objDatosEscuela[2] = new SqlParameter("telefono", strTelefonoE);
                        objDatosEscuela[3] = new SqlParameter("direccion", strDireccionE);
                        objDatosEscuela[4] = new SqlParameter("cargo", intcargo);
                        objDatosEscuela[5] = new SqlParameter("turno", intTurno);
                        objDatosEscuela[6] = new SqlParameter("salario", intSalarioE);
                        objDatosEscuela[7] = new SqlParameter("password", strContrasena);
                        break;
                    case "EMPLEADOUPDATE":
                        objDatosEscuela = new SqlParameter[7];
                        objDatosEscuela[0] = new SqlParameter("empleado_id", intEmpleado_id);
                        objDatosEscuela[1] = new SqlParameter("nombre", strNombreE);
                        objDatosEscuela[2] = new SqlParameter("telefono", strTelefonoE);
                        objDatosEscuela[3] = new SqlParameter("direccion", strDireccionE);
                        objDatosEscuela[4] = new SqlParameter("cargo", intcargo);
                        objDatosEscuela[5] = new SqlParameter("turno", intTurno);
                        objDatosEscuela[6] = new SqlParameter("salario", intSalarioE);
                        break;
                    case "PROVEEDORES":
                    case "UPDATEPROVEEDORES":
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
                        objDatosEscuela[0] = new SqlParameter("vehiculo_id", strVehiculo_id);
                        objDatosEscuela[1] = new SqlParameter("empleado_id", intEmpleado_id);
                        objDatosEscuela[2] = new SqlParameter("diagnostico", strDiagnostico);
                        objDatosEscuela[3] = new SqlParameter("procedimiento", strProc_Realizado);
                        break;
                    case "MANTENIMIENTOUPDATE":
                        objDatosEscuela = new SqlParameter[5];
                        objDatosEscuela[0] = new SqlParameter("vehiculo_id", strVehiculo_id);
                        objDatosEscuela[1] = new SqlParameter("empleado_id", intEmpleado_id);
                        objDatosEscuela[2] = new SqlParameter("diagnostico", strDiagnostico);
                        objDatosEscuela[3] = new SqlParameter("procedimiento", strProc_Realizado);
                        objDatosEscuela[4] = new SqlParameter("mantenimiento_id", intMantenimiento_id);
                        break;
                    case "REPUESTO":
                    case "REPUESTOUPDATE":
                        objDatosEscuela = new SqlParameter[5];
                        objDatosEscuela[0] = new SqlParameter("nombre_repuesto", strNombreRep);
                        objDatosEscuela[1] = new SqlParameter("unidades_en_stock", intUnidStock);
                        objDatosEscuela[2] = new SqlParameter("unidades_ordenadas", intUnidOrdenadas);
                        objDatosEscuela[3] = new SqlParameter("precio_por_unidad", intPrecioUnid);
                        objDatosEscuela[4] = new SqlParameter("prov_id", intProv_id);
                        break;
                    case "FACTURAS":              
                        objDatosEscuela = new SqlParameter[2];
                        objDatosEscuela[0] = new SqlParameter("vehiculo_id", strVehiculo_id);
                        objDatosEscuela[1] = new SqlParameter("empleado_id", intEmpleado_id);
                        break;
                    case "VEHICULO":
                        objDatosEscuela = new SqlParameter[6];
                        objDatosEscuela[0] = new SqlParameter("vehiculo_id", strVehiculo_id);
                        objDatosEscuela[1] = new SqlParameter("marca", strMarca);
                        objDatosEscuela[2] = new SqlParameter("cilindraje", strCilindraje);
                        objDatosEscuela[3] = new SqlParameter("modelo", intModelo);
                        objDatosEscuela[4] = new SqlParameter("color", strColor);
                        objDatosEscuela[5] = new SqlParameter("referencia", strRefencia);
                        break;
                    case "VEHICULOUPDATE":
                        objDatosEscuela = new SqlParameter[6];
                        objDatosEscuela[0] = new SqlParameter("vehiculo_id", strVehiculo_id);
                        objDatosEscuela[1] = new SqlParameter("marca", strMarca);
                        objDatosEscuela[2] = new SqlParameter("cilindraje", strCilindraje);
                        objDatosEscuela[3] = new SqlParameter("modelo", intModelo);
                        objDatosEscuela[4] = new SqlParameter("color", strColor);
                        objDatosEscuela[5] = new SqlParameter("referencia", strRefencia);
                        break;
                    case "DETALLES_FACTURA":                   
                        objDatosEscuela = new SqlParameter[6];
                        objDatosEscuela[0] = new SqlParameter("fecha", datFecha);
                        objDatosEscuela[1] = new SqlParameter("repuesto_id",intRepuesto_id );
                        objDatosEscuela[2] = new SqlParameter("cantidad_repuesto", intCant_Repuesto);
                        objDatosEscuela[3] = new SqlParameter("mantenimiento_id", intMantenimiento_id);
                        objDatosEscuela[4] = new SqlParameter("precio_mantenimiento", intPrecio_Mant);
                        objDatosEscuela[5] = new SqlParameter("factura_id", intFactura_id);
                        
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
                        objDatosEscuela[0] = new SqlParameter("vehiculo_id", strVehiculo_id);
                        break;
                    case "GETONEREPUESTO":
                        objDatosEscuela = new SqlParameter[1];
                        objDatosEscuela[0] = new SqlParameter("repuesto_id", intRepuesto_id);
                        break;
                    case "GETONEPROVEEDOR":
                        objDatosEscuela = new SqlParameter[1];
                        objDatosEscuela[0] = new SqlParameter("prov_id", intProv_id);
                        break;
                    case "GETONEMANTENIMIENTO":
                        objDatosEscuela = new SqlParameter[1];
                        objDatosEscuela[0] = new SqlParameter("vehiculo_id", strVehiculo_id);
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
        public bool Usuario_Update()
        {
            try
            {
                if (!AgregarParametros("UserUpdate"))
                {
                    return false;
                }
                objcnx.SQL = "sp_updatecliente";
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
        public bool Empleado_Update()
        {
            try
            {
                if (!AgregarParametros("EMPLEADOUPDATE"))
                {
                    return false;
                }
                objcnx.SQL = "sp_updateempleado";
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
        public bool Proveedores_Update()
        {
            try
            {
                if (!AgregarParametros("UPDATEPROVEEDORES"))
                {
                    return false;
                }
                objcnx.SQL = "sp_updateproveedores";
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
                objcnx.SQL = "sp_insertmantenimiento";
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

        public bool Mantenimiento_Update()
        {
            try
            {
                if (!AgregarParametros("mantenimientoupdate"))
                {
                    return false;
                }
                objcnx.SQL = "sp_updatemantenimiento";
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
        public bool Repuesto_Update()
        {
            try
            {
                if (!AgregarParametros("repuestoupdate"))
                {
                    return false;
                }
                objcnx.SQL = "sp_updaterepuesto";
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
        public bool Vehiculo_Update()
        {
            try
            {
                if (!AgregarParametros("vehiculoupdate"))
                {
                    return false;
                }
                objcnx.SQL = "sp_updatevehiculo";
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
                if (!AgregarParametros("facturas"))
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
                if (!AgregarParametros("DETALLES_FACTURA"))
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
            catch (Exception ex)
            {

                throw ex;
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
            catch (Exception ex)
            {

                throw ex;
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
            catch (Exception ex)
            {

                throw ex;
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
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Obtener_Proveedor()
        {
            try
            {
                if (!AgregarParametros("getoneproveedor"))
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
            catch (Exception ex)
            {

                throw ex;
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
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

    }
}

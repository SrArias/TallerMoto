using libLlenarGrids;
using LibReglasNegocio;
using System;
using System.Web.UI.WebControls;

namespace LibOperativa
{
    public class clsadminop
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
        private int intCargo;
        private int intTurno;
        private int intSalarioE;
        private int intProv_id;
        private string strNombreProv;
        private string strNombreContacProv;
        private string strTituloContacProv;
        private string strNumeroContacprov;
        private string strDireccionProv;
        private string strNombreRep;
        private int intUnidStock;
        private int intUnidOrdenadas;
        private int intPrecioUnid;
        private string strDiagnostico;
        private string strProc_Realizado;
        private DateTime datFecha;
        private int intCant_Repuesto;
        private int intPrecio_Mant;
        private string strNombreApp;
        private string strError;
        private string resultado;
        private int intRepuesto_id;
        private int intMantenimiento_id;
        private int intFactura_id;
        #endregion

        #region "Propiedades"
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
        public string Resultado { get => resultado; set => resultado = value; }
        public string StrNombreRep { get => strNombreRep; set => strNombreRep = value; }
        public int IntUnidStock { get => intUnidStock; set => intUnidStock = value; }
        public int IntUnidOrdenadas { get => intUnidOrdenadas; set => intUnidOrdenadas = value; }
        public int IntPrecioUnid { get => intPrecioUnid; set => intPrecioUnid = value; }
        public string StrDiagnostico { get => strDiagnostico; set => strDiagnostico = value; }
        public string StrProc_Realizado { get => strProc_Realizado; set => strProc_Realizado = value; }
        public DateTime DatFecha { get => datFecha; set => datFecha = value; }
        public int IntCant_Repuesto { get => intCant_Repuesto; set => intCant_Repuesto = value; }
        public int IntPrecio_Mant { get => intPrecio_Mant; set => intPrecio_Mant = value; }
        public int IntEmpleado_id { get => intEmpleado_id; set => intEmpleado_id = value; }
        public string StrError { get => strError; set => strError = value; }
        public int IntCargo { get => intCargo; set => intCargo = value; }
        public int IntTurno { get => intTurno; set => intTurno = value; }
        public int IntRepuesto_id { get => intRepuesto_id; set => intRepuesto_id = value; }
        public int IntMantenimiento_id { get => intMantenimiento_id; set => intMantenimiento_id = value; }
        public int IntFactura_id { get => intFactura_id; set => intFactura_id = value; }
        #endregion

        #region "Constructor"
        public clsadminop(string nombreapp)
        {
            strNombreApp = nombreapp;

        }
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
                case "user":

                    if (intUsuario_id <= 0)
                    {
                        strError = "Ingrese la id del cliente";
                        return false;
                    }

                    if (StrNombreC == string.Empty)
                    {
                        strError = "Ingrese el nombre del cliente";
                        return false;
                    }

                    if (StrTelefonoC == string.Empty)
                    {
                        strError = "Ingrese el telefono del cliente";
                        return false;
                    }

                    if (StrVehiculo_id == string.Empty)
                    {
                        strError = "Ingrese la placa del vehiculo del cliente";
                        return false;
                    }

                    if (StrContrasena == string.Empty)
                    {
                        strError = "Ingrese una contraseña";
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
                        strError = "La marca del vehiculo no ha sido ingresada";
                        return false;
                    }
                    if (StrCilindraje == string.Empty)
                    {
                        strError = "El cilindraje del vehiculo no ha sido ingresada";
                        return false;
                    }
                    if (intModelo <= 0)
                    {
                        strError = "El modelo del vehiculo no ha sido ingresada";
                        return false;
                    }
                    if (strColor == string.Empty)
                    {
                        strError = "El color del vehiculo no ha sido ingresada";
                        return false;
                    }
                    if (strRefencia == string.Empty)
                    {
                        strError = "La Refencia del vehiculo no ha sido ingresada";
                        return false;
                    }

                    break;
                case "proveedores":
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
                        strError = "La dirección del proveedor no ha sido ingresada";
                        return false;
                    }

                    break;
                case "detalle_factura":
                    if (datFecha < new DateTime().Date)
                    {
                        strError = "La fecha  no ha sido ingresada";
                        return false;
                    }
                    if (intCant_Repuesto <= -1)
                    {
                        strError = "La cantidad de no ha sido ingresado";
                        return false;
                    }
                    if (intPrecio_Mant <= 0)
                    {
                        strError = "El el precio del mantenimiento no ha sido ingresado";
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
                    if (intCargo <= 0)
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
                case "repuesto":
                    if (strNombreRep == string.Empty)
                    {
                        strError = "Ingrese el nombre del repuesto";
                        return false;
                    }
                    if (intUnidStock < 0)
                    {
                        strError = "Ingrese las unidades en stock";
                        return false;
                    }
                    if (intUnidOrdenadas < 0)
                    {
                        strError = "Ingrese las unidades ordenadas";
                        return false;
                    }
                    if (intPrecioUnid <= 0)
                    {
                        strError = "Ingrese el valor por unidad del repuesto";
                        return false;
                    }
                    if (intProv_id <= 0)
                    {
                        strError = "El id del proveedor no a sido ingresado";
                        return false;
                    }

                    break;
                case "mantenimiento":
                    if (StrVehiculo_id == string.Empty)
                    {
                        strError = "La placa del vehiculo no  ha sido ingresada correctamente";
                        return false;
                    }
                    if (intEmpleado_id <= 0)
                    {
                        strError = "Ingrese el id del empleado";
                        return false;
                    }
                    if (strDiagnostico == string.Empty)
                    {
                        strError = "Escriba el diagnóstico del vehiculo";
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
                        strError = "La placa del vehiculo no  a sido ingresada correctamente";
                        return false;
                    }
                    if (intEmpleado_id <= 0)
                    {
                        strError = "Ingrese la id del empleado";
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
                case "getonevehiculo":
                    if (strVehiculo_id == string.Empty)
                    {
                        strError = "Ingrese la placa del vehiculo";
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
                    if (strVehiculo_id == string.Empty)
                    {
                        strError = "Seleccione un mantenimiento";
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

        #region "Métodos Públicos"
        public bool Ingresar_Usuario()
        {
            try
            {
                if (!validar("user"))
                {
                    return false;
                }
                clsadminRN objadminRn = new clsadminRN(strNombreApp);
                objadminRn.IntUsuario_id = intUsuario_id;
                objadminRn.StrNombreC = StrNombreC;
                objadminRn.StrTelefonoC = strTelefonoC;
                objadminRn.StrDireccionC = strDireccionC;
                objadminRn.StrVehiculo_id = strVehiculo_id;
                objadminRn.StrContrasena = "12345";

                if (!objadminRn.Usuario())
                {
                    strError = objadminRn.StrError;
                    objadminRn = null;
                    return false;
                }
                resultado = objadminRn.DsDatos.Tables[0].Rows[0]["mensaje"].ToString();
                objadminRn = null;
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Actualizar_Usuario()
        {
            try
            {
                if (!validar("user"))
                {
                    return false;
                }
                clsadminRN objadminRn = new clsadminRN(strNombreApp);
                objadminRn.IntUsuario_id = intUsuario_id;
                objadminRn.StrNombreC = StrNombreC;
                objadminRn.StrTelefonoC = strTelefonoC;
                objadminRn.StrDireccionC = strDireccionC;
                objadminRn.StrVehiculo_id = strVehiculo_id;

                if (!objadminRn.Usuario_Update())
                {
                    strError = objadminRn.StrError;
                    objadminRn = null;
                    return false;
                }
                resultado = objadminRn.DsDatos.Tables[0].Rows[0]["mensaje"].ToString();
                objadminRn = null;
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Ingresar_Empleado()
        {
            try
            {
                if (!validar("Empleado"))
                {
                    return false;
                }
                clsadminRN objadminRn = new clsadminRN(strNombreApp);
                objadminRn.IntEmpleado_id = intEmpleado_id;
                objadminRn.StrNombreE = StrNombreE;
                objadminRn.StrTelefonoE = strTelefonoE;
                objadminRn.StrDireccionE = strDireccionE;
                objadminRn.IntCargo = intCargo;
                objadminRn.IntTurno = intTurno;
                objadminRn.IntSalarioE = IntSalarioE;
                objadminRn.StrContrasena = "12345";



                if (!objadminRn.Empleado())
                {
                    strError = objadminRn.StrError;
                    objadminRn = null;
                    return false;
                }
                resultado = objadminRn.DsDatos.Tables[0].Rows[0]["mensaje"].ToString();
                objadminRn = null;
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Actualizar_Empleado()
        {
            try
            {
                if (!validar("Empleado"))
                {
                    return false;
                }
                clsadminRN objadminRn = new clsadminRN(strNombreApp);
                objadminRn.IntEmpleado_id = intEmpleado_id;
                objadminRn.StrNombreE = strNombreE;
                objadminRn.StrTelefonoE = strTelefonoE;
                objadminRn.StrDireccionE = strDireccionE;
                objadminRn.IntCargo = intCargo;
                objadminRn.IntTurno = intTurno;
                objadminRn.IntSalarioE = intSalarioE;

                if (!objadminRn.Empleado_Update())
                {
                    strError = objadminRn.StrError;
                    objadminRn = null;
                    return false;
                }
                resultado = objadminRn.DsDatos.Tables[0].Rows[0]["mensaje"].ToString();
                objadminRn = null;
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Ingresar_proveedor()
        {
            try
            {
                if (!validar("proveedores"))
                {
                    return false;
                }
                clsadminRN objadminRn = new clsadminRN(strNombreApp);
                objadminRn.IntProv_id = intProv_id;
                objadminRn.StrNombreProv = strNombreProv;
                objadminRn.StrNombreContacProv = strNombreContacProv;
                objadminRn.StrTituloContacProv = strTituloContacProv;
                objadminRn.StrNumeroContacprov = strNumeroContacprov;
                objadminRn.StrDireccionProv = strDireccionProv;
                if (!objadminRn.Proveedores())
                {
                    strError = objadminRn.StrError;
                    objadminRn = null;
                    return false;
                }
                resultado = objadminRn.DsDatos.Tables[0].Rows[0]["mensaje"].ToString();
                objadminRn = null;
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Actualizar_proveedor()
        {
            try
            {
                if (!validar("proveedores"))
                {
                    return false;
                }
                clsadminRN objadminRn = new clsadminRN(strNombreApp);
                objadminRn.IntProv_id = intProv_id;
                objadminRn.StrNombreProv = strNombreProv;
                objadminRn.StrNombreContacProv = strNombreContacProv;
                objadminRn.StrTituloContacProv = strTituloContacProv;
                objadminRn.StrNumeroContacprov = strNumeroContacprov;
                objadminRn.StrDireccionProv = strDireccionProv;
                if (!objadminRn.Proveedores_Update())
                {
                    strError = objadminRn.StrError;
                    objadminRn = null;
                    return false;
                }
                resultado = objadminRn.DsDatos.Tables[0].Rows[0]["mensaje"].ToString();
                objadminRn = null;
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Ingresar_Mantenimiento()
        {
            try
            {
                if (!validar("mantenimiento"))
                {
                    return false;
                }
                clsadminRN objadminRn = new clsadminRN(strNombreApp);

                objadminRn.StrVehiculo_id = strVehiculo_id;
                objadminRn.IntEmpleado_id = intEmpleado_id;
                objadminRn.StrDiagnostico = strDiagnostico;
                objadminRn.StrProc_Realizado = strProc_Realizado;
                if (!objadminRn.Mantenimiento())
                {
                    strError = objadminRn.StrError;
                    objadminRn = null;
                    return false;
                }
                resultado = objadminRn.DsDatos.Tables[0].Rows[0]["mensaje"].ToString();
                objadminRn = null;
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool Actualizar_Mantenimiento()
        {
            try
            {
                if (!validar("mantenimiento"))
                {
                    return false;
                }
                clsadminRN objadminRn = new clsadminRN(strNombreApp);
                objadminRn.StrVehiculo_id = strVehiculo_id;
                objadminRn.IntEmpleado_id = intEmpleado_id;
                objadminRn.StrDiagnostico = strDiagnostico;
                objadminRn.StrProc_Realizado = strProc_Realizado;
                objadminRn.IntMantenimiento_id = IntMantenimiento_id;
                if (!objadminRn.Mantenimiento_Update())
                {
                    strError = objadminRn.StrError;
                    objadminRn = null;
                    return false;
                }
                resultado = objadminRn.DsDatos.Tables[0].Rows[0]["mensaje"].ToString();
                objadminRn = null;
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool Ingresar_Repuesto()
        {
            try
            {
                if (!validar("repuesto"))
                {
                    return false;
                }
                clsadminRN objadminRn = new clsadminRN(strNombreApp);
                objadminRn.StrNombreRep = strNombreRep;
                objadminRn.IntUnidStock = intUnidStock;
                objadminRn.IntUnidOrdenadas = intUnidOrdenadas;
                objadminRn.IntPrecioUnid = intPrecioUnid;
                objadminRn.IntProv_id = intProv_id;
                if (!objadminRn.Repuesto())
                {
                    strError = objadminRn.StrError;
                    objadminRn = null;
                    return false;
                }
                resultado = objadminRn.DsDatos.Tables[0].Rows[0]["mensaje"].ToString();
                objadminRn = null;
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool Actualizar_Repuesto()
        {
            try
            {
                if (!validar("repuesto"))
                {
                    return false;
                }
                clsadminRN objadminRn = new clsadminRN(strNombreApp);
                objadminRn.StrNombreRep = strNombreRep;
                objadminRn.IntUnidStock = intUnidStock;
                objadminRn.IntUnidOrdenadas = intUnidOrdenadas;
                objadminRn.IntPrecioUnid = intPrecioUnid;
                objadminRn.IntProv_id = intProv_id;
                if (!objadminRn.Repuesto_Update())
                {
                    strError = objadminRn.StrError;
                    objadminRn = null;
                    return false;
                }
                resultado = objadminRn.DsDatos.Tables[0].Rows[0]["mensaje"].ToString();
                objadminRn = null;
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool Ingresar_factura()
        {
            try
            {
                if (!validar("facturas"))
                {
                    return false;
                }
                clsadminRN objadminRn = new clsadminRN(strNombreApp);
                objadminRn.StrVehiculo_id = strVehiculo_id;
                objadminRn.IntEmpleado_id = intEmpleado_id;
                if (!objadminRn.Factura())
                {
                    strError = objadminRn.StrError;
                    objadminRn = null;
                    return false;
                }
                resultado = objadminRn.DsDatos.Tables[0].Rows[0]["factura_id"].ToString();
                objadminRn = null;
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Ingresar_Vehiculo()
        {
            try
            {
                if (!validar("vehiculo"))
                {
                    return false;
                }
                clsadminRN objadminRn = new clsadminRN(strNombreApp);
                objadminRn.StrVehiculo_id = strVehiculo_id;
                objadminRn.StrMarca = strMarca;
                objadminRn.StrCilindraje = strCilindraje;
                objadminRn.IntModelo = intModelo;
                objadminRn.StrColor = strColor;
                objadminRn.StrRefencia = strRefencia;
                if (!objadminRn.Vehiculo())
                {
                    strError = objadminRn.StrError;
                    objadminRn = null;
                    return false;
                }
                resultado = objadminRn.DsDatos.Tables[0].Rows[0]["mensaje"].ToString();
                objadminRn = null;
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool Actualizar_Vehiculo()
        {
            try
            {
                if (!validar("vehiculo"))
                {
                    return false;
                }
                clsadminRN objadminRn = new clsadminRN(strNombreApp);
                objadminRn.StrVehiculo_id = strVehiculo_id;
                objadminRn.StrMarca = strMarca;
                objadminRn.StrCilindraje = strCilindraje;
                objadminRn.IntModelo = intModelo;
                objadminRn.StrColor = strColor;
                objadminRn.StrRefencia = strRefencia;
                if (!objadminRn.Vehiculo_Update())
                {
                    strError = objadminRn.StrError;
                    objadminRn = null;
                    return false;
                }
                resultado = objadminRn.DsDatos.Tables[0].Rows[0]["mensaje"].ToString();
                objadminRn = null;
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool Ingresar_Detalle_factura(GridView gvGenerico)
        {
            try
            {
                if (!validar("detalle_factura"))
                {
                    return false;
                }
                clsadminRN objadminRn = new clsadminRN(strNombreApp);
                objadminRn.DatFecha = datFecha;
                objadminRn.IntRepuesto_id = intRepuesto_id;
                objadminRn.IntMantenimiento_id = intMantenimiento_id;
                objadminRn.IntCant_Repuesto = intCant_Repuesto;
                objadminRn.IntPrecio_Mant = intPrecio_Mant;
                objadminRn.IntFactura_id = intFactura_id;
                if (!objadminRn.Detalle_factura())
                {
                    strError = objadminRn.StrError;
                    objadminRn = null;
                    return false;
                }
                resultado = objadminRn.DsDatos.Tables[0].Rows[0]["mensaje"].ToString();

                clsLlenarGrids objllenar = new clsLlenarGrids();
                if (objadminRn.DsDatos.Tables.Count > 1)
                {
                    if (!objllenar.llenarGridWeb(gvGenerico, objadminRn.DsDatos.Tables[1]))
                    {
                        StrError = objllenar.Error;
                        objllenar = null;
                        return false;
                    }
                }
                objllenar = null;
                objadminRn = null;
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public bool getone_empleado()
        {
            try
            {
                if (!validar("getoneempleado"))
                {
                    return false;
                }
                clsadminRN objadminRn = new clsadminRN(strNombreApp);
                objadminRn.IntEmpleado_id = intEmpleado_id;
                if (!objadminRn.Obtener_Empleado())
                {
                    strError = objadminRn.StrError;
                    objadminRn = null;
                    return false;
                }
                intEmpleado_id = int.Parse(objadminRn.DsDatos.Tables[0].Rows[0]["empleado_id"].ToString());
                strDireccionE = objadminRn.DsDatos.Tables[0].Rows[0]["direccion"].ToString();
                strNombreE = objadminRn.DsDatos.Tables[0].Rows[0]["nombre"].ToString();
                strTelefonoE = objadminRn.DsDatos.Tables[0].Rows[0]["telefono"].ToString();
                intCargo = int.Parse(objadminRn.DsDatos.Tables[0].Rows[0]["cargo_id"].ToString());
                intTurno = int.Parse(objadminRn.DsDatos.Tables[0].Rows[0]["turno_id"].ToString());
                intSalarioE = int.Parse(objadminRn.DsDatos.Tables[0].Rows[0]["salario"].ToString());
                objadminRn = null;
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool getone_cliente()
        {
            try
            {
                if (!validar("getonecliente"))
                {
                    return false;
                }
                clsadminRN objadminRn = new clsadminRN(strNombreApp);
                objadminRn.IntUsuario_id = intUsuario_id;
                if (!objadminRn.Obtener_Cliente())
                {
                    strError = objadminRn.StrError;
                    objadminRn = null;
                    return false;
                }
                intUsuario_id = int.Parse(objadminRn.DsDatos.Tables[0].Rows[0]["cliente_id"].ToString());
                strDireccionC = objadminRn.DsDatos.Tables[0].Rows[0]["direccion"].ToString();
                strNombreC = objadminRn.DsDatos.Tables[0].Rows[0]["nombre"].ToString();
                strTelefonoC = objadminRn.DsDatos.Tables[0].Rows[0]["telefono"].ToString();
                strVehiculo_id = objadminRn.DsDatos.Tables[0].Rows[0]["vehiculo_id"].ToString();
                objadminRn = null;
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool getone_vehiculo()
        {
            try
            {
                if (!validar("getonevehiculo"))
                {
                    return false;
                }
                clsadminRN objadminRn = new clsadminRN(strNombreApp);
                objadminRn.StrVehiculo_id = strVehiculo_id;
                if (!objadminRn.Obtener_Vehiculo())
                {
                    strError = objadminRn.StrError;
                    objadminRn = null;
                    return false;
                }
                strVehiculo_id = objadminRn.DsDatos.Tables[0].Rows[0]["vehiculo_id"].ToString();
                strMarca = objadminRn.DsDatos.Tables[0].Rows[0]["marca"].ToString();
                strCilindraje = objadminRn.DsDatos.Tables[0].Rows[0]["cilindraje"].ToString();
                intModelo = int.Parse(objadminRn.DsDatos.Tables[0].Rows[0]["modelo"].ToString());
                strColor = objadminRn.DsDatos.Tables[0].Rows[0]["color"].ToString();
                strRefencia = objadminRn.DsDatos.Tables[0].Rows[0]["referencia"].ToString();
                
                objadminRn = null;
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool getone_repuesto()
        {
            try
            {
                if (!validar("getonerepuesto"))
                {
                    return false;
                }
                clsadminRN objadminRn = new clsadminRN(strNombreApp);
                objadminRn.IntRepuesto_id = intRepuesto_id;
                if (!objadminRn.Obtener_Repuesto())
                {
                    strError = objadminRn.StrError;
                    objadminRn = null;
                    return false;
                }
                intRepuesto_id = int.Parse(objadminRn.DsDatos.Tables[0].Rows[0]["repuesto_id"].ToString());
                strNombreRep = objadminRn.DsDatos.Tables[0].Rows[0]["nombre_repuesto"].ToString();
                intUnidStock = int.Parse(objadminRn.DsDatos.Tables[0].Rows[0]["unidades_en_stock"].ToString());
                intUnidOrdenadas = int.Parse(objadminRn.DsDatos.Tables[0].Rows[0]["unidades_ordenadas"].ToString());
                intPrecioUnid = int.Parse(objadminRn.DsDatos.Tables[0].Rows[0]["precio_por_unidad"].ToString());
                strNombreProv = objadminRn.DsDatos.Tables[0].Rows[0]["nombre_compania"].ToString();
                objadminRn = null;
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool getone_proveedor()
        {
            try
            {
                if (!validar("getoneproveedor"))
                {
                    return false;
                }
                clsadminRN objadminRn = new clsadminRN(strNombreApp);
                objadminRn.IntProv_id = intProv_id;
                if (!objadminRn.Obtener_Proveedor())
                {
                    strError = objadminRn.StrError;
                    objadminRn = null;
                    return false;
                }
                intProv_id = int.Parse(objadminRn.DsDatos.Tables[0].Rows[0]["prov_id"].ToString());
                strNombreProv = objadminRn.DsDatos.Tables[0].Rows[0]["nombre_compania"].ToString();
                strNombreContacProv = objadminRn.DsDatos.Tables[0].Rows[0]["nombre_contacto"].ToString();
                strTituloContacProv = objadminRn.DsDatos.Tables[0].Rows[0]["titulo_contacto"].ToString();
                strNumeroContacprov = objadminRn.DsDatos.Tables[0].Rows[0]["numero_contacto"].ToString();
                strDireccionProv = objadminRn.DsDatos.Tables[0].Rows[0]["direccion"].ToString();
                objadminRn = null;
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool getone_Mantenimiento(GridView gvgenerico)
        {
            try
            {
                if (!validar("getonemantenimiento"))
                {
                    return false;
                }
                clsadminRN objadminRn = new clsadminRN(strNombreApp);
                objadminRn.StrVehiculo_id = strVehiculo_id;
                if (!objadminRn.Obtener_Mantenimiento())
                {
                    strError = objadminRn.StrError;
                    objadminRn = null;
                    return false;
                }
                strNombreE = objadminRn.DsDatos.Tables[0].Rows[0]["nombre"].ToString();
                clsLlenarGrids objllenar = new clsLlenarGrids();
                if (!objllenar.llenarGridWeb(gvgenerico, objadminRn.DsDatos.Tables[0]))
                {
                    objadminRn = null;
                    objllenar = null;
                    return false;
                }

                objadminRn = null;
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
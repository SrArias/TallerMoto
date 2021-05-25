using LibReglasNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibOperativa
{
    public class clsadminop
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
        private int intCargo;
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

        public clsadminop(string nombreapp)
        {
            strNombreApp = nombreapp;
        }
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
                    if (intCargo <= 0)
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
                default:
                    strError = "Caso no válido OPE";
                    return false;
            }
            return true;
        }
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
                objadminRn.StrContrasena = strContrasena;

                if (!objadminRn.Usuario())
                {
                    strError = objadminRn.StrError;
                    objadminRn = null;
                    return false;
                }
                resultado = objadminRn.DsDatos.Tables[0].Rows[0]["@mensaje"].ToString();
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
                objadminRn.IntEmpleado_id = intUsuario_id;
                objadminRn.StrNombreE = StrNombreE;
                objadminRn.StrTelefonoE = strTelefonoE;
                objadminRn.StrDireccionE = strDireccionE;
                objadminRn.IntCargo = intCargo;
                objadminRn.IntSalario = IntSalarioE;
                objadminRn.StrContrasena = strContrasena;



                if (!objadminRn.Empleado())
                {
                    strError = objadminRn.StrError;
                    objadminRn = null;
                    return false;
                }
                resultado = objadminRn.DsDatos.Tables[0].Rows[0]["@mensaje"].ToString();
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
                resultado = objadminRn.DsDatos.Tables[0].Rows[0]["@mensaje"].ToString();
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
                resultado = "";
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
                resultado = "";
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
                if (!validar("factura"))
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
                objadminRn.IntModelo = intModelo;
                objadminRn.StrColor = strColor;
                objadminRn.StrRefencia = strRefencia;
                if (!objadminRn.Vehiculo())
                {
                    strError = objadminRn.StrError;
                    objadminRn = null;
                    return false;
                }
                resultado = "";
                objadminRn = null;
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool Ingresar_Detalle_factura()
        {
            try
            {
                if (!validar("detalle_factura"))
                {
                    return false;
                }
                clsadminRN objadminRn = new clsadminRN(strNombreApp);
                objadminRn.DatFecha = datFecha;
                objadminRn.IntCant_Repuesto = intCant_Repuesto;
                objadminRn.IntPrecio_Mant = intPrecio_Mant;
                if (!objadminRn.Detalle_factura())
                {
                    strError = objadminRn.StrError;
                    objadminRn = null;
                    return false;
                }
                resultado = "";
                objadminRn = null;
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}

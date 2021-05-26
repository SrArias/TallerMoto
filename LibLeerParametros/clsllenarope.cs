using LibReglasNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace LibOperativa
{
    public class clsllenarope
    {
        private string strNombreApp;
        private string strError;
        private int intidentificacion;
        private int opcion;

        public int Identificacion { get => intidentificacion; set => intidentificacion = value; }
        public int Opcion { get => opcion; set => opcion = value; }

        public bool llenarGrid(GridView gvGenerico)
        {
            try
            {
                clsLlenarControles objLnRn = new clsLlenarControles(strNombreApp);

                objLnRn.Opcion = opcion;

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


        public clsllenarope(string nombreapp)
        {
            strNombreApp = nombreapp;
            strError = string.Empty;
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
    }
}

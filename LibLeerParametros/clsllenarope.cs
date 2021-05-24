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
        public clsllenarope(string nombreapp)
        {
            strNombreApp = nombreapp;
            strError = string.Empty;
        }

        public int Identificacion { get => intidentificacion; set => intidentificacion = value; }

        public bool llenarDrop(DropDownList ddlGenerico)
        {
            try
            {
                clsLlenarControles objLnRn = new clsLlenarControles(strNombreApp);
                

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

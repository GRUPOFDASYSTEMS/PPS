using System;
using System.Collections;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;




using System.Data.SqlClient;




namespace Agros
{


    public class puente
    {

        public string elimina(string id, string tabla)
        {
            System.Windows.Forms.DialogResult a;
            string res, respuesta;
            

            a = System.Windows.Forms.MessageBox.Show("¿Seguro Desea Eliminar Este Registro?", "Confirme Su Accion", System.Windows.Forms.MessageBoxButtons.YesNo);
            res = a.ToString();

            if (res.Equals("Yes"))
            {
                respuesta = borrar_id(id, tabla);
            
            }
            else
                respuesta = "No";

            return respuesta;
        }




        protected string borrar_id(string id, string tabla)
        {
            string respuesta;
            
            
            

            linkeo linker = new linkeo();
            respuesta = linker.borrado_por_tabla_e_id(tabla, id);
            
            return respuesta;
        }




    }
}
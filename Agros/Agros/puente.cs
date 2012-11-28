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
        linkeo linker = new linkeo();


        


        public bool cambiar_estado( string id, string cual_estado, string que_tabla) {

            if (id.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Debe Marcar Un Item Antes de Continuar");
                //si hay tiempo luego implementar esto
                //string i = "<script>window.alert('";
                //string f = "');</script>";
                //string 
                //mensaje_error = i + mensaje_error + f;


            }

            else
            {
                string id_valor = " id=" + id;

                int valor;

                
                ArrayList campos_y_valores = new ArrayList();

                
                
                valor = linker.obtener_id(cual_estado);

                //agrego datos
                campos_y_valores.Add("id_estado="); //
                campos_y_valores.Add(valor);

                id = linker.actualizacion_personalizada(que_tabla, id_valor, campos_y_valores);



                return true;
            }

        return false;
        }

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
            
            respuesta = linker.borrado_por_tabla_e_id(tabla, id);
            
            return respuesta;
        }




    }
}
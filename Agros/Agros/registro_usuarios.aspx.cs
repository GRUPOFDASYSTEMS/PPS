using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Agros
{
    public partial class registro_usuarios : System.Web.UI.Page
    {
        /*global*/
        linkeo linker = new linkeo();


        protected void Page_Load(object sender, EventArgs e)
        {
            
        }




        protected void Button1_Click(object sender, EventArgs e)
        {
            ArrayList campos = new ArrayList();
            ArrayList datos = new ArrayList();
            string resultado;

            //especifico campos
            campos.Add("nombre, ");
            campos.Add("perfil, ");
            campos.Add("id_estado, ");
            campos.Add("password ");

            //recolecto datos             
            datos.Add("'");
            datos.Add(this.nom.Text);
            datos.Add("'");
            datos.Add(" , ");
            datos.Add(this.DropDownList1.SelectedValue);//cf int
            datos.Add(" , ");
            datos.Add("1");
            datos.Add(" , ");
            datos.Add("'");
            datos.Add(this.clave.Valor);//raz varchar
            datos.Add("'");


            resultado = linker.insercion_de_dataset("usuario", campos, datos);
            //Label1.Text = resultado;
            string[] devolucion = new string[3];
            devolucion = linker.revisar_error(resultado, "INS", "La Registracion Del Usuario Ha Sido Exitosa", "Atencion Ocurrio Un Error Al Intentar Ejecutar La Transaccion", "registro_usuarios.aspx", "registro_usuarios.aspx");


            if (devolucion[0].Equals("0"))
                Session["mensaje_error"] = devolucion[1];
            else
                Session["mensaje_exito"] = devolucion[1];

            Response.Redirect(devolucion[2]);


        }

























    }
}

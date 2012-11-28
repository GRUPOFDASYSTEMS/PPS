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
    public partial class abmservicios_in : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            linkeo linker = new linkeo();
            ArrayList campos = new ArrayList();
            ArrayList datos = new ArrayList();
            string resultado;


            //especifico campos
            campos.Add("nombre_servicio, ");
            campos.Add("descripcion, ");
            campos.Add("descuento ");
            

            //recolecto datos             
            datos.Add(" ' ");
            datos.Add(this.TextBox1.Text);//des
            datos.Add(" ' ");
            datos.Add(" , ");
            datos.Add(" ' ");
            datos.Add(this.TextBox2.Text);//com
            datos.Add(" ' ");
            datos.Add(" , ");
            datos.Add(this.TextBox3.Text);//ra um



            resultado = linker.insercion_de_dataset("servicio", campos, datos);
            Label1.Text = resultado;
            string[] devolucion = new string[3];
            devolucion = linker.revisar_error(resultado, "INS", "Se Ha Guardado El Servicio Correctamente. Puede Continuar Agregando Servicios, O Finalizar y Editar Sus Detalles En La Pagina De Edicion Servicios", "Atencion Ocurrio Un Error Al Intentar Ejecutar La Transaccion", "abmservicios_in.aspx", "abmservicios_in.aspx");


            if (devolucion[0].Equals("0"))
                Session["mensaje_error"] = devolucion[1];
            else
                Session["mensaje_exito"] = devolucion[1];

            Response.Redirect(devolucion[2]);


        }
    }
}

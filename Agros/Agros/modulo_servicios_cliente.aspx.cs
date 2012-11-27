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
    public partial class modulo_servicios_cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            linkeo linker = new linkeo();
            ArrayList campos = new ArrayList();
            ArrayList datos = new ArrayList();
            string resultado, estado;
            int id;



            campos.Add("nombre_corto, ");
            campos.Add("comentario,");
            campos.Add("fecha_solicitud, ");
            campos.Add("id_cliente, ");
            campos.Add("id_estado ");


            datos.Add(" ' ");
            if (TextBox1.Text.Length>9)
                datos.Add(TextBox1.Text.Substring(0,9));
            else
                datos.Add(TextBox1.Text.Substring(0, TextBox1.Text.Length));

            datos.Add(" ' ");
            datos.Add(" , ");
            datos.Add(" ' ");
            if (TextBox2.Text.Length > 49)
                datos.Add(TextBox2.Text.Substring(0, 49));
            else
                datos.Add(TextBox2.Text.Substring(0, TextBox2.Text.Length));
            datos.Add(" ' ");
            datos.Add(" , ");

            DateTime fecha = DateTime.Now;
            string fechas = fecha.ToString("yyyyMMdd");
            datos.Add(" ' ");
            datos.Add(fechas);
            datos.Add(" ' ");
            datos.Add(" , ");
            datos.Add(Session["cliente"].ToString());
            datos.Add(" , ");
            estado = linker.obtener_dato_especificado("select * from estados where descripcion='En Proceso de creacion' and tema='orden_servicio'",0);
            datos.Add(estado);


            


            resultado = linker.insercion_de_dataset("orden_de_servicio", campos, datos);

            Label1.Text = resultado;

            string[] devolucion = new string[3];
            devolucion = linker.revisar_error(resultado, "INS", "Orden Agregada Correctamente. Puede Continuar Generando Ordenes Si Lo Desea, O Terminar La Carga Con El Boton Finalizar.", "Atencion Ocurrio Un Error Al Intentar Ejecutar La Transaccion", "modulo_servicios_cliente.aspx", "modulo_servicios_cliente.aspx");


            if (devolucion[0].Equals("0"))
                Session["mensaje_error"] = devolucion[1];
            else
                Session["mensaje_exito"] = devolucion[1];

            Response.Redirect(devolucion[2]);



        }
    }
}

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
    public partial class abmservicios_detalle_in : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            linkeo linker = new linkeo();
            ArrayList campos = new ArrayList();
            ArrayList datos = new ArrayList();
            string resultado;


            //especifico campos
            campos.Add("descripcion, ");
            campos.Add("tiempo_horas_hombre, ");
            campos.Add("precio, ");
            campos.Add("id_servicio ");

            //recolecto datos             
            datos.Add(" ' ");
            datos.Add(this.TextBox1.Text);//des
            datos.Add(" ' ");
            datos.Add(" , ");
            datos.Add(" ' ");
            datos.Add(this.TextBox2.Text);//thh
            datos.Add(" ' ");
            datos.Add(" , ");
            datos.Add(this.TextBox3.Text);//pre
            datos.Add(" , ");
            datos.Add(this.DropDownList1.SelectedValue);//ids
            

            resultado = linker.insercion_de_dataset("detalle_servicio", campos, datos);
            Label1.Text = resultado;
            //if ok salvar.enabled=false

            string[] devolucion = new string[3];
            devolucion = linker.revisar_error(resultado, "INS", "Se Ha Guardado El Servicio Correctamente. Puede Continuar Agregando Servicios, O Finalizar y Editar Sus Detalles En La Pagina De Edicion Servicios", "Atencion Ocurrio Un Error Al Intentar Ejecutar La Transaccion", "abmservicios_detalle_in.aspx", "abmservicios_detalle_in.aspx");


            if (devolucion[0].Equals("0"))
                Session["mensaje_error"] = devolucion[1];
            else
                Session["mensaje_exito"] = devolucion[1];

            Response.Redirect(devolucion[2]);

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            string i = "<script>window.alert('";
            string f = "');</script>";
            string mensaje_error = i + "Primero Debe Salvar El Servicio Especifico Actual, Presionando El Boton Salvar" + f;
            string idds = Session["id_detalle_servicio"].ToString();

            if (idds.Equals("0"))
                Response.Write(mensaje_error);
            else
                Response.Redirect("abmservicios_agregar_producto_necesario.aspx");


        }
    }
}

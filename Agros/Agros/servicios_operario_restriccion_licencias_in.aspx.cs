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
    public partial class servicios_operario_restriccion_licencias_in : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lusuario.Text = Session["usuario"].ToString();
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            linkeo linker = new linkeo();
            ArrayList campos = new ArrayList();
            ArrayList datos = new ArrayList();
            string resultado;
            int id;
            //DateTime fecha = Convert.ToDatetime(this.Calendar1.SelectedDate.ToShortDateString());



            string fecha = Calendar1.SelectedDate.ToString("yyyyMMdd");
            //especifico campos
            campos.Add("fecha, ");
            campos.Add("tiempo_inicial, ");
            campos.Add("tiempo_final, ");
            campos.Add("descripcion, ");
            campos.Add("id_usuario ");

            //recolecto datos
            //datos.Add("CONVERT(varchar, CAST(SUBSTRING(");
            datos.Add(" ' ");
            //datos.Add(this.Calendar1.SelectedDate.ToShortDateString());//fecha   .SelectedDate.Date
            datos.Add(fecha);
            datos.Add(" ' ");
            //datos.Add(" , 0, 10) AS datetime), 103) ");
            datos.Add(" , ");
            datos.Add(" ' ");
            datos.Add(this.TextBox2.Text);//tiempo
            datos.Add(" ' ");
            datos.Add(" , ");
            datos.Add(" ' ");
            datos.Add(this.TextBox3.Text);//tiempo
            datos.Add(" ' ");
            datos.Add(" , ");
            datos.Add(" ' ");
            datos.Add(this.TextBox4.Text);//des
            datos.Add(" ' ");
            datos.Add(" , ");
            datos.Add(this.DropDownList1.SelectedValue);//idu


            resultado = linker.insercion_de_dataset("restriccion_disponibilidad_usuario", campos, datos);
            Label1.Text = resultado;


        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            string fecha2 = String.Format("{0:yyyyMMdd}", this.Calendar1.SelectedDate.ToShortDateString());
            Label2.Text = "Fecha Seleccionada: " + fecha2;
        }
    }
}

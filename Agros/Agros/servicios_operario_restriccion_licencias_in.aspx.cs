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



            string fecha = Calendar1.SelectedDate.ToString("yyyyMMdd");
            string fecha2 = Calendar2.SelectedDate.ToString("yyyyMMdd");

            //especifico campos
            campos.Add("fecha_registracion, ");
            campos.Add("fecha_inicial, ");
            campos.Add("fecha_final, ");
            campos.Add("descripcion, ");
            campos.Add("id_usuario ");
            DateTime fecha_actual = DateTime.Now;
            string fa = fecha_actual.ToShortDateString();
            //recolecto datos
            datos.Add(" ' ");
            datos.Add(fa);
            datos.Add(" ' ");
            datos.Add(" , ");
            datos.Add(" ' ");
            datos.Add(fecha);//tiempo inicial
            datos.Add(" ' ");
            datos.Add(" , ");
            datos.Add(" ' ");
            datos.Add(fecha2);//tiempo final
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
            string fecha = String.Format("{0:yyyyMMdd}", this.Calendar1.SelectedDate.ToShortDateString());
            f_in.Text = "Fecha Seleccionada: " + fecha;
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            string fecha2 = String.Format("{0:yyyyMMdd}", this.Calendar2.SelectedDate.ToShortDateString());
            f_out.Text = "Fecha Seleccionada: " + fecha2;

        }
    }
}

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
            int id;

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




        }
    }
}

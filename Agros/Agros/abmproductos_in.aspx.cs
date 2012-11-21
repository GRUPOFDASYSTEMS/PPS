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
    public partial class abmproductos_in : System.Web.UI.Page
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
            int id;

            //especifico campos
            campos.Add("descripcion, ");
            campos.Add("unidad_medida, ");
            campos.Add("racion_unidad_medida, ");
            campos.Add("comentario ");

            //recolecto datos             
            datos.Add(" ' ");
            datos.Add(this.TextBox1.Text);//des
            datos.Add(" ' ");
            datos.Add(" , ");
            datos.Add(this.DropDownList1.SelectedValue);//um
            datos.Add(" , ");
            datos.Add(this.TextBox2.Text);//ra um
            datos.Add(" , ");
            datos.Add(" ' ");
            datos.Add(this.TextBox5.Text);//com
            datos.Add(" ' ");


            resultado = linker.insercion_de_dataset("productos", campos, datos);
            Label1.Text = resultado;



            id = linker.obtener_id("productos");


            campos.RemoveRange(0, campos.Count);
            datos.RemoveRange(0, datos.Count);


            //especifico campos
            campos.Add("cantidad, ");
            campos.Add("indice_repo, ");
            campos.Add("comentario, ");
            campos.Add("id_producto ");

            //recolecto datos                 
            datos.Add(this.TextBox3.Text);//des
            datos.Add(" , ");
            datos.Add(this.TextBox4.Text);//um
            datos.Add(" , ");
            datos.Add(" ' ");
            datos.Add("stock inicial");//ra um
            datos.Add(" ' ");
            datos.Add(" , ");
            datos.Add(id);

            resultado = linker.insercion_de_dataset("stock", campos, datos);
            Label2.Text = resultado;


        }
    }
}

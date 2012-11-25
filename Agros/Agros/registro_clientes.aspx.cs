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
    public partial class registro_clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cliente"].ToString().Equals("0"))
            {
                backtoindexcliente.Visible = false;

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            linkeo linker = new linkeo();
            ArrayList campos = new ArrayList();
            ArrayList datos = new ArrayList();
            string resultado;

            //especifico campos
            campos.Add("cuit, ");
            campos.Add("password, ");
            campos.Add("razon_social, ");
            campos.Add("direccion, ");
            campos.Add("condicion_iva, ");
            campos.Add("email, ");
            campos.Add("id_estado, ");
            campos.Add("operario_favorito");

            //recolecto datos             
            datos.Add(this.TextBox1.Text);//cuit int
            datos.Add(" , ");
            datos.Add(this.TextBox2.Text);//cla  int
            datos.Add(" , ");
            datos.Add(" ' ");
            datos.Add(this.TextBox3.Text);//raz varchar
            datos.Add(" ' ");
            datos.Add(" , ");
            datos.Add(" ' ");
            datos.Add(this.TextBox4.Text);//dir varchar
            datos.Add(" ' ");
            datos.Add(" , ");
            datos.Add(this.DropDownList1.SelectedValue);//cf int
            datos.Add(" , ");
            datos.Add(" ' ");
            datos.Add(this.TextBox5.Text);//email varchar
            datos.Add(" ' ");
            datos.Add(" , ");
            datos.Add("1");
            datos.Add(" , ");
            datos.Add("1");


            resultado =linker.insercion_de_dataset("cliente", campos, datos);
            Label1.Text = resultado;
        }



    }
}

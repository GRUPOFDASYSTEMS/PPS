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
//using System.Windows.Forms;

namespace Agros
{
    public partial class listar_clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


           
        }
       



        protected void ObjectDataSource2_Filtering(object sender, ObjectDataSourceFilteringEventArgs e)
        {
            
            string consultar;

                e.ParameterValues.Clear();
                consultar = "select c.id as id, c.razon_social as 'Razon Social', c.direccion as 'Direccion', c.cuit as 'Cuit', c.confianza as 'Confianza', u.nombre as 'Operario Favorito', i.descripcion as 'Condicion Fiscal', email as 'E-Mail' from cliente c, usuario u, condicion_iva i  where c.operario_favorito=u.id and c.condicion_iva=i.id and c.id="+this.DropDownList1.SelectedValue.ToString();
                e.ParameterValues.Add("consulta", consultar);
                Label1.Text = consultar;
            
        }





        protected void ObjectDataSource2_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dgvDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            puente puente = new puente();
         
            string id = this.dgvDatos.Rows[this.dgvDatos.SelectedIndex].Cells[3].Text;
            //this.Label1.Text = id;
            puente.elimina(id, "cliente");
            Response.Redirect("listar_clientes.aspx");        
        }



    }
}

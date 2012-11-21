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
    public partial class abmrestriccionlicencias_listado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            puente puente = new puente();

            string id = this.dgvDatos.Rows[this.dgvDatos.SelectedIndex].Cells[3].Text;
            //this.Label1.Text = id;
            puente.elimina(id, "restriccion_disponibilidad_usuario");
            Response.Redirect("abmrestriccionlicencias_listado.aspx");        


        }
    }
}

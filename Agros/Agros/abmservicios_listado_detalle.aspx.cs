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
    public partial class abmservicios_listado_detalle : System.Web.UI.Page
    {
        puente puente = new puente();
        string id;

        protected void Page_Load(object sender, EventArgs e)
        {

        }




        public bool mensaje(string parametro)
        {
            string i = "<script>window.alert('";
            string f = "');</script>";
            string mensaje_error = "Debe Marcar Un Item Antes De Continuar";
            bool res = true;

            if (parametro.Length < 1)
            {
                mensaje_error = i + mensaje_error + f;
                Response.Write(mensaje_error);
                res = false;
            }

            return res;

        }


        protected void dgvDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            id = this.dgvDatos.Rows[this.dgvDatos.SelectedIndex].Cells[1].Text;
            this.Label2.Text = id;
            
        }

        protected void x_Click(object sender, EventArgs e)
        {
            id = this.Label2.Text;

            if (mensaje(id)){

                puente.elimina(id, "detalle_servicio");
                Response.Redirect("abmservicios_listado_detalle.aspx");
            }

        }

        protected void ver_Click(object sender, EventArgs e)
        {
            //PostBackUrl="~/abmservicios_ver_productos_necesarios.aspx" 
            id = this.Label2.Text;

            if (mensaje(id)){
                Session["id_detalle_servicio"] =id;
                Response.Redirect("abmservicios_ver_productos_necesarios.aspx");
            }

        }

        protected void add_Click(object sender, EventArgs e)
        {
            id = this.Label2.Text;

            if (mensaje(id)){

                Session["id_detalle_servicio"] = id;
                Response.Redirect("abmservicios_agregar_producto_necesario.aspx");
            }

        }
    }
}

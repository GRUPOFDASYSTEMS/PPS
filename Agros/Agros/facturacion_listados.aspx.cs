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
    public partial class facturacion_listados : System.Web.UI.Page
    {
        puente p = new puente();
        nueva_pagina np = new nueva_pagina();


        protected void Page_Load(object sender, EventArgs e)
        {
            LabelInfo.Text = "";
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }




        protected void informar_Click(object sender, EventArgs e)
        {

            string id = Label2.Text;
            bool exito = false;



            string estadoIncorrecto = np.obtenerEstados("facturas", id, "Pagada", "facturacion");

            if (estadoIncorrecto == "OK")
                LabelInfo.Text = "Recuerde que no puede cambiar el estado de una factura ya pagada.";
            else
                exito = p.cambiar_estado(id, " estados where descripcion='Informada' and tema='facturacion'", "facturas");


            if (exito)
            {
                Response.Redirect("facturacion_listados.aspx");
            }



        }

        protected void dgvdatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = this.dgvDatos.Rows[this.dgvDatos.SelectedIndex].Cells[1].Text;
            Label2.Text = id;
        }

        protected void desinformar_Click(object sender, EventArgs e)
        {
            string id = Label2.Text;
            bool exito = false;

            string estadoIncorrecto = np.obtenerEstados("facturas", id, "Pagada", "facturacion");

            if (estadoIncorrecto == "OK")
                LabelInfo.Text = "Recuerde que no puede cambiar el estado de una factura ya pagada.";
            else
                exito = p.cambiar_estado(id, " estados where descripcion='Pendiente' and tema='facturacion'", "facturas");

            //Label2.Text = id; 
            if (exito)
            {
                Response.Redirect("facturacion_listados.aspx");
            }

        }

        protected void Detalles_Click(object sender, EventArgs e)
        {
            string id = Label2.Text;

            if (!id.Equals("")) {
                Session["id_factura"] = id;
                Response.Redirect("facturacion_detalle_facturas_clientes.aspx");
            }




        }



    }
}

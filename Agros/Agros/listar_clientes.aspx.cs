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
        linkeo linker = new linkeo();
        puente puente = new puente();
        nueva_pagina np = new nueva_pagina();
        string id, rm, resultado;


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

         
            id = this.dgvDatos.Rows[this.dgvDatos.SelectedIndex].Cells[1].Text;
            this.idc.Text = id;

     
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            id = this.idc.Text;
            if ((rm = np.mensaje_marca(id)).Length < 1)
            {
            puente.elimina(id, "cliente");
            Response.Redirect("listar_clientes.aspx");
            }
            else
                Response.Write(rm);
        }

        protected void of_Click(object sender, EventArgs e)
        {
            id = this.idc.Text;

            if ((rm = np.mensaje_marca(id)).Length < 1)
            {
                ArrayList campos_y_valores = new ArrayList();
                //recolecto datos
                campos_y_valores.Add("operario_favorito=");
                campos_y_valores.Add(this.operario.SelectedValue);

                resultado = linker.actualizacion_de_dataset("cliente", id, campos_y_valores); 

                string[] devolucion = new string[3];
                devolucion = linker.revisar_error(resultado, "UPD", "Datos Actualizados Correctamente", "Atencion Ocurrio Un Error Al Intentar Ejecutar La Transaccion", "listar_clientes.aspx", "listar_clientes.aspx");


                if (devolucion[0].Equals("0"))
                    Session["mensaje_error"] = devolucion[1];
                else
                    Session["mensaje_exito"] = devolucion[1];



                Response.Redirect(devolucion[2]);

            }
            else
                Response.Write(rm);



        }

        protected void vc_Click(object sender, EventArgs e)
        {
            id = this.idc.Text;
            if ((rm = np.mensaje_marca(id)).Length < 1)
            {
                ArrayList campos_y_valores = new ArrayList();
                //recolecto datos
                campos_y_valores.Add("confianza=");
                campos_y_valores.Add(this.confianza.Text);

                resultado = linker.actualizacion_de_dataset("cliente", id, campos_y_valores);

                string[] devolucion = new string[3];
                devolucion = linker.revisar_error(resultado, "UPD", "Datos Actualizados Correctamente", "Atencion Ocurrio Un Error Al Intentar Ejecutar La Transaccion", "listar_clientes.aspx", "listar_clientes.aspx");


                if (devolucion[0].Equals("0"))
                    Session["mensaje_error"] = devolucion[1];
                else
                    Session["mensaje_exito"] = devolucion[1];



                Response.Redirect(devolucion[2]);

            }
            else
                Response.Write(rm);
        }



    }
}

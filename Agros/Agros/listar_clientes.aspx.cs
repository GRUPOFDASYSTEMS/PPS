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
    public partial class listar_clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }



        protected void ObjectDataSource2_Filtering(object sender, ObjectDataSourceFilteringEventArgs e)
        {
            
            string consultar;

                e.ParameterValues.Clear();
                consultar = "select c.id_cliente as id, c.razon_social as 'Razon Social', c.direccion as 'Direccion', c.cuit as 'Cuit', c.confianza as 'Confianza', u.nombre as 'Operario Favorito', i.descripcion as 'Condicion Fiscal', email as 'E-Mail' from cliente c, usuario u, condicion_iva i  where c.operario_favorito=u.id_usuario and c.condicion_iva=i.id_condicion and c.id_estado="+this.DropDownList1.SelectedValue.ToString();
                e.ParameterValues.Add("consulta", consultar);
                Label1.Text = consultar;
            
        }



        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            //aca defino el filtro de cambio de estado



            //ObjectDataSource2_Filtering(sender,e);

            //link.Seleccion_en_dataset(consulta);
            
            //HttpContext consulta_act = consulta;
            //this.ObjectDataSource2.SelectParameters.UpdateValues(consulta_act);
            //this.ObjectDataSource2.SelectParameters.consulta = consulta;
            



        }





        //private void btnMostrar_Click(object sender, EventArgs e)
        //{
        //    linkeo ConexionMySQL = new linkeo();

        //    ConexionMySQL.Conectar();
        //    ConexionMySQL.Seleccionar("*", "estados", "id_estado");
        //    dgvDatos.DataSource = ConexionMySQL.Bin;
        //    ConexionMySQL.Desconectar();
        //}







//        public void cargardd()
//        {
//            /*
//             * 
//             * * 
//             * 
//             * 
//             * 
//             * 
//             * 
//            SqlCommand OrdenSqlSelect = new SqlCommand("SELECT * FROM Zonas", ConexionBd);
//            SqlDataAdapter da = new SqlDataAdapter(OrdenSqlSelect.CommandText, ConexionBd);
//            DataSet ds = new DataSet();
//            da.Fill(ds);
//            this.ddZona.DataSource = ds;
//            this.ddZona.DataSource = ds;
//            this.ddZona.DataValueField = "CodZona";
//            this.ddZona.DataTextField = "Zona";
//            this.ddZona.DataBind();
//             */


//            //this.DropDownList1.Items.Insert(0, new ListItem("Activos", "1"));
//            //this.DropDownList1.Items.Insert(0, new ListItem("Inactivos", "2"));
//            //this.DropDownList1.Items.Insert(0, new ListItem("Bloqueados", "3"));
            
            
            
//            string estado, desc;



//            linkeo enlace = new linkeo();

            
////            enlace.Seleccionar("id_estado, descripcion", "estados", "id_estado");
//            enlace.Seleccion_simple("select id_estado, descripcion from estados");

//            //while (enlace.BindingSource.read())
//            //{

//            //    estado = enlace.BindingSource["id_estado"].ToString();
//            //    desc = enlace.BindingSource["descripcion"].ToString();




//             //   this.DropDownList1.Items.Insert(0, new ListItem(desc, estado));
//            //}
            



//        }




    }
}

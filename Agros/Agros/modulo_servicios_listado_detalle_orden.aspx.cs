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
    public partial class modulo_servicios_listado_detalle_orden : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargardd();
        }

        public void cargardd()
        {
            /*
             * 
             * * 
             * 
             * 
             * 
             * 
             * 
            SqlCommand OrdenSqlSelect = new SqlCommand("SELECT * FROM Zonas", ConexionBd);
            SqlDataAdapter da = new SqlDataAdapter(OrdenSqlSelect.CommandText, ConexionBd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            this.ddZona.DataSource = ds;
            this.ddZona.DataSource = ds;
            this.ddZona.DataValueField = "CodZona";
            this.ddZona.DataTextField = "Zona";
            this.ddZona.DataBind();
             */

            this.DropDownList1.Items.Insert(0, new ListItem("Riego", "1"));
            this.DropDownList3.Items.Insert(0, new ListItem("Desratizacion", "2"));
            this.DropDownList5.Items.Insert(0, new ListItem("Control de plagas", "3"));


            this.DropDownList2.Items.Insert(0, new ListItem("Pendiente", "1"));
            this.DropDownList4.Items.Insert(0, new ListItem("Abortada", "2"));
            this.DropDownList6.Items.Insert(0, new ListItem("Completada", "3"));

        }


    }
}

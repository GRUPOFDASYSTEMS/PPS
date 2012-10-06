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
    public partial class modulo_servicios_cliente_listados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargardd();   
        }



        public void cargardd()
        {
            /*
             * 
                             <asp:ListItem Text="Pendientes__" Value="1" />
                <asp:ListItem Text="Aprobadas__" Value="2" />
                <asp:ListItem Text="Desaprobadas" Value="3" />
                <asp:ListItem Text="Informadas" Value="4" />
                <asp:ListItem Text="Desinformadas" Value="5" />
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

            this.DropDownList1.Items.Insert(0, new ListItem("Pendientes", "1"));
            this.DropDownList1.Items.Insert(0, new ListItem("Pre-Aprobadas", "2"));
            this.DropDownList1.Items.Insert(0, new ListItem("Aprobadas", "3"));
            this.DropDownList1.Items.Insert(0, new ListItem("Desaprobadas", "4"));
            this.DropDownList1.Items.Insert(0, new ListItem("Abortadas", "5"));
            this.DropDownList1.Items.Insert(0, new ListItem("Informadas", "6"));
            this.DropDownList1.Items.Insert(0, new ListItem("Desinformadas", "7"));

        }

    }
}

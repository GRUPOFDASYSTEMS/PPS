using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace Agros
{
    public class Conexion_BD
    {
            /** Conexion con la BD */
        public SqlConnection m_connection;
        /** Enlace con la DB */
        public SqlDataAdapter m_adapter;
        /** CommandBuilder para encapsular enlace a DB */
        public SqlCommandBuilder m_builder;
        /** credenciales de autentificacion */
        public string m_credentials;


        public void Conectar()
        {
            //InitializeComponent();
            
            // Inicializar variables para la conexion con BD
            m_connection = new SqlConnection();
            m_adapter = new SqlDataAdapter();
            m_builder = new SqlCommandBuilder(m_adapter);
        }

    }




}

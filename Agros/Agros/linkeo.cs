using System;
using System.Collections;
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
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;




using System.Data.SqlClient;




namespace Agros
{
    //public class linkeo
    //{
    //}

//    public class linkeo
//    {
//        static MySqlConnection Conex = new MySqlConnection();
//        static string CadenaDeConexion = "Server=localhost;" + "Database=agros;" + "UID=root;" + "Password=;";
//        static MySqlCommand Comando = new MySqlCommand();
//        static MySqlDataAdapter Adaptador = new MySqlDataAdapter();
//        static BindingSource Bind = new BindingSource();

//        public static void Conectar()
//        {


//            try
//            {
//                Conex.ConnectionString = CadenaDeConexion;
//                Conex.Open();
//                //Response.Write("Exito");
//            }
//            catch {
//                //Response.Write("Fallo");
//            }




//        }


//        public static void Desconectar()
//        {
//            Conex.Close();
//        }

//        public DataSet Seleccionar(string campos, string tabla, string orden)
//        {
            
//            //aca podria agregar para que se conecte automaticamente
//            //this.Conectar();

//            string Comando = "select " + campos + " from " + tabla + " order by " + orden + ";";
//            Adaptador = new MySqlDataAdapter(Comando, CadenaDeConexion);
//            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(Adaptador);
//            DataSet table = new DataSet();
//            Adaptador.Fill(table);
//            return table;
////            Bind.DataSource = table;
//        }





//        public DataSet Seleccion_simple(string consulta)
//        {

//            //aca podria agregar para que se conecte automaticamente
//            //this.Conectar();

//            string Comando = " " + consulta + "  ";
//            Adaptador = new MySqlDataAdapter(Comando, CadenaDeConexion);
//            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(Adaptador);
//            DataSet table = new DataSet();
//            Adaptador.Fill(table);
//            return table;
//            //            Bind.DataSource = table;
//        }



//        public DataSet Seleccion_estados()
//        {

//            //aca podria agregar para que se conecte automaticamente
//            //this.Conectar();

//            string Comando = " select id_estado, descripcion from estados  ";
//            Adaptador = new MySqlDataAdapter(Comando, CadenaDeConexion);
//            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(Adaptador);
//            DataSet table = new DataSet();
//            Adaptador.Fill(table);
//            return table;
//            //            Bind.DataSource = table;
//        }










//        public static BindingSource Bin
//        {
//            get
//            {
//                return Bind;
//            }
//        }
//    }


    public class linkeo //link_mssql
    {

      static SqlConnection conexion = new SqlConnection("Data Source=ALEX\\FDA;MultipleActiveResultSets=True;Initial Catalog=master;Integrated Security=True");
        //Data Source=ALEX\FDA;Initial Catalog=master;Integrated Security=True
        //Data Source=\\ALEX\\FDA;Database=master;Integrated Security=SSPI

      //public static void conectar_ms()
      //{
      //      // Connecting to an instance of SQL Server using SQL Server Authentication
      //    Server srv1 = new Server();   // connects to default instance
      //    //srv1.ConnectionContext.LoginSecure = false;   // set to true for Windows Authentication
      //    //srv1.ConnectionContext.Login = sqlServerLogin;
      //    //srv1.ConnectionContext.Password = password;
            
      //    Console.WriteLine(srv1.Information.Version);   // connection is established
            
      //}










      //select c.id_cliente as id, c.razon_social as 'Razon Social', c.direccion as 'Direccion', c.cuit as 'Cuit', c.confianza as 'Confianza', u.nombre as 'Operario Favorito', i.descripcion as 'Condicion Fiscal', email as 'E-Mail' from cliente c, usuario u, condicion_iva i  where c.operario_favorito=u.id_usuario and c.condicion_iva=i.id_condicion
        public DataSet Seleccion_en_dataset (string consulta)
        {

            //aca podria agregar para que se conecte automaticamente
            //this.Conectar();
            //SqlConnection conexion = new SqlConnection("Data Source=ALEX\\FDA;MultipleActiveResultSets=True;Initial Catalog=master;Integrated Security=True");
            DataSet table = new DataSet();
            SqlCommand Comando = new SqlCommand (consulta, conexion);
            conexion.Open();

            //using (SqlDataReader select = Comando.ExecuteReader())
            //{
                SqlDataAdapter Adaptador = new SqlDataAdapter(Comando);
                SqlCommandBuilder cm = new SqlCommandBuilder(Adaptador);


                //Adaptador = new MySqlDataAdapter(Comando, CadenaDeConexion);
                //MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(Adaptador);
                
                Adaptador.Fill(table);
            //}
            conexion.Close();
            return table;
            
        }



        public DataSet Seleccion_por_id_estado(string id)
        {

            //aca podria agregar para que se conecte automaticamente
            string consulta;
            //SqlConnection conexion = new SqlConnection("Data Source=ALEX\\FDA;MultipleActiveResultSets=True;Initial Catalog=master;Integrated Security=True");
            DataSet table = new DataSet();
            consulta = "select c.id_cliente as id, c.razon_social as 'Razon Social', c.direccion as 'Direccion', c.cuit as 'Cuit', c.confianza as 'Confianza', u.nombre as 'Operario Favorito', i.descripcion as 'Condicion Fiscal', email as 'E-Mail' from cliente c, usuario u, condicion_iva i  where c.operario_favorito=u.id_usuario and c.condicion_iva=i.id_condicion and c.id_estado=" + id;
            SqlCommand Comando = new SqlCommand(consulta, conexion);
            conexion.Open();

            //using (SqlDataReader select = Comando.ExecuteReader())
            //{
            SqlDataAdapter Adaptador = new SqlDataAdapter(Comando);
            SqlCommandBuilder cm = new SqlCommandBuilder(Adaptador);


            //Adaptador = new MySqlDataAdapter(Comando, CadenaDeConexion);
            //MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(Adaptador);

            Adaptador.Fill(table);
            //}
            conexion.Close();
            return table;

        }

        public static string PrintValues(IEnumerable myList)
        {
            string res="";
            foreach (Object obj in myList)
                //  Console.Write("   {0}", obj);
                //Console.WriteLine();
                res = res +  obj;
            
            
            return res;

        }


        public DataSet Seleccion_por_id_y_consulta(string consulta, string id)
        {

            //aca podria agregar para que se conecte automaticamente
            
            //SqlConnection conexion = new SqlConnection("Data Source=ALEX\\FDA;MultipleActiveResultSets=True;Initial Catalog=master;Integrated Security=True");
            DataSet table = new DataSet();
            consulta = consulta + id;
            SqlCommand Comando = new SqlCommand(consulta, conexion);
            conexion.Open();

            SqlDataAdapter Adaptador = new SqlDataAdapter(Comando);
            SqlCommandBuilder cm = new SqlCommandBuilder(Adaptador);

            Adaptador.Fill(table);

            conexion.Close();
            return table;

        }



        public string insercion_de_dataset(string tabla, ArrayList campos, ArrayList valores)
        {

            string insercion;
            DataSet table = new DataSet();
            SqlCommand Comando = conexion.CreateCommand();

            

            //Comando.CommandText = "INSERT  INTO Employees (FirstName, LastName) VALUES (@FirstName, @LastName)";
            insercion = "INSERT  INTO " + tabla + " (" + PrintValues(campos) + ") VALUES (" + PrintValues(valores) + ")";
            //Create Command object

            //SqlCommand nonqueryCommand = thisConnection.CreateCommand();


            

            try
            {

              
                conexion.Open();
                
                // Create INSERT statement with named parameters          
                
                Comando.CommandText = insercion;
                
                // Add Parameters to Command Parameters collection
                //nonqueryCommand.Parameters.Add("@FirstName", SqlDbType.VarChar, 10);
                //nonqueryCommand.Parameters.Add("@LastName", SqlDbType.VarChar, 20);
                //nonqueryCommand.Parameters["@FirstName"].Value = txtFirstName.Text;
                //nonqueryCommand.Parameters["@LastName"].Value = txtLastName.Text;

                Comando.ExecuteNonQuery();

            }



            catch (SqlException ex)
            {

                // mostrar error
                string error= insercion;
                error = error + ex.ToString();
                return  error;

                

            }



            finally
            {

                // Close Connection

                conexion.Close();



            }

            //return "proceso exitoso";
            return insercion;
        }

    //public DataSet Seleccion_estados_ms_puro()
    //{

    //    //SqlCommand Comando = new SqlCommand(" select * from estados  ");
    //    string Comando = " select id_estado, descripcion from estados  ";

    //    SqlDataAdapter Adaptador = new SqlDataAdapter(Comando, conexion);
    //    SqlCommandBuilder cm = new SqlCommandBuilder(Adaptador);


    //    DataSet table = new DataSet();
    //    Adaptador.Fill(table);

        
    //    return table;

    //}





        //public DataSet Seleccion_simple(string c)
        //{

        //    //aca podria agregar para que se conecte automaticamente
        //    //this.Conectar();


        //    //SqlCommand Comando = new SqlCommand(" select * from estados  ");
        //    string Comando = c;

        //    SqlDataAdapter Adaptador = new SqlDataAdapter(Comando, conexion);
        //    SqlCommandBuilder cm = new SqlCommandBuilder(Adaptador);


        //    DataSet table = new DataSet();
        //    Adaptador.Fill(table);


        //    return table;

        //}



    }

}

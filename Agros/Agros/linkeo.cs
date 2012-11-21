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


    public class linkeo //link_mssql
    {

      static SqlConnection conexion = new SqlConnection("Data Source=ALEX\\FDA;MultipleActiveResultSets=True;Initial Catalog=master;Integrated Security=True");


      public static string PrintValues(IEnumerable myList)
      {
          string res = "";
          foreach (Object obj in myList)
              res = res + obj;

          return res;
      }




      //select c.id_cliente as id, c.razon_social as 'Razon Social', c.direccion as 'Direccion', c.cuit as 'Cuit', c.confianza as 'Confianza', u.nombre as 'Operario Favorito', i.descripcion as 'Condicion Fiscal', email as 'E-Mail' from cliente c, usuario u, condicion_iva i  where c.operario_favorito=u.id_usuario and c.condicion_iva=i.id_condicion
        public DataSet Seleccion_en_dataset (string consulta)
        {

            //aca podria agregar para que se conecte automaticamente
            DataSet table = new DataSet();
            SqlCommand Comando = new SqlCommand (consulta, conexion);
            try
            {
                conexion.Open();
                SqlDataAdapter Adaptador = new SqlDataAdapter(Comando);
                SqlCommandBuilder cm = new SqlCommandBuilder(Adaptador);
                Adaptador.Fill(table);
            }

            catch (SqlException ex)
            {

                // mostrar error
                string error = ex.ToString();
                table = null;                

            }

            finally
            {
                // Close Connection
                conexion.Close();
            }


            return table;
            
        }





        public DataSet Seleccion_por_id_y_consulta(string consulta, string id)
        {

            DataSet table = new DataSet();
            consulta = consulta + id;
            SqlCommand Comando = new SqlCommand(consulta, conexion);

            try
            {
                conexion.Open();

                SqlDataAdapter Adaptador = new SqlDataAdapter(Comando);
                SqlCommandBuilder cm = new SqlCommandBuilder(Adaptador);

                Adaptador.Fill(table);
            }

            catch (SqlException ex)
            {

                // mostrar error
                string error = ex.ToString();
                table = null;

            }

            finally
            {
                // Close Connection
                conexion.Close();
            }

            return table;

        }


        public DataSet Seleccion_segun_id_para_consultar(string consulta1, string consulta2, string consulta3, string id)
        {

            DataSet table = new DataSet();
            string consulta= "";
            
            switch (id)
            {
                case "3":
                    consulta = consulta1;
                    break;

                case "4":
                    consulta = consulta2;
                    break;

                case "5":
                    consulta = consulta3;
                    break;

            }
            
            
           
            SqlCommand Comando = new SqlCommand(consulta, conexion);

            try
            {
                conexion.Open();

                SqlDataAdapter Adaptador = new SqlDataAdapter(Comando);
                SqlCommandBuilder cm = new SqlCommandBuilder(Adaptador);
                
                Adaptador.Fill(table);
            }

            catch (SqlException ex)
            {

                // mostrar error
                string error = ex.ToString();
                table = null;

            }

            finally
            {
                // Close Connection
                conexion.Close();
            }

            return table;

        }





        public int obtener_id(string tabla)
        {

            int id = 0;
            string maxid = "";
            string consulta = "";

            
            consulta = "select max(id)  from " + tabla ;


            SqlCommand Comando = new SqlCommand(consulta, conexion);
            
            

            try
            {
                conexion.Open();
                Comando.CommandText = consulta;
                Comando.CommandType = CommandType.Text;
                SqlDataReader reader = Comando.ExecuteReader();

                if (reader.Read())
                {
                    maxid = reader[0].ToString();
                }
                reader.Close();


                id = Int32.Parse(maxid);
                //id = (int)Comando.ExecuteNonQuery();
            }

            catch (SqlException ex)
            {

                // mostrar error
                string error = ex.ToString();
                

            }

            finally
            {
                // Close Connection
                conexion.Close();
            }


            
            return id;

        }








        public string insercion_de_dataset(string tabla, ArrayList campos, ArrayList valores)
        {

            string insercion;
            DataSet table = new DataSet();
            SqlCommand Comando = conexion.CreateCommand();
            
            insercion = "INSERT  INTO " + tabla + " (" + PrintValues(campos) + ") VALUES (" + PrintValues(valores) + ")";
            
            try
            {
                conexion.Open();
                Comando.CommandText = insercion;
                Comando.ExecuteNonQuery();
            }



            catch (SqlException ex)
            {

                // mostrar error
                string error= insercion;
                error = error + ex.ToString();
                insercion=error;

            }

            finally
            {
                // Close Connection
                conexion.Close();
            }

            //return "proceso exitoso";
            return insercion;
        }


        public string actualizacion_de_dataset(string tabla, string id, ArrayList campos_y_valores)
        {

            string actualizacion;
            DataSet table = new DataSet();
            SqlCommand Comando = conexion.CreateCommand();

            actualizacion = "UPDATE " + tabla + " SET " + PrintValues(campos_y_valores) + " WHERE id=" + id;

            try
            {
                conexion.Open();
                Comando.CommandText = actualizacion;
                Comando.ExecuteNonQuery();
            }



            catch (SqlException ex)
            {

                // mostrar error
                string error = actualizacion;
                error = error + ex.ToString();
                return error;

            }

            finally
            {
                // Close Connection
                conexion.Close();
            }

            //return "proceso exitoso";
            return actualizacion;
        }


        public string actualizacion_personalizada(string tabla, string id_con_condicion, ArrayList campos_y_valores)
        {

            string actualizacion;
            DataSet table = new DataSet();
            SqlCommand Comando = conexion.CreateCommand();

            actualizacion = "UPDATE " + tabla + " SET " + PrintValues(campos_y_valores) + " WHERE " + id_con_condicion;

            try
            {
                conexion.Open();
                Comando.CommandText = actualizacion;
                Comando.ExecuteNonQuery();
            }



            catch (SqlException ex)
            {

                // mostrar error
                string error = actualizacion;
                error = error + ex.ToString();
                return error;

            }

            finally
            {
                // Close Connection
                conexion.Close();
            }

            //return "proceso exitoso";
            return actualizacion;
        }










        
        public string borrado_por_tabla_e_id(string tabla, string id)
        {

            string borrado;
            
            SqlCommand Comando = conexion.CreateCommand();
            // tomo para todos las tablas el atributo id siempre 
            borrado = "DELETE FROM " + tabla + " WHERE  id=" + id + " ";

            try
            {
                conexion.Open();
                Comando.CommandText = borrado;
                Comando.ExecuteNonQuery();
            }



            catch (SqlException ex)
            {

                // mostrar error
                string error = borrado;
                error = error + ex.ToString();
                borrado=error;

            }

            finally
            {
                // Close Connection
                conexion.Close();
            }

            //return "proceso exitoso";
            return borrado;
        }




    }

}

using CRUD_ASP_CORE.Models;
using System.Data.SqlClient;
using System.Data;

namespace CRUD_ASP_CORE.Datos
{
    public class ContactoDatos
    {
        public List<ContactoModel> Listar()
        {
            var oLista = new List<ContactoModel>();

            var cn = new Connection();

            using (SqlConnection connection = new SqlConnection(cn.getCadenaSQL()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar",connection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oLista.Add(new ContactoModel()
                    {
                        IdContacto = Convert.ToInt32(reader["IdContacto"]),
                        Nombre = reader["Nombre"].ToString(),
                        Telefono = reader["Telefono"].ToString(),
                        Correo = reader["Correo"].ToString()
                    }); 
                }


            }
            return oLista;
        }

        public ContactoModel Obtener(int IdContacto)
        {
            var oContacto = new ContactoModel();

            var cn = new Connection();

            using (SqlConnection connection = new SqlConnection(cn.getCadenaSQL()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", connection);
                cmd.Parameters.AddWithValue("IdContacto",IdContacto);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oContacto.IdContacto = Convert.ToInt32(reader["IdContacto"]);
                    oContacto.Nombre = reader["Nombre"].ToString();
                    oContacto.Telefono = reader["Telefono"].ToString();
                    oContacto.Correo = reader["Correo"].ToString();
                }
            }
            return oContacto;
        }

        public bool Guardar(ContactoModel oContacto)
        {
            bool rta;
            try
            {
                var cn = new Connection();
            
                using (SqlConnection connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", connection);
                    cmd.Parameters.AddWithValue("@Nombre",oContacto.Nombre);
                    cmd.Parameters.AddWithValue("@Telefono", oContacto.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", oContacto.Correo);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rta = false;
            }

            return rta;
        }

        public bool Editar(ContactoModel oContacto)
        {
            bool rta;
            try
            {
                var cn = new Connection();

                using (SqlConnection connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", connection);
                    cmd.Parameters.AddWithValue("@IdContacto", oContacto.IdContacto);
                    cmd.Parameters.AddWithValue("@Nombre", oContacto.Nombre);
                    cmd.Parameters.AddWithValue("@Telefono", oContacto.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", oContacto.Correo);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rta = false;
            }

            return rta;
        }

        public bool Eliminar(int IDContacto)
        {
            bool rta;
            try
            {
                var cn = new Connection();

                using (SqlConnection connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", connection);
                    cmd.Parameters.AddWithValue("@IdContacto", IDContacto);
                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rta = false;
            }

            return rta;
        }
    }
}

using ABMcliente.Models;
using System.Data.SqlClient;
using System.Data;


namespace ABMcliente.Datos
{
    public class Cliente
    {

        public List<ClienteModel> Listar()
        {

            var oLista = new List<ClienteModel>();
            var cn = new conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {

                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ClienteModel()
                        {
                            Id_cliente = Convert.ToInt32(dr["Id_cliente"]),
                            Nombre = dr["Nombre"].ToString(),
                            Apellido = dr["Apellido"].ToString(),
                            Direccion = dr["Direccion"].ToString(),
                            Email = dr["Email"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Fecha = Convert.ToDateTime(dr["Fecha"]),
                        });
                    }
                }
            }
            return oLista;
        }


        public ClienteModel Obtener(int Id_cliente)
        {

            var oCliente = new ClienteModel();
            var cn = new conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {

                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("Id_cliente", Id_cliente);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        oCliente.Id_cliente = Convert.ToInt32(dr["Idcliente"]);
                        oCliente.Nombre = dr["Nombre"].ToString();
                        oCliente.Apellido = dr["Apellido"].ToString();
                        oCliente.Direccion = dr["Direccion"].ToString();
                        oCliente.Email = dr["Email"].ToString();
                        oCliente.Telefono = dr["Telefono"].ToString();
                        oCliente.Fecha = Convert.ToDateTime(dr["Fecha"]);

                    }
                }

                return oCliente;
            }

           
        }

        public bool Guardar(ClienteModel oCliente)
        {
            bool rpta;

            try
            {
                var cn = new conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);

                    cmd.Parameters.AddWithValue("Id_cliente", oCliente.Id_cliente);
                    cmd.Parameters.AddWithValue("Nombre", oCliente.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", oCliente.Apellido);
                    cmd.Parameters.AddWithValue("Direccion", oCliente.Direccion);
                    cmd.Parameters.AddWithValue("Email", oCliente.Email);
                    cmd.Parameters.AddWithValue("Telefono", oCliente.Telefono);
                    cmd.Parameters.AddWithValue("Fecha", oCliente.Fecha);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }

            catch (Exception e)
            {
                string error = e.Message;
                    
                rpta = false;

            }
            return rpta;
        }
        public bool Editar(ClienteModel oCliente)
        {
            bool rpta;

            try
            {
                var cn = new conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);

                    cmd.Parameters.AddWithValue("Id_cliente", oCliente.Id_cliente);
                    cmd.Parameters.AddWithValue("Nombre", oCliente.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", oCliente.Apellido);
                    cmd.Parameters.AddWithValue("Direccion", oCliente.Direccion);
                    cmd.Parameters.AddWithValue("Email", oCliente.Email);
                    cmd.Parameters.AddWithValue("Telefono", oCliente.Telefono);
                    cmd.Parameters.AddWithValue("Fecha", oCliente.Fecha);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }

            catch (Exception e)
            {
                string error = e.Message;

                rpta = false;

            }
            return rpta;
        }

        public bool Eliminar(int Id_cliente)
        {
            bool rpta;

            try
            {
                var cn = new conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);

                    cmd.Parameters.AddWithValue("Id_cliente", Id_cliente);
                    
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }

            catch (Exception e)
            {
                string error = e.Message;

                rpta = false;

            }
            return rpta;
        }

    }
}
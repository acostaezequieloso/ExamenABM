using System.Data.SqlClient;
namespace ABMcliente.Datos
{
    public class conexion
    {
        private string cadenaSQL = String.Empty;

        public conexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }

        public string getCadenaSQL()
        {
            return cadenaSQL;
        }
    } 
}

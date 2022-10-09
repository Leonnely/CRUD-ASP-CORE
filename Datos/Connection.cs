using System.Data.SqlClient;

namespace CRUD_ASP_CORE.Datos
{
    public class Connection
    {
        public Connection()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _cadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }
        private string _cadenaSQL = string.Empty;

        public string getCadenaSQL() => _cadenaSQL;
        
    }
}

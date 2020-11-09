using System.Data;
using System.Data.SqlClient;

namespace Aliquota.Infraestructure.Test.DBConfiguration
{
    public class DataOptionFactory
    {
        public string DefaultConnection { get; set; }
        public IDbConnection DatabaseConnection => new SqlConnection(DefaultConnection);
    }
}

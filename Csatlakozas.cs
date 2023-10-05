using MySql.Data.MySqlClient;

namespace Tantargyak
{
    public class Csatlakozas
    {
        public MySqlConnection connection;
        private string Host;
        private string DbName;
        private string UserName;
        private string Password;
        private string ConnectionString;

        public Csatlakozas()
        {
            Host = "localhost";
            DbName = "tantargyak";
            UserName = "root";
            Password = "";

            ConnectionString = $"Host={Host};Database={DbName};User={UserName};Password={Password}";

            connection = new MySqlConnection(ConnectionString);
        }
    }
}
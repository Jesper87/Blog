using MySql.Data.MySqlClient;

namespace Blog.Core.Database
{
  public class MySqlDatabaseConnection : IDatabaseConnection
  {
    public string ConnectionString { get; } = "server=192.168.1.11;database=Test;uid=root;pwd=jesper;";

    private MySqlConnection _mySqlConnection;
    public MySqlConnection MySqlConnection
    {
      get { return _mySqlConnection ?? (_mySqlConnection = new MySqlConnection(ConnectionString)); }
    }
  }
}

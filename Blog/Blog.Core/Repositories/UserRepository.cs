using System;
using System.Collections.Generic;
using Blog.Core.Database;
using Blog.Core.Model;
using MySql.Data.MySqlClient;

namespace Blog.Core.Repositories
{
  public class UserRepository
  {
    private MySqlDatabaseConnection _mySqlDatabaseConnection;
    protected MySqlDatabaseConnection MySqlDatabaseConnection
    {
      get { return _mySqlDatabaseConnection ?? (_mySqlDatabaseConnection = new MySqlDatabaseConnection()); }
    }

    public List<User> GetAllUsers()
    {
      const string query = "SELECT * FROM Users";
      var users = new List<User>();

      try
      {
        MySqlDatabaseConnection.MySqlConnection.Open();
        using (var command = new MySqlCommand(query, MySqlDatabaseConnection.MySqlConnection))
        {
          using (var reader = command.ExecuteReader())
          {
            while (reader.Read())
            {
              var user = new User();
              user.FirstName = reader["FirstName"].ToString();
              user.LastName = reader["LastName"].ToString();
              user.UserId = (int) reader["UserId"];
              users.Add(user);
            }
          }
        }
      }
      catch (Exception)
      {
        return null;
      }
      finally
      {
        MySqlDatabaseConnection.MySqlConnection.Close();
      }

      return users;
    }

    public User GetUser(int userId)
    {
      const string query = "SELECT * FROM Users WHERE UserId=@userId";

      try
      {
        MySqlDatabaseConnection.MySqlConnection.Open();
        using (var command = new MySqlCommand(query, MySqlDatabaseConnection.MySqlConnection))
        {
          command.Parameters.AddWithValue("@userId", userId);
          using (var reader = command.ExecuteReader())
          {
            var user = new User();
            user.FirstName = reader["FirstName"].ToString();
            user.LastName = reader["LastName"].ToString();
            user.UserId = (int) reader["UserId"];
            return user;
          }
        }
      }
      catch (Exception)
      {
        return null;
      }
      finally
      {
        MySqlDatabaseConnection.MySqlConnection.Close();
      }
    }
  }
}

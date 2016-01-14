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
    
    public UserRepository()
    {
      IntitializeDb();
    }

    private void IntitializeDb()
    {
      _mySqlDatabaseConnection = new MySqlDatabaseConnection();
      _mySqlDatabaseConnection.MySqlConnection.Open();
    }

    public List<User> GetAllUsers()
    {
      const string query = "SELECT * FROM Users";
      var users = new List<User>();

      try
      {
        using (var command = new MySqlCommand(query, _mySqlDatabaseConnection.MySqlConnection))
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
      
      return users;
    }

    public User GetUser(int userId)
    {
      const string query = "SELECT * FROM Users WHERE UserId=@userId";

      try
      {
        using (var command = new MySqlCommand(query, _mySqlDatabaseConnection.MySqlConnection))
        {
          command.Parameters.AddWithValue("@userId", userId);
          using (var reader = command.ExecuteReader())
          {
            reader.Read();
            var user = new User
            {
              FirstName = reader["FirstName"].ToString(),
              LastName = reader["LastName"].ToString(),
              UserId = (int) reader["UserId"]
            };

            return user;
          }
        }
      }
      catch (Exception)
      {
        return null;
      }
    }

    public void Dispose()
    {
      Dispose(true);
    }

    public void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (_mySqlDatabaseConnection.MySqlConnection.State == System.Data.ConnectionState.Open)
        {
          _mySqlDatabaseConnection.MySqlConnection.Close();
          _mySqlDatabaseConnection.MySqlConnection.Dispose();
        }
      }
    }
  }
}

using System;
using Blog.Core;
using Blog.Core.Repositories;

namespace Blog.ConsoleApp
{
  class Program
  {
    static void Main(string[] args)
    {
      var userRepo = new UserRepository();
      //var users = userRepo.GetAllUsers();
      var user = userRepo.GetUser(1);
      if (user == null)
      {
        Console.WriteLine("Users = null");
        Console.ReadLine();
        return;
      }

      //foreach (var user in users)
      //{
        Console.WriteLine("----------------------");
        Console.WriteLine(user.FirstName);
        Console.WriteLine(user.LastName);
        Console.WriteLine(user.UserId);
        Console.WriteLine("----------------------");
      //}
      Console.WriteLine("END");
      Console.ReadLine();
    }
  }
}

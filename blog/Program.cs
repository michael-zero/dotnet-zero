using System.Data;
using Blog.Models;
using Blog.Repositories;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace ZeroDataAcesss {
  class Program {
    private const string CONNECTION_STRING = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=blog;Integrated Security=SSPI;";

    static void Main(string[] args){

       var connection = new SqlConnection(CONNECTION_STRING);
       connection.Open();

        // ReadUser();
        // CreateUser();
        // UpdateUser();
        // DeleteUser();
        // ReadUsers(connection);
        ReadUsersWithRoles(connection);
        // ReadRoles(connection);
        // ReadTags(connection);
        
        connection.Close();
   
    }

    public static void ReadUser(SqlConnection connection){
      var repository = new Repository<User>(connection);
      var user = repository.Get(1);
      Console.WriteLine(user.Name);
    }

    public static void ReadUsersWithRoles(SqlConnection connection){
     var repository = new UserRepository(connection);
     var users = repository.ReadWithRole();

     foreach(var user in users){
      Console.WriteLine(user.Name);
       foreach(var role in user.Roles){
         Console.WriteLine($" - {role.Name}");
       }
     }
    }
    public static void ReadUsers(SqlConnection connection){
     var repository = new Repository<User>(connection);
     var users = repository.Get();

     foreach(var user in users){
      Console.WriteLine(user.Name);
       foreach(var role in user.Roles){
         Console.WriteLine($" - {role.Name}");
       }
     }
    }

    public static void ReadRoles(SqlConnection connection){
     var repository = new Repository<Role>(connection);
     var items = repository.Get();

     foreach(var item in items){
      Console.WriteLine(item.Name);
     }
    }

    public static void ReadTags(SqlConnection connection){
     var repository = new Repository<Tag>(connection);
     var items = repository.Get();

     foreach(var item in items){
      Console.WriteLine(item.Name);
     }
    }

    private static void CreateUser()
    {         
        var user = new User
        {
            Bio = "ze ninguem",
            Email = "ze@zero.com",
            Image = "https:...",
            Name = "ze ngm",
            Slug = "ze-zero",
            PasswordHash = Guid.NewGuid().ToString()
        };

        using(var conn = new SqlConnection(CONNECTION_STRING)){
        conn.Insert<User>(user);
        Console.WriteLine("Cadastro realizado com sucesso!");
        }

    }

    private static void UpdateUser()
      {         
          var user = new User
          {
              Id=2,
              Bio = "9x melhor amigo",
              Email = "pablo@zero.com",
              Image = "https:...",
              Name = "Pablo Sousa 7",
              Slug = "pablo-zero",
              PasswordHash = Guid.NewGuid().ToString()
          };

          using(var conn = new SqlConnection(CONNECTION_STRING)){
          conn.Update<User>(user);
          Console.WriteLine("Cadastro atualizado com sucesso!");
          }

      }

    private static void DeleteUser()
    {         
        using(var conn = new SqlConnection(CONNECTION_STRING)){
        var user = conn.Get<User>(3);
        conn.Delete<User>(user);
        Console.WriteLine("Exclusão realizada com sucesso!");
        }

    }


      
        // private static void CreateUser(Repository<User> repository)
        // {
        //     var user = new User
        //     {
        //         Bio = "8x Microsoft MVP",
        //         Email = "andre@balta.io",
        //         Image = "https://balta.io/andrebaltieri.jpg",
        //         Name = "André Baltieri",
        //         Slug = "andre-baltieri",
        //         PasswordHash = Guid.NewGuid().ToString()
        //     };

        //     repository.Create(user);
        // }

        // private static void ReadUsers(Repository<User> repository)
        // {
        //     var users = repository.Read();
        //     foreach (var item in users)
        //         Console.WriteLine(item.Email);
        // }

        // private static void ReadUser(Repository<User> repository)
        // {
        //     var user = repository.Read(2);
        //     Console.WriteLine(user?.Email);
        // }

        // private static void UpdateUser(Repository<User> repository)
        // {
        //     var user = repository.Read(2);
        //     user.Email = "hello@balta.io";
        //     repository.Update(user);

        //     Console.WriteLine(user?.Email);
        // }

        // private static void DeleteUser(Repository<User> repository)
        // {
        //     var user = repository.Read(2);
        //     repository.Delete(user);
        // }

        // private static void ReadWithRoles(SqlConnection connection)
        // {
        //     var repository = new UserRepository(connection);
        //     var users = repository.ReadWithRole();

        //     foreach (var user in users)
        //     {
        //         Console.WriteLine(user.Email);
        //         foreach (var role in user.Roles) Console.WriteLine($" - {role.Slug}");
        //     }
        // }

   }}
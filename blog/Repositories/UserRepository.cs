using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories {
  public class UserRepository {
    
    private readonly SqlConnection _connection;

    public UserRepository(SqlConnection connection)
    { 
       _connection = connection;
    }

    public User User(int id){
      return _connection.Get<User>(id);
    }

    public IEnumerable<User> Get(){
        return  _connection.GetAll<User>();
    }
    
    public void Create(User user){
      _connection.Insert<User>(user);
    }


  }
}
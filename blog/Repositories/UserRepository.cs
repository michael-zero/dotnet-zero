using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories {
  public class UserRepository {
    
    private SqlConnection _connection = new SqlConnection("");

    public User User(int id, string connectionString){
      return _connection.Get<User>(id);
    }

    public IEnumerable<User> Get(){
        return  _connection.GetAll<User>();
    }
    
    public void Create(User user, string connectionString){
      _connection.Insert<User>(user);
    }


  }
}
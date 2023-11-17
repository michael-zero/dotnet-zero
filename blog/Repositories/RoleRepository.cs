using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories{
  public class RoleRepository{
    private readonly SqlConnection _connection;

    public RoleRepository(SqlConnection connection)
    { 
       _connection = connection;
    }

    public Role Role(int id){
      return _connection.Get<Role>(id);
    }

    public IEnumerable<Role> Get(){
        return  _connection.GetAll<Role>();
    }
    
    public void Create(Role role){
      _connection.Insert<Role>(role);
    }
  }
}
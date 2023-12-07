using Blog.Models;
using Blog.Repositories;
using Dapper;
using Microsoft.Data.SqlClient;

public class UserRepository : Repository <User> {
    private readonly SqlConnection _connection;

    public UserRepository(SqlConnection connection): base(connection)
    {
        _connection = connection;
    }

    
      public List<User> ReadWithRole()
      {
          var query = @"
              SELECT
                  [User].*,
                  [Role].*
              FROM
                  [User]
                  LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                  LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]";

          var users = new List<User>();
          var items = _connection.Query<User, Role, User>(
              query,
              (user, role) =>
              {
                  var usr = users.FirstOrDefault(x => x.Id == user.Id);
                  if (usr == null)
                  {
                      usr = user;
                      if(role != null){
                          usr.Roles.Add(role);
                      }
                      users.Add(usr);
                  }
                  else {
                     usr.Roles.Add(role);
                  }
                     

                  return user;
              }, splitOn: "Id");
          return users;
      }
}
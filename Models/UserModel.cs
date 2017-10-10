using Dapper;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using TodoApi.Models;

public class UserModel
{
    private string connectionString;
    public UserModel()
    {
        connectionString = @"Server=localhost;Database=todoApi;User Id=SA;Password=rootr00T";
    }
 
    public IDbConnection Connection
    {
        get  {
            return new SqlConnection(connectionString);
        }
    }
 
    public void Add(UserItem user)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string sQuery = "INSERT INTO [User] (Firstname, Lastname, Email, Password)"
                            + " VALUES(@Firstname, @Lastname, @Email, @Password)";
            dbConnection.Open();
            dbConnection.Execute(sQuery, user);
        }
    }
 
    public IEnumerable<UserItem> GetAll()
    {
        using (IDbConnection dbConnection = Connection)
        {
            dbConnection.Open();
            return dbConnection.Query<UserItem>("SELECT * FROM [User]");
        }
    }
 
    public UserItem GetByID(int id)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string sQuery = "SELECT * FROM [User]"
                           + " WHERE Id = @Id";
            dbConnection.Open();
            return dbConnection.Query<UserItem>(sQuery, new { Id = id }).FirstOrDefault();
        }
    }
 
    public void Delete(int id)
    {
        using (IDbConnection dbConnection = Connection)
        {
             string sQuery = "DELETE FROM [User]"
                          + " WHERE Id = @Id";
            dbConnection.Open();
            dbConnection.Execute(sQuery, new { Id = id });
        }
    }
 
    public void Update(UserItem user)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string sQuery = "UPDATE [User] SET Firstname = @Firstname,"
                           + " Lastname = @Lastname, Email= @Email, Password = @Password"
                           + " WHERE Id = @Id";
            dbConnection.Open();
            dbConnection.Query(sQuery, user);
        }
    }

    public UserItem GetByUsernamePassword(UserItem user)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string sQuery = "SELECT * FROM [User]"
                           + " WHERE Email = @Email AND Password = @Password";
            dbConnection.Open();
            return dbConnection.Query<UserItem>(sQuery, user).FirstOrDefault();
        }
    }
}
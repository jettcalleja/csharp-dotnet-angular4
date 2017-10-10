using Dapper;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using TodoApi.Models;

public class TopicModel
{
    private string connectionString;
    public TopicModel()
    {
        connectionString = @"Server=localhost;Database=todoApi;User Id=SA;Password=rootr00T";
    }
 
    public IDbConnection Connection
    {
        get  {
            return new SqlConnection(connectionString);
        }
    }
 
    public void Add(TopicItem topic)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string sQuery = "INSERT INTO [Topic] (Title, Content)"
                            + " VALUES(@Title, @Content)";
            dbConnection.Open();
            dbConnection.Execute(sQuery, topic);
        }
    }
 
    public IEnumerable<TopicItem> GetAll()
    {
        using (IDbConnection dbConnection = Connection)
        {
            dbConnection.Open();
            return dbConnection.Query<TopicItem>("SELECT * FROM [Topic]");
        }
    }
 
    public TopicItem GetByID(int id)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string sQuery = "SELECT * FROM [Topic]"
                           + " WHERE Id = @Id";
            dbConnection.Open();
            return dbConnection.Query<TopicItem>(sQuery, new { Id = id }).FirstOrDefault();
        }
    }
 
    public void Delete(int id)
    {
        using (IDbConnection dbConnection = Connection)
        {
             string sQuery = "DELETE FROM [Topic]"
                          + " WHERE Id = @Id";
            dbConnection.Open();
            dbConnection.Execute(sQuery, new { Id = id });
        }
    }
 
    public void Update(TopicItem topic)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string sQuery = "UPDATE [Topic] SET Title = @Title,"
                           + " Content = @Content"
                           + " WHERE Id = @Id";
            dbConnection.Open();
            dbConnection.Query(sQuery, topic);
        }
    }
}
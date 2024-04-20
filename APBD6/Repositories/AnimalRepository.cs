using System.Data.SqlClient;
using APBD6.Models;

namespace APBD6.Repositories;

public class AnimalRepository : IAnimalRepository
{
    private IConfiguration _configuration;

    public AnimalRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IEnumerable<Animal> GetAnimals(string orderBy = "Name")
    {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        connection.Open();

        using var cmd = new SqlCommand($"SELECT * FROM Animal ORDER BY {orderBy}", connection);
        // cmd.Connection = connection;
        // cmd.CommandText = "SELECT * FROM Animal ORDER BY @orderBy";
        // cmd.Parameters.AddWithValue("@orderBy", orderBy);

        var dr = cmd.ExecuteReader();
        var animals = new List<Animal>();
        while (dr.Read())
        {
            var animal = new Animal
            {
                IdAnimal = (int)dr["IdAnimal"],
                Name = dr["Name"].ToString(),
                Description = dr["Description"].ToString(),
                Category = dr["Category"].ToString(),
                Area = dr["Area"].ToString()
            };
            animals.Add(animal);
        }

        return animals;
    }

    public int CreateAnimal(Animal animal)
    {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        connection.Open();
        using var cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "INSERT INTO Animal (Name, Description, Category, Area) VALUES (@Name, @Description, @Category, @Area)";
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Description", animal.Description);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Area", animal.Area);

        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }

    public Animal GetAnimal(int idAnimal)
    {
        throw new NotImplementedException();
    }

    public int UpdateAnimal(int IdAnimal, Animal animal)
    {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        connection.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText =
            "UPDATE Animal SET Name=@Name, Description=@Description, Category=@Category, Area=@Area WHERE IdAnimal=@IdAnimal";
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Description", animal.Description);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Area", animal.Area);
        cmd.Parameters.AddWithValue("@IdAnimal", IdAnimal);

        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;

    }

    public int DeleteAnimal(int idAnimal)
    {
        // using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        // connection.Open();
        //
        // using var cmd = new SqlCommand();
        // cmd.Connection = connection;
        // cmd.CommandText = "DELETE FROM Aimal WHERE IdAnimal=@IdAnimal";
        // cmd.Parameters.AddWithValue("@IdAnimal", idAnimal);
        //
        // var affectedCount = cmd.ExecuteNonQuery();
        // return affectedCount;
        using (var sqlConnection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]))
        {
            var sqlCommand = new SqlCommand(
                "DELETE FROM Animal WHERE IdAnimal = @1",
                sqlConnection
            );
            sqlCommand.Parameters.AddWithValue("@1", idAnimal);
            sqlCommand.Connection.Open();
            
            var affectedRows = sqlCommand.ExecuteNonQuery();
            return affectedRows;

        }
    }
}
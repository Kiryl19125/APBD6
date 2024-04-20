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
        throw new NotImplementedException();
    }

    public Animal GetAnimal(int idAnimal)
    {
        throw new NotImplementedException();
    }

    public int UpdateAnimal(Animal animal)
    {
        throw new NotImplementedException();
    }

    public int DeleteAnimal(int idAnimal)
    {
        throw new NotImplementedException();
    }
}
using APBD6.Models;

namespace APBD6.Repositories;

public interface IAnimalRepository
{
    IEnumerable<Animal> GetAnimals(string orderBy);
    int CreateAnimal(Animal animal);
    Animal GetAnimal(int idAnimal);
    int UpdateAnimal(Animal animal);
    int DeleteAnimal(int idAnimal);
}
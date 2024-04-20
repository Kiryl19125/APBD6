using APBD6.Models;
using APBD6.Repositories;

namespace APBD6.Services;

public class AnimalService : IAnimalService
{

    private readonly IAnimalRepository _animalRepository;

    public AnimalService(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }
    
    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        return _animalRepository.GetAnimals(orderBy);
    }

    public int CreateAnimal(Animal animal)
    {
        return _animalRepository.CreateAnimal(animal);
    }

    public Animal? GetAnimal(int idAnimal)
    {
        throw new NotImplementedException();
    }

    public int UpdateAnimal(int IdAnimal, Animal animal)
    {
        return _animalRepository.UpdateAnimal(IdAnimal, animal);
    }

    public int DeleteAnimal(int idAnimal)
    {
        return _animalRepository.DeleteAnimal(idAnimal);
    }
}
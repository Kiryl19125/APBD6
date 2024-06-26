using APBD6.Models;
using APBD6.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD6.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalController : ControllerBase
{
    private IAnimalService _animalService;

    public AnimalController(IAnimalService animalService)
    {
        _animalService = animalService;
    }

    [HttpGet]
    public IActionResult GetAnimals([FromQuery] string orderBy = "Name")
    {
        var animals = _animalService.GetAnimals(orderBy);
        return Ok(animals);
    }

    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        var affectedCount = _animalService.CreateAnimal(animal);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{IdAnimal:int}")]
    public IActionResult UpdateAnimal(int IdAnimal, Animal animal)
    {
        var affectedCount = _animalService.UpdateAnimal(IdAnimal, animal);
        return NoContent();
    }

    [HttpDelete("{IdAnimal:int}")]
    public IActionResult DeleteAnimal(int IdAnimal)
    {
        var affectedCount = _animalService.DeleteAnimal(IdAnimal);
        return NoContent();
    }
}
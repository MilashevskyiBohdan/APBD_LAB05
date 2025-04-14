
using Microsoft.AspNetCore.Mvc;
using APBD_LAB_05.Data;
using APBD_LAB_05.models;

namespace APBD_LAB_05.Controllers;

[ApiController]
[Route("api/animals")]
public class AnimalsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllAnimals() => Ok(StaticDb.Animals);

    [HttpGet("{id}")]
    public IActionResult GetAnimal(int id)
    {
        var animal = StaticDb.Animals.FirstOrDefault(a => a.Id == id);
        return animal == null ? NotFound() : Ok(animal);
    }

    [HttpPost]
    public IActionResult AddAnimal([FromBody] Animal animal)
    {
        animal.Id = StaticDb.Animals.Any() ? StaticDb.Animals.Max(a => a.Id) + 1 : 1;
        StaticDb.Animals.Add(animal);
        return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, animal);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAnimal(int id, [FromBody] Animal updated)
    {
        var animal = StaticDb.Animals.FirstOrDefault(a => a.Id == id);
        if (animal == null) return NotFound();

        animal.Name = updated.Name;
        animal.Category = updated.Category;
        animal.Weight = updated.Weight;
        animal.FurColor = updated.FurColor;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animal = StaticDb.Animals.FirstOrDefault(a => a.Id == id);
        if (animal == null) return NotFound();

        StaticDb.Animals.Remove(animal);
        StaticDb.Visits.RemoveAll(v => v.AnimalId == id);
        return NoContent();
    }
}

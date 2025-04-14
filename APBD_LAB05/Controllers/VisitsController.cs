using Microsoft.AspNetCore.Mvc;
using APBD_LAB_05.Data;
using APBD_LAB_05.models;

namespace APBD_LAB_05.Controllers;


[ApiController]
[Route("api/animals/{animalId}/visits")]
public class VisitsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetVisitsForAnimal(int animalId)
    {
        if (!StaticDb.Animals.Any(a => a.Id == animalId))
            return NotFound("Animal not found.");

        var visits = StaticDb.Visits.Where(v => v.AnimalId == animalId).ToList();
        return Ok(visits);
    }

    [HttpPost]
    public IActionResult AddVisit(int animalId, [FromBody] Visit visit)
    {
        if (!StaticDb.Animals.Any(a => a.Id == animalId))
            return NotFound("Animal not found.");

        visit.Id = StaticDb.Visits.Any() ? StaticDb.Visits.Max(v => v.Id) + 1 : 1;
        visit.AnimalId = animalId;
        StaticDb.Visits.Add(visit);
        return CreatedAtAction(nameof(GetVisitsForAnimal), new { animalId = animalId }, visit);
    }
}

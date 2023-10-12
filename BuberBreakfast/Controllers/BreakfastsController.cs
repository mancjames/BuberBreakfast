using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers;

[ApiController]
[Route("[controller]")]
public class BreakfastController : ControllerBase
{
    [HttpPost]

    public IActionResult CreateBreakfast(CreateBreakfastRequest request)
    {
        var breakfast = new Breakfast(
            Guid.NewGuid(), 
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet)

            //TODO: save to database 

            var response = new BreakfastResponse(
                breakfast.Id,
                breakfast.Name,
                breakfast.Description,
                breakfast.StartDateTime,
                breakfast.EndDateTime,
                breakfast.LastModifiedDateTime,
                breakfast.Savory,
                breakfast.Sweet
            )

        return CreatedAtAction(
            actionName: nameof(GetBreakfast),
            routeValues: new { id = breakfast.Id},
            value: response);
    }

    [HttpGet("{id:guid}")]

    public IActionResult GetBreakfast(Guid id)
    {
        return Ok(id);
    }

    [HttpPut("{id:guid}")]

    public IActionResult UpsetBreakfast(Guid id, UpsertBreakfastRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("{id:guid}")]

    public IActionResult DeleteBreakfast(Guid id)
    {
        return Ok(id);
    }
}
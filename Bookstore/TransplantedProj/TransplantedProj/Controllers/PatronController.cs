using Bookstore.Models;
using TransplantedProj.Repositories;

namespace BookStore.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/patrons")]
public class PatronController : ControllerBase
{
    private readonly PatronRepository _repository;

    public PatronController(PatronRepository repository)
    {
        this._repository = repository;
    }
    //[HttpPost("/{id}")]
    //public IActionResult AddPatronToBook(Patron patron, int id)
    //{
    //    _repository.Add(patron, id);
    //    return Ok();
    //}
    //[HttpGet]
    /*public IActionResult GetAllPatrons()
    {
        return Ok(_repository.GetAll());
    }
    [HttpGet("{id}")]
    public IActionResult GetPatronById(int id)
    {
        var patron = _repository.Get(id);
        if (patron == null)
        {
            return NotFound();
        }
        return Ok(patron);
    }
    [HttpPut("{id}")]
    public IActionResult UpdatePatronById(int id, Patron patron)
    {
        _repository.Update(id, patron);
        return Ok();
    }
    [HttpDelete("{id}")]
    public IActionResult RemovePatronById(int id)
    {
        _repository.Delete(id);
        return Ok();
    }*/
}

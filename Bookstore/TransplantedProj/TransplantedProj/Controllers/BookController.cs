using Bookstore.Models;
using Bookstore.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TransplantedProj.Repositories;

namespace BookStore.Controllers;

[ApiController]
[Route("api/books")]
public class BookController : ControllerBase
{
    
    private readonly BookRepository _repository;
    private readonly ILogger<BookController> _logger;

    public BookController(ILogger<BookController> logger,BookRepository repository)
    {
        this._logger = logger;
        this._repository = repository;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult> Get(int id) { return Ok(await this._repository.Get(id)); }
    [HttpGet("{id}/images")]
    public async Task<ActionResult> GetImages(int id) { return Ok(await this._repository.GetImages(id)); }
    [HttpGet]
    public async Task<ActionResult> GetAll() { return Ok(await this._repository.GetAll()); }

    [HttpGet("{id}/interested")]
    public async Task<ActionResult> GetPatrons(int id)
    {
        return Ok(await this._repository.GetPatrons(id));
    }
    [HttpGet("{id}/seller")]
    public async Task<ActionResult> GetSeller(int id)
    {
        return Ok(await this._repository.GetSeller(id));
    }

    [HttpPost]
    public async Task<ActionResult> Post(Book book) { return Ok(await this._repository.Create(book)); }
    [HttpPost("{id}/addPatron")]
    public async Task<ActionResult> AddPatron(int id, Patron p) { return Ok(await this._repository.AddPatron(id, p)); }
    [HttpPost("{id}/removePatron/{pId}")]
    public async Task<ActionResult> RemovePatron(int id, int pId) { return Ok(await this._repository.RemovePatron(id, pId)); }
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, Book book) { return Ok(await this._repository.Update(id,book)); }
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id) { return Ok(await this._repository.Delete(id)); }
}
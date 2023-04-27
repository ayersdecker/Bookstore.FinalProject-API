using Bookstore.Models;
using Bookstore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

[ApiController]
[Route("api/books")]
public class BookController : ControllerBase
{
    
    private readonly BookRepository _repository;

    public BookController(BookRepository repository)
    {
        this._repository = repository;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult> Get(int id) { return Ok(await this._repository.Get(id)); }
    [HttpGet]
    public async Task<ActionResult> GetAll() { return Ok(await this._repository.GetAll()); }
    [HttpPost]
    public async Task<ActionResult> Post(Book book) { return Ok(await this._repository.Create(book)); }
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, Book book) { return Ok(await this._repository.Update(id,book)); }
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id) { return Ok(await this._repository.Delete(id)); }
}
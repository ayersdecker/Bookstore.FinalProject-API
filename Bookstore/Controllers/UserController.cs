using Bookstore.Models;
using Bookstore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly UserRepository _repository;

    public UserController(UserRepository repository)
    {
        _repository = repository;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult> Get(int id) { return Ok(await this._repository.Get(id)); }
    [HttpGet]
    public async Task<ActionResult> GetAll() { return Ok(await this._repository.GetAll()); }
    [HttpPost]
    public async Task<ActionResult> Post(User user) { return Ok(await this._repository.Create(user)); }
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, User user) { return Ok(await this._repository.Update(id,user)); }
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id) { return Ok(await this._repository.Delete(id)); }
}
using Bookstore.Repositories;
using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using TransplantedProj.Repositories;

namespace BookStore.Controllers;

[ApiController]
[Route("api/transactions")]
public class TransactionController : ControllerBase
{
    private readonly TransactionRepository _repository;

    public TransactionController(TransactionRepository repository)
    {
        this._repository = repository;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult> Get(int id) { return Ok(await this._repository.Get(id)); }
    [HttpGet]
    public async Task<ActionResult> GetAll() { return Ok(await this._repository.GetAll()); }
    [HttpPost]
    public async Task<ActionResult> Post(Transaction trans) { return Ok(await this._repository.Create(trans)); }
}
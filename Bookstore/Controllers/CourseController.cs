using Bookstore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

[ApiController]
[Route("api/courses")]
public class CourseController : ControllerBase
{
    private readonly CourseRepository _repository;

    public CourseController(CourseRepository courseRepository)
    {
        this._repository = courseRepository;
    }
    [HttpGet]
    public async Task<ActionResult> GetAll() { return Ok(await this._repository.GetAll()); }

}
using Microsoft.AspNetCore.Mvc;
using TodoAPI.Todos;

namespace TodoAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TodosController : ControllerBase
{
    private readonly TodoRepository _repository;

    public TodosController(TodoRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("{id}", Name = nameof(GetTodo))]
    public async Task<IActionResult> GetTodo(int id)
    {
        return new GetTodo(_repository).Handle(id) is Todo todo ? Ok(todo) : NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> GetTodos()
    {
        return Ok(new GetTodos(_repository).Handle());
    }

    [HttpPost]
    public async Task<IActionResult> CreateTodo(Todo todo)
    {
        var newTodo = new CreateTodo(_repository).Handle(todo);

        return CreatedAtRoute(nameof(GetTodo), new { id = newTodo.Id }, newTodo);
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> EditTodo(int id, Todo todo)
    {
        new EditTodo(_repository).Handle(id, todo);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteTodo(int id)
    {
        new DeleteTodo(_repository).Handle(id);
        return Ok();
    }
}

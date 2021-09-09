using Microsoft.AspNetCore.Mvc;

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
        return _repository.GetTodo(id) is Todo todo ? Ok(todo) : NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> GetTodos()
    {
        return Ok(_repository.GetTodos());
    }

    [HttpPost]
    public async Task<IActionResult> CreateTodo(Todo todo)
    {
        var newTodo = _repository.AddTodo(todo);

        return CreatedAtRoute(nameof(GetTodo), new { id = newTodo.Id }, newTodo);
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> EditTodo(int id, Todo todo)
    {
        _repository.EditTodo(id, todo);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteTodo(int id)
    {
        _repository.DeleteTodo(id);
        return Ok();
    }
}

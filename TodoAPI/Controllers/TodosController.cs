using Microsoft.AspNetCore.Mvc;
using TodoAPI.Todos.Commands;
using TodoAPI.Todos.Queries;

namespace TodoAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TodosController : ControllerBase
{
    private readonly IServiceProvider _serviceProvider;

    public TodosController(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    [HttpGet("{id}", Name = nameof(GetTodo))]
    public async Task<IActionResult> GetTodo(int id)
    {
        return _serviceProvider.GetRequiredService<GetTodoQuery>().Handle(id) is Todo todo ? Ok(todo) : NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> GetTodos()
    {
        return Ok(_serviceProvider.GetRequiredService<GetTodosQuery>().Handle());
    }

    [HttpPost]
    public async Task<IActionResult> CreateTodo(Todo todo)
    {
        var newTodo = _serviceProvider.GetRequiredService<CreateTodoCommand>().Handle(todo);

        return CreatedAtRoute(nameof(GetTodo), new { id = newTodo.Id }, newTodo);
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> EditTodo(int id, Todo todo)
    {
        _serviceProvider.GetRequiredService<EditTodoCommand>().Handle(id, todo);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteTodo(int id)
    {
        _serviceProvider.GetRequiredService<DeleteTodoCommand>().Handle(id);
        return Ok();
    }
}

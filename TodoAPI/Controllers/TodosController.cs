using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.Todos.Commands;
using TodoAPI.Todos.Queries;

namespace TodoAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TodosController : ControllerBase
{
    private readonly IMediator _mediator;

    public TodosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}", Name = nameof(GetTodo))]
    public async Task<IActionResult> GetTodo(int id)
    {
        return await _mediator.Send(new GetTodoQuery(id)) is Todo todo ? Ok(todo) : NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> GetTodos()
    {
        return Ok(await _mediator.Send(new GetTodosQuery()));
    }

    [HttpPost]
    public async Task<IActionResult> CreateTodo(Todo todo)
    {
        var newTodo = await _mediator.Send(new CreateTodoCommand(todo));

        return CreatedAtRoute(nameof(GetTodo), new { id = newTodo.Id }, newTodo);
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> EditTodo(int id, Todo todo)
    {
        await _mediator.Send(new EditTodoCommand(id, todo));
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodo(int id)
    {
        await _mediator.Send(new DeleteTodoCommand(id));
        return Ok();
    }
}

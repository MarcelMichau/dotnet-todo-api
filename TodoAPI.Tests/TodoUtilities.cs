using TodoAPI.Todos.Commands;
using static TodoAPI.Todos.Commands.CreateTodoCommand;

namespace TodoAPI.Tests;
public static class TodoUtilities
{
    public static async Task<int> CreateDummyTodo(CreateTodoCommandHandler handler)
    {
        var todoText = "Write another Test";

        var newTodo = await handler.Handle(new CreateTodoCommand(todoText), CancellationToken.None);

        return newTodo.Id;
    }
}
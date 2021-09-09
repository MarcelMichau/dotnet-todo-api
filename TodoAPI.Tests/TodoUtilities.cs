using TodoAPI.Todos.Commands;

namespace TodoAPI.Tests;
public static class TodoUtilities
{
    public static int CreateDummyTodo(CreateTodoCommand handler)
    {
        var todo = new Todo
        {
            Text = "Write another Test"
        };

        var newTodo = handler.Handle(todo);

        return newTodo.Id;
    }
}
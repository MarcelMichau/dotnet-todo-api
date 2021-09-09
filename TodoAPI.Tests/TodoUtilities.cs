using TodoAPI.Todos;

namespace TodoAPI.Tests;
public static class TodoUtilities
{
    public static int CreateDummyTodo(CreateTodo handler)
    {
        var todo = new Todo
        {
            Text = "Write another Test"
        };

        var newTodo = handler.Handle(todo);

        return newTodo.Id;
    }
}
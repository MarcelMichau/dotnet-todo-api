
namespace TodoAPI;
public class TodoRepository
{
    private readonly List<Todo> _todos = new();
    private int _counter = 1;

    public Todo GetTodo(int id)
    {
        return _todos.First(x => x.Id == id);
    }

    public List<Todo> GetTodos()
    {
        return _todos;
    }

    public Todo AddTodo(Todo todo)
    {
        var newTodo = new Todo
        {
            Id = _counter++,
            Text = todo.Text,
            IsCompleted = false
        };

        _todos.Add(newTodo);

        return newTodo;
    }

    public void EditTodo(int id, Todo todo)
    {
        var savedTodo = _todos.First(x => x.Id == id);

        savedTodo.IsCompleted = todo.IsCompleted;
    }

    public void DeleteTodo(int id)
    {
        _todos.RemoveAll(x => x.Id == id);
    }
}

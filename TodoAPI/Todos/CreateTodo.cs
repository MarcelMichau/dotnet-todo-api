
namespace TodoAPI.Todos;
public class CreateTodo
{
    private readonly TodoRepository _repository;

    public CreateTodo(TodoRepository repository)
    {
        _repository = repository;
    }

    public Todo Handle(Todo todo)
    {
        return _repository.AddTodo(todo);
    }
}
